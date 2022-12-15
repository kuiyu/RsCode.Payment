/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 协议:MIT License 2.0 
 * 作者:河南软商网络科技有限公司 
 * 项目己托管于  
 * github
   https://github.com/kuiyu/RsCode.Payment.git
 */
using Microsoft.AspNetCore.Http;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using RsCode.Payment.Util;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Serialization;

namespace RsCode.Payment.Tenpay
{
    public class TenpayTool
    {
        /// <summary>
        /// 生成随机数
        /// </summary>
        /// <returns></returns>
        public static string GetNonceStr()
        {
            var randomGenerator = new RandomGenerator();
            return randomGenerator.GetRandomUInt().ToString();
        }
        /// <summary>
        /// 生成时间戳，标准北京时间，时区为东八区，自1970年1月1日 0点0分0秒以来的秒数
        /// </summary>
        /// <returns></returns>
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        /// 计算文件的 SHA256 值
        /// </summary>
        /// <param name="fileName">要计算 SHA256 值的文件名和路径</param>
        /// <returns>SHA256值16进制字符串</returns>
        public static string SHA256File(string fileName)
        {
            return HashFile(fileName, "sha256");
        }

        public static string HashFile(FileStream fs,string algName="sha256")
        {
            using(fs)
            {
                byte[] hashBytes = HashData(fs, algName); 
                return ByteArrayToHexString(hashBytes);
            } 
        }

        /// <summary>
        /// 计算文件的哈希值
        /// </summary>
        /// <param name="fileName">要计算哈希值的文件名和路径</param>
        /// <param name="algName">算法:sha1,md5</param>
        /// <returns>哈希值16进制字符串</returns>
        private static string HashFile(string fileName, string algName)
        {
            if (!System.IO.File.Exists(fileName))
                return string.Empty;

            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            byte[] hashBytes = HashData(fs, algName);
            fs.Close();
            return ByteArrayToHexString(hashBytes);
        }


        /// <summary>
        /// 字节数组转换为16进制表示的字符串
        /// </summary>
        private static string ByteArrayToHexString(byte[] buf)
        {
            string returnStr = "";
            if (buf != null)
            {
                for (int i = 0; i < buf.Length; i++)
                {
                    returnStr += buf[i].ToString("X2");
                }
            }
            return returnStr;
        }


        /// <summary>
        /// 计算哈希值
        /// </summary>
        /// <param name="stream">要计算哈希值的 Stream</param>
        /// <param name="algName">算法:sha1,md5</param>
        /// <returns>哈希值字节数组</returns>
        private static byte[] HashData(Stream stream, string algName)
        {
            HashAlgorithm algorithm;
            if (algName == null)
            {
                throw new ArgumentNullException("algName 不能为 null");
            }
            if (string.Compare(algName, "sha256", true) == 0)
            {
                algorithm = SHA256.Create();
            }
            else
            {
                if (string.Compare(algName, "md5", true) != 0)
                {
                    throw new Exception("algName 只能使用 sha256 或 md5");
                }
                algorithm = System.Security.Cryptography.MD5.Create();
            }
            return algorithm.ComputeHash(stream);
        }

        public static bool IsBase64String(string str)
        {
            try
            {
                  Convert.FromBase64String(str);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        /// <summary>
        /// 使用微信的平台公钥对提交的信息进行加密
        /// 最终提交请求时，需对敏感信息加密，如身份证、银行卡号。
        /// 加密算法是RSA，使用从接口下载到的公钥进行加密，非后台下载到的私钥。 
        /// 
        /// </summary>
        /// <param name="text">要加密的明文</param>
        /// <param name="publicKey"> -----BEGIN CERTIFICATE----- 开头的string，转为bytes </param>
        /// <returns></returns>
        public static string RSAEncrypt(string text, byte[] publicKey)
        {
            using (var x509 = new X509Certificate2(publicKey))
            {
                var rsaParam = x509.GetRSAPublicKey().ExportParameters(false);
                var rsa = new RSACryptoServiceProvider();
                rsa.ImportParameters(rsaParam);
                var buff = rsa.Encrypt(Encoding.UTF8.GetBytes(text), true);
                return  Convert.ToBase64String(buff);
            }
        }


        public static string AesGcmDecrypt(string AES_KEY, string associatedData, string nonce, string ciphertext)
        {
            GcmBlockCipher gcmBlockCipher = new GcmBlockCipher(new AesEngine());
            AeadParameters aeadParameters = new AeadParameters(
                new KeyParameter(Encoding.UTF8.GetBytes(AES_KEY)),
                128,
                Encoding.UTF8.GetBytes(nonce),
                Encoding.UTF8.GetBytes(associatedData));
            gcmBlockCipher.Init(false, aeadParameters);

            byte[] data = Convert.FromBase64String(ciphertext);
            byte[] plaintext = new byte[gcmBlockCipher.GetOutputSize(data.Length)];
            int length = gcmBlockCipher.ProcessBytes(data, 0, data.Length, plaintext, 0);
            gcmBlockCipher.DoFinal(plaintext, length);
            return Encoding.UTF8.GetString(plaintext);
        }


        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="publicKey">-----BEGIN CERTIFICATE----- 开头的string，转为bytes->不需要每次都去</param>
        /// <param name="signedString">私钥加密串-Wechatpay-Signature</param>
        /// <param name="signSourceString">验签名串-应答时间戳\n应答随机串\n应答报文主体\n</param>
        /// <returns></returns>
        public static bool VerifySign(byte[]publicKey,string signedString, string signSourceString)
        {
            using (var x509 = new X509Certificate2(publicKey))
            {
                var rsaParam = x509.GetRSAPublicKey().ExportParameters(false);
                var rsa = new RSACryptoServiceProvider();
                rsa.ImportParameters(rsaParam);

                var sha256 = new SHA256CryptoServiceProvider();
                return rsa.VerifyData(Encoding.UTF8.GetBytes(signSourceString), sha256, Convert.FromBase64String(signedString));
            } 
        }
        /// <summary>
        /// V3数据签名
        /// </summary>
        /// <param name="data"></param>
        /// <param name="rsa">签名的证书</param>
        /// <returns></returns>
        public static string Sign(string data,RSA rsa)
        { 
            byte[] s = System.Text.Encoding.UTF8.GetBytes(data);
            return Convert.ToBase64String(rsa.SignData(s, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1));
        }

        /// <summary>
        /// V3数据签名
        /// </summary>
        /// <param name="data"></param>
        /// <param name="rsa">签名的证书</param>
        /// <returns></returns>
        public static string Sign(string data,PayOptions payOptions)
        {
            X509Certificate2 x509Certificate2 = payOptions.GetPrivateKeyCert();

            var rsa = x509Certificate2.GetRSAPrivateKey();
            byte[] s = System.Text.Encoding.UTF8.GetBytes(data);
            return Convert.ToBase64String(rsa.SignData(s, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1));
        }

        public static int Price(decimal price)
        {
            return Convert.ToInt32(price * 100);
        }

        public static decimal Price(int price)
        {
            return decimal.Round(Convert.ToDecimal(price) / 100, 2); 
        }
        /// <summary>
        /// rfc3339标准格式时间
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ConvertDateTime(DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd'T'HH:mm:ss.fffK");
        }

        /// <summary>
        /// 获取客户端IP
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string GetIp(HttpContext context)
        {
             
            string ip = "0.0.0.0";
            if (context != null)
            {
                ip = context.Request.Headers["X-Forwarded-For"].FirstOrDefault();
                if (string.IsNullOrEmpty(ip))
                {
                    ip = context.Connection.RemoteIpAddress.ToString();
                }
            }

            return ip;
        }

        /// <summary>
        /// 创建xml序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string XmlSerialize<T>(T obj)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                StringWriter writer = new StringWriter(CultureInfo.InvariantCulture);
                serializer.Serialize(writer, obj); 
                string xml = writer.ToString();
                writer.Close();
                writer.Dispose();
                return xml;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        /// <summary>
        /// xml反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T XmlDeserialize<T>(string xml)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (StringReader reader = new StringReader(xml))
                {
                    T res = (T)serializer.Deserialize(reader);
                   reader.Close();
                   reader.Dispose(); 
                    return res;
                } 
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

