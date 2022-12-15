using Newtonsoft.Json;
using RsCode.Payment.Util;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace RsCode.Payment
{
    public  class PayOptions
    {
        /// <summary>
        /// 支付渠道
        /// </summary>
        [JsonProperty("PaymentChannel")]
        [JsonPropertyName("PaymentChannel")] 
        public PaymentChannel PaymentChannel { get; set; }
        /// <summary>
        /// 商户类型
        /// </summary>
        [Description("商户类型")]
        [JsonProperty("MchType")]
        [JsonPropertyName("MchType")]
        public MchType MchType { get; set; }

        /// <summary>
        /// 支付渠道的状态
        /// </summary>
        [JsonProperty("PaymentStatus")]
        [JsonPropertyName("PaymentStatus")]
        public bool PaymentStatus { get; set; }
       
        /// <summary>
        /// 微信商户号 或支付宝合作id
        ///  </summary> 
        [JsonProperty("MchId")]
        [JsonPropertyName("MchId")] 
        public string MchId { get; set; }
        /// <summary>
        /// 渠道费率
        /// </summary>
        [JsonProperty("Rate")]
        [JsonPropertyName("Rate")]
        public decimal Rate { get; set; } = 0.6m;
        /// <summary>
        /// API密钥
        /// </summary>
        [JsonProperty("APIKey")]
        [JsonPropertyName("APIKey")]
        public string APIKey { get; set; } = "";
        /// <summary>
        /// 微信支付APIKeyV3版
        /// </summary>
       [JsonProperty("APIKeyV3")]
        [JsonPropertyName("APIKeyV3")] 
        public string APIKeyV3 { get; set; } = "";


        string privateKeyPath = "";
        /// <summary>
        /// 私钥证书路径
        /// </summary>
        [JsonProperty("PrivateKeyCertPath")]
        [JsonPropertyName("PrivateKeyCertPath")]
        public string PrivateKeyCertPath { 
            get {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    privateKeyPath = privateKeyPath.Replace("/", "\\");
                }
                return privateKeyPath;
            } set {
                privateKeyPath = value;
            } }
        /// <summary>
        /// 商户私钥证书密码
        /// </summary>
        [JsonProperty("CertPassword")]
        [JsonPropertyName("CertPassword")]
        public string CertPassword { get; set; } = "";

        string publicKeyPath = "";
        
        /// <summary>
        /// 公钥证书路径
        /// </summary>
        [JsonProperty("PublicKeyCertPath")]
        [JsonPropertyName("PublicKeyCertPath")]
        public string PublicKeyCertPath { 
            get {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    privateKeyPath = privateKeyPath.Replace("/", "\\");
                }
                    return publicKeyPath;
            } set {
                publicKeyPath = value;
            } }
 

        /// <summary>
        /// 平台公钥证书文件
        /// </summary>
        [JsonProperty("PlatformPublicKeyCertPath")]
        [JsonPropertyName("PlatformPublicKeyCertPath")]
        public string PlatformPublicKeyCertPath { get; set; }

        /// <summary>
        /// 平台根证书路径
        /// </summary>
        [JsonProperty("PlatformRootCertPath")]
        [JsonPropertyName("PlatformRootCertPath")]
        public string PlatformRootCertPath { get; set; }

        /// <summary>
        /// 支付宝公钥
        /// </summary>
        [JsonProperty("PlatformPublicKey")]
        [JsonPropertyName("PlatformPublicKey")]
        public string PlatformPublicKey { get; set; }

        /// <summary>
        /// 应用的公钥
        /// </summary>
        [JsonProperty("PublicKey")]
        [JsonPropertyName("PublicKey")]
        public string PublicKey { get; set; }
        /// <summary>
        /// 支付结果通知回调url，用于商户接收支付结果
        /// </summary>
        [JsonProperty("NotifyUrl")]
        [JsonPropertyName("NotifyUrl")] 
        public virtual string NotifyUrl { get; set; } = "";

        string gateWay = "";
        [JsonProperty("GateWay")]
        [JsonPropertyName("GateWay")]
        public string GateWay { get { 
              if(PaymentChannel== PaymentChannel.Alipay)
                {
                    gateWay = "https://openapi.alipay.com/gateway.do";
                }
                return gateWay;
            } set {
                gateWay = value;
            }
        }

        public X509Certificate2 GetPublicKeyCert()
        {
            X509Certificate2 certificate = null;
            if (string.IsNullOrWhiteSpace(PublicKeyCertPath))
            {
                throw new Exception("未配置公钥");
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                //windows使用p12证书
                var root = AppContext.BaseDirectory;
                var certPath = Path.Combine(Environment.CurrentDirectory, PublicKeyCertPath);
                byte[] publicKey = File.ReadAllBytes(certPath); //从平台接口下载到的公钥
                certificate = new X509Certificate2(certPath);
            }
            else
            { 
                var certPath = Path.Combine(Environment.CurrentDirectory, PublicKeyCertPath);
                byte[] publicKey = File.ReadAllBytes(certPath); //从平台接口下载到的公钥
                certificate = new X509Certificate2(certPath);
            }


            return certificate;
        }
        public X509Certificate2 GetPrivateKeyCert()
        {
            if (string.IsNullOrWhiteSpace(PrivateKeyCertPath))
            {
                throw new Exception("未配置证书");
            }
            var cert=Path.Combine(Environment.CurrentDirectory, PrivateKeyCertPath); 

            X509Certificate2 certificate = File.Exists(cert) ? new X509Certificate2(cert, CertPassword)
                : RSAUtilities.IsBase64String(cert) ? new X509Certificate2(Convert.FromBase64String(cert), CertPassword)
                :throw new Exception("证书配置有误"); 

            return certificate;
        }

        /// <summary>
        /// 获取私有证书序列号
        /// </summary>
        /// <returns></returns>
        public string GetCertSerialNo()
        {
            var cert = GetPrivateKeyCert();
            return cert.GetSerialNumberString();
        }
    }
}
