using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using Org.BouncyCastle.X509;

namespace Aop.Api.Util
{
    public class AlipaySignature
    {
        /** 默认编码字符集 */
        private static string DEFAULT_CHARSET = "GBK";

        /// <summary>
        /// 从支付宝公钥证书中提取支付宝公钥
        /// </summary>
        /// <param name="certPath">证书路径</param>
        /// <returns>公钥字符串</returns>
        public static string ExtractPemPublicKeyFromCert(string certPath)
        {
            X509Certificate alipayPublicKeyCert = AntCertificationUtil.ParseCert(File.ReadAllText(certPath));
            return AntCertificationUtil.ExtractPemPublicKeyFromCert(alipayPublicKeyCert);
        }

        /// <summary>
        /// 异步通知参数验签，RSA或RSA2签名，均可调用此方法进行验签
        /// V1版本方法将删除sign_type参数再进行验签，V2版本方法则不会
        /// </summary>
        /// <param name="parameters">待验签的参数集合</param>
        /// <param name="alipayPublicCertPath">支付宝公钥证书路径</param>
        /// <param name="charset">参数编码字符集</param>
        /// <param name="signType">签名类型，可选RSA或RSA2</param>
        /// <returns>true：验证成功；false：验证失败</returns>
        public static bool RSACertCheckV1(IDictionary<string, string> parameters, string alipayPublicCertPath, string charset, string signType)
        {
            string alipayPublicKey = ExtractPemPublicKeyFromCert(alipayPublicCertPath);
            return RSACheckV1(parameters, alipayPublicKey, charset, signType, false);
        }

        /// <summary>
        /// 异步通知参数验签，RSA或RSA2签名，均可调用此方法进行验签
        /// V1版本方法将删除sign_type参数再进行验签，V2版本方法则不会
        /// </summary>
        /// <param name="parameters">待验签字符串</param>
        /// <param name="publicKeyPem">PEM格式的支付宝公钥</param>
        /// <param name="charset">参数编码字符集</param>
        /// <param name="signType">签名类型，可选RSA或RSA2</param>
        /// <param name="keyFromFile">是否从文件加载支付宝公钥内容。
        /// 如果该参数为true，则publicKeyPem为公钥文件路径；
        /// 如果该参数为false，则publicKeyPem为公钥内容（去除-----BEGIN PUBLIC KEY-----头和-----END PUBLIC KEY-----尾）
        /// </param>
        /// <returns>true：验证成功；false：验证失败</returns>
        public static bool RSACheckV1(IDictionary<string, string> parameters, string publicKeyPem, string charset, string signType, bool keyFromFile)
        {
            string sign = parameters["sign"];

            parameters.Remove("sign");
            parameters.Remove("sign_type");
            string signContent = GetSignContent(parameters);
            return RSACheckContent(signContent, sign, publicKeyPem, charset, signType, keyFromFile);
        }

        /// <summary>
        /// 异步通知参数验签，RSA或RSA2签名，均可调用此方法进行验签
        /// V1版本方法将删除sign_type参数再进行验签，V2版本方法则不会
        /// </summary>
        /// <param name="parameters">待验签的参数集合</param>
        /// <param name="alipayPublicCertPath">支付宝公钥证书路径</param>
        /// <param name="charset">参数编码字符集</param>
        /// <param name="signType">签名类型，可选RSA或RSA2</param>
        /// <returns>true：验证成功；false：验证失败</returns>
        public static bool RSACertCheckV2(IDictionary<string, string> parameters, string alipayPublicCertPath, string charset, string signType)
        {
            string alipayPublicKey = ExtractPemPublicKeyFromCert(alipayPublicCertPath);
            return RSACheckV2(parameters, alipayPublicKey, charset, signType, false);
        }

        /// <summary>
        /// 异步通知参数验签，RSA或RSA2签名，均可调用此方法进行验签
        /// V1版本方法将删除sign_type参数再进行验签，V2版本方法则不会
        /// </summary>
        /// <param name="parameters">待验签字符串</param>
        /// <param name="publicKeyPem">PEM格式的支付宝公钥</param>
        /// <param name="charset">参数编码字符集</param>
        /// <param name="signType">签名类型，可选RSA或RSA2</param>
        /// <param name="keyFromFile">是否从文件加载支付宝公钥内容。
        /// 如果该参数为true，则publicKeyPem为公钥文件路径；
        /// 如果该参数为false，则publicKeyPem为公钥内容（去除-----BEGIN PUBLIC KEY-----头和-----END PUBLIC KEY-----尾）
        /// </param>
        /// <returns>true：验证成功；false：验证失败</returns>
        public static bool RSACheckV2(IDictionary<string, string> parameters, string publicKeyPem, string charset, string signType, bool keyFromFile)
        {
            string sign = parameters["sign"];

            parameters.Remove("sign");
            string signContent = GetSignContent(parameters);

            return RSACheckContent(signContent, sign, publicKeyPem, charset, signType, keyFromFile);
        }

        /// <summary>
        /// 对指定内容验证签名
        /// </summary>
        /// <param name="signContent">待验签的内容</param>
        /// <param name="sign">签名字符串</param>
        /// <param name="publicKeyPem">支付宝公钥字符串</param>
        /// <param name="charset">字符集编码</param>
        /// <param name="signType">签名算法类型，RSA或RSA2</param>
        /// <param name="keyFromFile">是否从文件加载支付宝公钥内容。
        /// 如果该参数为true，则publicKeyPem为公钥文件路径；
        /// 如果该参数为false，则publicKeyPem为公钥内容（去除-----BEGIN PUBLIC KEY-----头和-----END PUBLIC KEY-----尾）
        /// </param>
        /// <returns>true：验证成功；false：验证失败</returns>
        public static bool RSACheckContent(string signContent, string sign, string publicKeyPem, string charset, string signType, bool keyFromFile)
        {

            try
            {
                if (string.IsNullOrEmpty(charset))
                {
                    charset = DEFAULT_CHARSET;
                }

                string sPublicKeyPEM;

                if (keyFromFile)
                {
                    sPublicKeyPEM = File.ReadAllText(publicKeyPem);
                }
                else
                {
                    sPublicKeyPEM = "-----BEGIN PUBLIC KEY-----\r\n";
                    sPublicKeyPEM += publicKeyPem;
                    sPublicKeyPEM += "-----END PUBLIC KEY-----\r\n\r\n";
                }


                if ("RSA2".Equals(signType))
                {
                    RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                    rsa.PersistKeyInCsp = false;
                    LoadPemPublicKey(rsa, sPublicKeyPEM);

                    bool bVerifyResultOriginal = rsa.VerifyData(Encoding.GetEncoding(charset).GetBytes(signContent), "SHA256", Convert.FromBase64String(sign));
                    return bVerifyResultOriginal;
                }
                else
                {
                    RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                    rsa.PersistKeyInCsp = false;
                    LoadPemPublicKey(rsa, sPublicKeyPEM);

                    SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
                    bool bVerifyResultOriginal = rsa.VerifyData(Encoding.GetEncoding(charset).GetBytes(signContent), sha1, Convert.FromBase64String(sign));
                    return bVerifyResultOriginal;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("验签出现异常。" + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 验签并解密，目前适用于公众号
        /// </summary>
        /// <param name="parameters">待验签并解密的参数</param>
        /// <param name="alipayPublicKey">支付宝公钥字符串，用于验签</param>
        /// <param name="cusPrivateKey">商户私钥字符串，用于解密</param>
        /// <param name="isCheckSign">是否检查签名</param>
        /// <param name="isDecrypt">是否解密</param>
        /// <param name="signType">非对称加密算法类型，RSA或RSA2</param>
        /// <param name="keyFromFile">是否从文件加载支付宝公钥内容。
        /// 如果该参数为true，则publicKeyPem为公钥文件路径；
        /// 如果该参数为false，则publicKeyPem为公钥内容（去除-----BEGIN PUBLIC KEY-----头和-----END PUBLIC KEY-----尾）
        /// </param>
        /// <returns>验签解密后的内容</returns>
        public static string CheckSignAndDecrypt(IDictionary<string, string> parameters, string alipayPublicKey,
                                             string cusPrivateKey, bool isCheckSign,
                                             bool isDecrypt, string signType, bool keyFromFile)
        {
            string charset = parameters["charset"];
            string bizContent = parameters["biz_content"];
            if (isCheckSign)
            {
                if (!RSACheckV2(parameters, alipayPublicKey, charset, signType, keyFromFile))
                {
                    throw new AopException("rsaCheck failure:rsaParams=" + parameters);
                }
            }

            if (isDecrypt)
            {
                return RSADecrypt(bizContent, cusPrivateKey, charset, signType, keyFromFile);
            }

            return bizContent;
        }

        /// <summary>
        /// 加密并加签，目前适用于公众号
        /// </summary>
        /// <param name="bizContent">待加密和加签的原文</param>
        /// <param name="alipayPublicKey">支付宝公钥字符串，用于加密</param>
        /// <param name="cusPrivateKey">商户私钥字符串，用于加签</param>
        /// <param name="charset">字符集编码</param>
        /// <param name="isEncrypt">是否需要加密</param>
        /// <param name="isSign">是否需要加签</param>
        /// <param name="signType">非对称加密算法类型，RSA或RSA2</param>
        /// <param name="keyFromFile">是否从文件加载支付宝公钥内容。
        /// 如果该参数为true，则publicKeyPem为公钥文件路径；
        /// 如果该参数为false，则publicKeyPem为公钥内容（去除-----BEGIN PUBLIC KEY-----头和-----END PUBLIC KEY-----尾）
        /// </param>
        /// <returns>加密加签后的内容</returns>
        public static string encryptAndSign(string bizContent, string alipayPublicKey,
                                        string cusPrivateKey, string charset, bool isEncrypt,
                                        bool isSign, string signType, bool keyFromFile)
        {
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(charset))
            {
                charset = DEFAULT_CHARSET;
            }
            sb.Append("<?xml version=\"1.0\" encoding=\"" + charset + "\"?>");
            if (isEncrypt)
            {// 加密
                sb.Append("<alipay>");
                String encrypted = RSAEncrypt(bizContent, alipayPublicKey, charset, keyFromFile);
                sb.Append("<response>" + encrypted + "</response>");
                sb.Append("<encryption_type>" + signType + "</encryption_type>");
                if (isSign)
                {
                    String sign = RSASign(encrypted, cusPrivateKey, charset, signType, keyFromFile);
                    sb.Append("<sign>" + sign + "</sign>");
                    sb.Append("<sign_type>" + signType + "</sign_type>");
                }
                sb.Append("</alipay>");
            }
            else if (isSign)
            {// 不加密，但需要签名
                sb.Append("<alipay>");
                sb.Append("<response>" + bizContent + "</response>");
                String sign = RSASign(bizContent, cusPrivateKey, charset, signType, keyFromFile);
                sb.Append("<sign>" + sign + "</sign>");
                sb.Append("<sign_type>" + signType + "</sign_type>");
                sb.Append("</alipay>");
            }
            else
            {// 不加密，不加签
                sb.Append(bizContent);
            }
            return sb.ToString();
        }





        public static string GetSignContent(IDictionary<string, string> parameters)
        {
            // 第一步：把字典按Key的字母顺序排序
            IDictionary<string, string> sortedParams = new SortedDictionary<string, string>(parameters, StringComparer.Ordinal);
            IEnumerator<KeyValuePair<string, string>> dem = sortedParams.GetEnumerator();

            // 第二步：把所有参数名和参数值串在一起
            StringBuilder query = new StringBuilder("");
            while (dem.MoveNext())
            {
                string key = dem.Current.Key;
                string value = dem.Current.Value;
                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                {
                    query.Append(key).Append("=").Append(value).Append("&");
                }
            }
            string content = query.ToString().Substring(0, query.Length - 1);

            return content;
        }

        public static string RSASign(IDictionary<string, string> parameters, string privateKeyPem, string charset, string signType)
        {
            string signContent = GetSignContent(parameters);

            return RSASignCharSet(signContent, privateKeyPem, charset, signType);
        }

        public static string RSASign(string data, string privateKeyPem, string charset, string signType)
        {
            return RSASignCharSet(data, privateKeyPem, charset, signType);
        }

        public static string RSASign(IDictionary<string, string> parameters, string privateKeyPem, string charset, bool keyFromFile, string signType)
        {
            string signContent = GetSignContent(parameters);

            return RSASignCharSet(signContent, privateKeyPem, charset, keyFromFile, signType);
        }

        public static string RSASign(string data, string privateKeyPem, string charset, string signType, bool keyFromFile)
        {
            return RSASignCharSet(data, privateKeyPem, charset, keyFromFile, signType);
        }

        public static string RSASignCharSet(string data, string privateKeyPem, string charset, string signType)
        {
            RSACryptoServiceProvider rsaCsp = LoadCertificateFile(privateKeyPem, signType);
            byte[] dataBytes = null;
            if (string.IsNullOrEmpty(charset))
            {
                dataBytes = Encoding.UTF8.GetBytes(data);
            }
            else
            {
                dataBytes = Encoding.GetEncoding(charset).GetBytes(data);
            }


            if ("RSA2".Equals(signType))
            {

                byte[] signatureBytes = rsaCsp.SignData(dataBytes, "SHA256");

                return Convert.ToBase64String(signatureBytes);

            }
            else
            {
                byte[] signatureBytes = rsaCsp.SignData(dataBytes, "SHA1");

                return Convert.ToBase64String(signatureBytes);
            }
        }

        public static string RSASignCharSet(string data, string privateKeyPem, string charset, bool keyFromFile, string signType)
        {

            byte[] signatureBytes = null;
            try
            {
                RSACryptoServiceProvider rsaCsp = null;
                if (keyFromFile)
                {//文件读取
                    rsaCsp = LoadCertificateFile(privateKeyPem, signType);
                }
                else
                {
                    //字符串获取
                    rsaCsp = LoadCertificateString(privateKeyPem, signType);
                }

                byte[] dataBytes = null;
                if (string.IsNullOrEmpty(charset))
                {
                    dataBytes = Encoding.UTF8.GetBytes(data);
                }
                else
                {
                    dataBytes = Encoding.GetEncoding(charset).GetBytes(data);
                }
                if (null == rsaCsp)
                {
                    throw new AopException("您使用的私钥格式错误，请检查RSA私钥配置" + ",charset = " + charset);
                }
                if ("RSA2".Equals(signType))
                {

                    signatureBytes = rsaCsp.SignData(dataBytes, "SHA256");

                }
                else
                {
                    signatureBytes = rsaCsp.SignData(dataBytes, "SHA1");
                }

            }
            catch (Exception ex)
            {
                throw new AopException("您使用的私钥格式错误，请检查RSA私钥配置" + "，charset = " + charset + "。 " + ex.Message);
            }
            return Convert.ToBase64String(signatureBytes);
        }

        public static bool RSACheckV1(IDictionary<string, string> parameters, string publicKeyPem, string charset)
        {
            string sign = parameters["sign"];

            parameters.Remove("sign");
            parameters.Remove("sign_type");
            string signContent = GetSignContent(parameters);
            return RSACheckContent(signContent, sign, publicKeyPem, charset, "RSA");
        }

        public static bool RSACheckV1(IDictionary<string, string> parameters, string publicKeyPem)
        {
            string sign = parameters["sign"];

            parameters.Remove("sign");
            parameters.Remove("sign_type");
            string signContent = GetSignContent(parameters);

            return RSACheckContent(signContent, sign, publicKeyPem, DEFAULT_CHARSET, "RSA");
        }

        public static bool RSACheckV2(IDictionary<string, string> parameters, string publicKeyPem)
        {
            string sign = parameters["sign"];

            parameters.Remove("sign");
            string signContent = GetSignContent(parameters);

            return RSACheckContent(signContent, sign, publicKeyPem, DEFAULT_CHARSET, "RSA");
        }

        public static bool RSACheckV2(IDictionary<string, string> parameters, string publicKeyPem, string charset)
        {
            string sign = parameters["sign"];

            parameters.Remove("sign");
            string signContent = GetSignContent(parameters);

            return RSACheckContent(signContent, sign, publicKeyPem, charset, "RSA");
        }

        public static bool RSACheckContent(string signContent, string sign, string publicKeyPem, string charset, string signType)
        {

            try
            {
                if (string.IsNullOrEmpty(charset))
                {
                    charset = DEFAULT_CHARSET;
                }


                if ("RSA2".Equals(signType))
                {
                    string sPublicKeyPEM = File.ReadAllText(publicKeyPem);

                    RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                    rsa.PersistKeyInCsp = false;
                    LoadPemPublicKey(rsa, sPublicKeyPEM);

                    bool bVerifyResultOriginal = rsa.VerifyData(Encoding.GetEncoding(charset).GetBytes(signContent), "SHA256", Convert.FromBase64String(sign));
                    return bVerifyResultOriginal;

                }
                else
                {
                    string sPublicKeyPEM = File.ReadAllText(publicKeyPem);
                    RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                    rsa.PersistKeyInCsp = false;
                    LoadPemPublicKey(rsa, sPublicKeyPEM);

                    SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
                    bool bVerifyResultOriginal = rsa.VerifyData(Encoding.GetEncoding(charset).GetBytes(signContent), sha1, Convert.FromBase64String(sign));
                    return bVerifyResultOriginal;
                }
            }
            catch
            {
                return false;
            }

        }

        public static bool RSACheckContent(string signContent, string sign, string publicKeyPem, string charset, bool keyFromFile)
        {
            try
            {
                string sPublicKeyPEM;
                if (keyFromFile)
                {
                    sPublicKeyPEM = File.ReadAllText(publicKeyPem);
                }
                else
                {
                    sPublicKeyPEM = "-----BEGIN PUBLIC KEY-----\r\n";
                    sPublicKeyPEM = sPublicKeyPEM + publicKeyPem;
                    sPublicKeyPEM = sPublicKeyPEM + "-----END PUBLIC KEY-----\r\n\r\n";
                }
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.PersistKeyInCsp = false;
                LoadPemPublicKey(rsa, sPublicKeyPEM);
                SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
                if (string.IsNullOrEmpty(charset))
                {
                    charset = DEFAULT_CHARSET;
                }
                bool bVerifyResultOriginal = rsa.VerifyData(Encoding.GetEncoding(charset).GetBytes(signContent), sha1, Convert.FromBase64String(sign));
                return bVerifyResultOriginal;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("验签出现异常。" + ex.Message);
                return false;
            }

        }

        public static string CheckSignAndDecrypt(IDictionary<string, string> parameters, string alipayPublicKey,
                                             string cusPrivateKey, bool isCheckSign,
                                             bool isDecrypt)
        {
            string charset = parameters["charset"];
            string bizContent = parameters["biz_content"];
            if (isCheckSign)
            {
                if (!RSACheckV2(parameters, alipayPublicKey, charset))
                {
                    throw new AopException("rsaCheck failure:rsaParams=" + parameters);
                }
            }

            if (isDecrypt)
            {
                return RSADecrypt(bizContent, cusPrivateKey, charset, "RSA");
            }

            return bizContent;
        }

        public static string encryptAndSign(string bizContent, string alipayPublicKey,
                                        string cusPrivateKey, string charset, bool isEncrypt,
                                        bool isSign)
        {
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(charset))
            {
                charset = DEFAULT_CHARSET;
            }
            sb.Append("<?xml version=\"1.0\" encoding=\"" + charset + "\"?>");
            if (isEncrypt)
            {// 加密
                sb.Append("<alipay>");
                String encrypted = RSAEncrypt(bizContent, alipayPublicKey, charset);
                sb.Append("<response>" + encrypted + "</response>");
                sb.Append("<encryption_type>RSA</encryption_type>");
                if (isSign)
                {
                    String sign = RSASign(encrypted, cusPrivateKey, charset, "RSA");
                    sb.Append("<sign>" + sign + "</sign>");
                    sb.Append("<sign_type>RSA</sign_type>");
                }
                sb.Append("</alipay>");
            }
            else if (isSign)
            {// 不加密，但需要签名
                sb.Append("<alipay>");
                sb.Append("<response>" + bizContent + "</response>");
                String sign = RSASign(bizContent, cusPrivateKey, charset, "RSA");
                sb.Append("<sign>" + sign + "</sign>");
                sb.Append("<sign_type>RSA</sign_type>");
                sb.Append("</alipay>");
            }
            else
            {// 不加密，不加签
                sb.Append(bizContent);
            }
            return sb.ToString();
        }

        public static string RSAEncrypt(string content, string publicKeyPem, string charset)
        {
            try
            {
                string sPublicKeyPEM = File.ReadAllText(publicKeyPem);
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.PersistKeyInCsp = false;
                LoadPemPublicKey(rsa, sPublicKeyPEM);
                if (string.IsNullOrEmpty(charset))
                {
                    charset = DEFAULT_CHARSET;
                }
                byte[] data = Encoding.GetEncoding(charset).GetBytes(content);
                int maxBlockSize = rsa.KeySize / 8 - 11; //加密块最大长度限制
                if (data.Length <= maxBlockSize)
                {
                    byte[] cipherbytes = rsa.Encrypt(data, false);
                    return Convert.ToBase64String(cipherbytes);
                }
                MemoryStream plaiStream = new MemoryStream(data);
                MemoryStream crypStream = new MemoryStream();
                Byte[] buffer = new Byte[maxBlockSize];
                int blockSize = plaiStream.Read(buffer, 0, maxBlockSize);
                while (blockSize > 0)
                {
                    Byte[] toEncrypt = new Byte[blockSize];
                    Array.Copy(buffer, 0, toEncrypt, 0, blockSize);
                    Byte[] cryptograph = rsa.Encrypt(toEncrypt, false);
                    crypStream.Write(cryptograph, 0, cryptograph.Length);
                    blockSize = plaiStream.Read(buffer, 0, maxBlockSize);
                }

                return Convert.ToBase64String(crypStream.ToArray(), Base64FormattingOptions.None);
            }
            catch (Exception ex)
            {
                throw new AopException("EncryptContent = " + content + ",charset = " + charset, ex);
            }
        }
        public static string RSAEncrypt(string content, string publicKeyPem, string charset, bool keyFromFile)
        {
            try
            {
                string sPublicKeyPEM;
                if (keyFromFile)
                {
                    sPublicKeyPEM = File.ReadAllText(publicKeyPem);
                }
                else
                {
                    sPublicKeyPEM = "-----BEGIN PUBLIC KEY-----\r\n";
                    sPublicKeyPEM += publicKeyPem;
                    sPublicKeyPEM += "-----END PUBLIC KEY-----\r\n\r\n";
                }
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.PersistKeyInCsp = false;
                LoadPemPublicKey(rsa, sPublicKeyPEM);
                if (string.IsNullOrEmpty(charset))
                {
                    charset = DEFAULT_CHARSET;
                }
                byte[] data = Encoding.GetEncoding(charset).GetBytes(content);
                int maxBlockSize = rsa.KeySize / 8 - 11; //加密块最大长度限制
                if (data.Length <= maxBlockSize)
                {
                    byte[] cipherbytes = rsa.Encrypt(data, false);
                    return Convert.ToBase64String(cipherbytes);
                }
                MemoryStream plaiStream = new MemoryStream(data);
                MemoryStream crypStream = new MemoryStream();
                Byte[] buffer = new Byte[maxBlockSize];
                int blockSize = plaiStream.Read(buffer, 0, maxBlockSize);
                while (blockSize > 0)
                {
                    Byte[] toEncrypt = new Byte[blockSize];
                    Array.Copy(buffer, 0, toEncrypt, 0, blockSize);
                    Byte[] cryptograph = rsa.Encrypt(toEncrypt, false);
                    crypStream.Write(cryptograph, 0, cryptograph.Length);
                    blockSize = plaiStream.Read(buffer, 0, maxBlockSize);
                }

                return Convert.ToBase64String(crypStream.ToArray(), Base64FormattingOptions.None);
            }
            catch (Exception ex)
            {
                throw new AopException("EncryptContent = " + content + ",charset = " + charset, ex);
            }
        }

        public static string RSADecrypt(string content, string privateKeyPem, string charset, string signType)
        {
            try
            {
                RSACryptoServiceProvider rsaCsp = LoadCertificateFile(privateKeyPem, signType);
                if (string.IsNullOrEmpty(charset))
                {
                    charset = DEFAULT_CHARSET;
                }
                byte[] data = Convert.FromBase64String(content);
                int maxBlockSize = rsaCsp.KeySize / 8; //解密块最大长度限制
                if (data.Length <= maxBlockSize)
                {
                    byte[] cipherbytes = rsaCsp.Decrypt(data, false);
                    return Encoding.GetEncoding(charset).GetString(cipherbytes);
                }
                MemoryStream crypStream = new MemoryStream(data);
                MemoryStream plaiStream = new MemoryStream();
                Byte[] buffer = new Byte[maxBlockSize];
                int blockSize = crypStream.Read(buffer, 0, maxBlockSize);
                while (blockSize > 0)
                {
                    Byte[] toDecrypt = new Byte[blockSize];
                    Array.Copy(buffer, 0, toDecrypt, 0, blockSize);
                    Byte[] cryptograph = rsaCsp.Decrypt(toDecrypt, false);
                    plaiStream.Write(cryptograph, 0, cryptograph.Length);
                    blockSize = crypStream.Read(buffer, 0, maxBlockSize);
                }

                return Encoding.GetEncoding(charset).GetString(plaiStream.ToArray());
            }
            catch (Exception ex)
            {
                throw new AopException("DecryptContent = " + content + ",charset = " + charset, ex);
            }
        }

        public static string RSADecrypt(string content, string privateKeyPem, string charset, string signType, bool keyFromFile)
        {
            try
            {
                RSACryptoServiceProvider rsaCsp = null;
                if (keyFromFile)
                {
                    //文件读取
                    rsaCsp = LoadCertificateFile(privateKeyPem, signType);
                }
                else
                {
                    //字符串获取
                    rsaCsp = LoadCertificateString(privateKeyPem, signType);
                }
                if (string.IsNullOrEmpty(charset))
                {
                    charset = DEFAULT_CHARSET;
                }
                byte[] data = Convert.FromBase64String(content);
                int maxBlockSize = rsaCsp.KeySize / 8; //解密块最大长度限制
                if (data.Length <= maxBlockSize)
                {
                    byte[] cipherbytes = rsaCsp.Decrypt(data, false);
                    return Encoding.GetEncoding(charset).GetString(cipherbytes);
                }
                MemoryStream crypStream = new MemoryStream(data);
                MemoryStream plaiStream = new MemoryStream();
                Byte[] buffer = new Byte[maxBlockSize];
                int blockSize = crypStream.Read(buffer, 0, maxBlockSize);
                while (blockSize > 0)
                {
                    Byte[] toDecrypt = new Byte[blockSize];
                    Array.Copy(buffer, 0, toDecrypt, 0, blockSize);
                    Byte[] cryptograph = rsaCsp.Decrypt(toDecrypt, false);
                    plaiStream.Write(cryptograph, 0, cryptograph.Length);
                    blockSize = crypStream.Read(buffer, 0, maxBlockSize);
                }

                return Encoding.GetEncoding(charset).GetString(plaiStream.ToArray());
            }
            catch (Exception ex)
            {
                throw new AopException("DecryptContent = " + content + ",charset = " + charset, ex);
            }
        }

        private static byte[] GetPem(string type, byte[] data)
        {
            string pem = Encoding.UTF8.GetString(data);
            string header = String.Format("-----BEGIN {0}-----\\n", type);
            string footer = String.Format("-----END {0}-----", type);
            int start = pem.IndexOf(header, StringComparison.Ordinal) + header.Length;
            int end = pem.IndexOf(footer, start, StringComparison.Ordinal);
            string base64 = pem.Substring(start, (end - start));

            return Convert.FromBase64String(base64);
        }

        private static RSACryptoServiceProvider LoadCertificateFile(string filename, string signType)
        {
            using (FileStream fs = File.OpenRead(filename))
            {
                byte[] data = new byte[fs.Length];
                byte[] res = null;
                fs.Read(data, 0, data.Length);
                if (data[0] != 0x30)
                {
                    res = GetPem("RSA PRIVATE KEY", data);
                }
                try
                {
                    RSACryptoServiceProvider rsa = DecodeRSAPrivateKey(res, signType);
                    return rsa;
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("从文件加载私钥出现异常。" + ex.Message);
                    return null;
                }
            }
        }

        private static RSACryptoServiceProvider LoadCertificateString(string strKey, string signType)
        {
            try
            {
                return DecodeRSAPrivateKey(Convert.FromBase64String(strKey), signType);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("私钥解析出现异常。" + ex.Message);
                return null;
            }
        }

        private static RSACryptoServiceProvider DecodeRSAPrivateKey(byte[] privkey, string signType)
        {
            byte[] MODULUS, E, D, P, Q, DP, DQ, IQ;

            // --------- Set up stream to decode the asn.1 encoded RSA private key ------
            MemoryStream mem = new MemoryStream(privkey);
            BinaryReader binr = new BinaryReader(mem);  //wrap Memory Stream with BinaryReader for easy reading
            byte bt = 0;
            ushort twobytes = 0;
            int elems = 0;
            try
            {
                twobytes = binr.ReadUInt16();
                if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)
                    binr.ReadByte();    //advance 1 byte
                else if (twobytes == 0x8230)
                    binr.ReadInt16();    //advance 2 bytes
                else
                    return null;

                twobytes = binr.ReadUInt16();
                if (twobytes != 0x0102) //version number
                    return null;
                bt = binr.ReadByte();
                if (bt != 0x00)
                    return null;


                //------ all private key components are Integer sequences ----
                elems = GetIntegerSize(binr);
                MODULUS = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                E = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                D = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                P = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                Q = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                DP = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                DQ = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                IQ = binr.ReadBytes(elems);


                // ------- create RSACryptoServiceProvider instance and initialize with public key -----
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                RSAParameters RSAparams = new RSAParameters();
                RSAparams.Modulus = MODULUS;
                RSAparams.Exponent = E;
                RSAparams.D = D;
                RSAparams.P = P;
                RSAparams.Q = Q;
                RSAparams.DP = DP;
                RSAparams.DQ = DQ;
                RSAparams.InverseQ = IQ;
                RSA.ImportParameters(RSAparams);
                return RSA;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("解码私钥出现异常。" + ex.Message);
                return null;
            }
            finally
            {
                binr.Close();
            }
        }

        private static int GetIntegerSize(BinaryReader binr)
        {
            byte bt = 0;
            byte lowbyte = 0x00;
            byte highbyte = 0x00;
            int count = 0;
            bt = binr.ReadByte();
            if (bt != 0x02)		//expect integer
                return 0;
            bt = binr.ReadByte();

            if (bt == 0x81)
                count = binr.ReadByte();	// data size in next byte
            else
                if (bt == 0x82)
            {
                highbyte = binr.ReadByte(); // data size in next 2 bytes
                lowbyte = binr.ReadByte();
                byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };
                count = BitConverter.ToInt32(modint, 0);
            }
            else
            {
                count = bt;     // we already have the data size
            }

            while (binr.ReadByte() == 0x00)
            {	//remove high order zeros in data
                count -= 1;
            }
            binr.BaseStream.Seek(-1, SeekOrigin.Current);		//last ReadByte wasn't a removed zero, so back up a byte
            return count;
        }

        private static void LoadPemPublicKey(RSACryptoServiceProvider provider, string pemPublicKey)
        {
            provider.ImportParameters(ConvertFromPemPublicKey(pemPublicKey));
        }

        private static RSAParameters ConvertFromPemPublicKey(string pemPublickKey)
        {
            if (string.IsNullOrEmpty(pemPublickKey))
            {
                throw new AopException("PEM格式公钥不可为空。");
            }
            pemPublickKey = pemPublickKey.Replace("-----BEGIN PUBLIC KEY-----", "").Replace("-----END PUBLIC KEY-----", "").Replace("\n", "").Replace("\r", "");
            byte[] keyData = Convert.FromBase64String(pemPublickKey);
            bool keySize1024 = (keyData.Length == 162);
            bool keySize2048 = (keyData.Length == 294);
            if (!(keySize1024 || keySize2048))
            {
                throw new AopException("公钥长度只支持1024和2048。");
            }
            byte[] pemModulus = (keySize1024 ? new byte[128] : new byte[256]);
            byte[] pemPublicExponent = new byte[3];
            Array.Copy(keyData, (keySize1024 ? 29 : 33), pemModulus, 0, (keySize1024 ? 128 : 256));
            Array.Copy(keyData, (keySize1024 ? 159 : 291), pemPublicExponent, 0, 3);
            RSAParameters para = new RSAParameters();
            para.Modulus = pemModulus;
            para.Exponent = pemPublicExponent;
            return para;
        }

        public static SignSourceData ExtractSignContent(String str, int begin)
        {
            if (str == null)
            {
                return null;
            }

            int beginIndex = ExtractBeginPosition(str, begin);
            if (beginIndex >= str.Length)
            {
                return null;
            }

            int endIndex = ExtractEndPosition(str, beginIndex);
            return new SignSourceData()
            {
                SourceData = str.Substring(beginIndex, endIndex - beginIndex),
                BeginIndex = beginIndex,
                EndIndex = endIndex
            };
        }

        private static int ExtractBeginPosition(String responseString, int begin)
        {
            int beginPosition = begin;
            //找到第一个左大括号（对应响应的是JSON对象的情况：普通调用OpenAPI响应明文）
            //或者双引号（对应响应的是JSON字符串的情况：加密调用OpenAPI响应Base64串），作为待验签内容的起点
            while (beginPosition < responseString.Length
                    && responseString[beginPosition] != '{'
                    && responseString[beginPosition] != '"')
            {
                ++beginPosition;
            }
            return beginPosition;
        }

        private static int ExtractEndPosition(String responseString, int beginPosition)
        {
            //提取明文验签内容终点
            if (responseString[beginPosition] == '{')
            {
                return ExtractJsonObjectEndPosition(responseString, beginPosition);
            }
            //提取密文验签内容终点
            else
            {
                return ExtractJsonBase64ValueEndPosition(responseString, beginPosition);
            }
        }

        private static int ExtractJsonBase64ValueEndPosition(String responseString, int beginPosition)
        {
            for (int index = beginPosition; index < responseString.Length; ++index)
            {
                //找到第2个双引号作为终点，由于中间全部是Base64编码的密文，所以不会有干扰的特殊字符
                if (responseString[index] == '"' && index != beginPosition)
                {
                    return index + 1;
                }
            }
            //如果没有找到第2个双引号，说明验签内容片段提取失败，直接尝试选取剩余整个响应字符串进行验签
            return responseString.Length;
        }

        private static int ExtractJsonObjectEndPosition(String responseString, int beginPosition)
        {
            //记录当前尚未发现配对闭合的大括号
            LinkedList<String> braces = new LinkedList<String>();
            //记录当前字符是否在双引号中
            bool inQuotes = false;
            //记录当前字符前面连续的转义字符个数
            int consecutiveEscapeCount = 0;
            //从待验签字符的起点开始遍历后续字符串，找出待验签字符串的终止点，终点即是与起点{配对的}
            for (int index = beginPosition; index < responseString.Length; ++index)
            {
                //提取当前字符
                char currentChar = responseString[index];

                //如果当前字符是"且前面有偶数个转义标记（0也是偶数）
                if (currentChar == '"' && consecutiveEscapeCount % 2 == 0)
                {
                    //是否在引号中的状态取反
                    inQuotes = !inQuotes;
                }
                //如果当前字符是{且不在引号中
                else if (currentChar == '{' && !inQuotes)
                {
                    //将该{加入未闭合括号中
                    braces.AddLast("{");
                }
                //如果当前字符是}且不在引号中
                else if (currentChar == '}' && !inQuotes)
                {
                    //弹出一个未闭合括号
                    braces.RemoveLast();
                    //如果弹出后，未闭合括号为空，说明已经找到终点
                    if (braces.Count == 0)
                    {
                        return index + 1;
                    }
                }

                //如果当前字符是转义字符
                if (currentChar == '\\')
                {
                    //连续转义字符个数+1
                    ++consecutiveEscapeCount;
                }
                else
                {
                    //连续转义字符个数置0
                    consecutiveEscapeCount = 0;
                }
            }

            //如果没有找到配对的闭合括号，说明验签内容片段提取失败，直接尝试选取剩余整个响应字符串进行验签
            return responseString.Length;
        }

        /// <summary>
        /// 获取公钥证书序列号
        /// </summary>
        /// <param name="certPath">公钥证书路径</param>
        /// <returns>公钥证书序列号</returns>
        public static String GetCertSN(String certPath)
        {
            X509Certificate cert = AntCertificationUtil.ParseCert(File.ReadAllText(certPath));
            return AntCertificationUtil.GetCertSN(cert);
        }
    }
}
