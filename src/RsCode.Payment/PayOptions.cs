/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.InteropServices;
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
        /// 微信支付APIKey
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


        string privateKey = "";
        /// <summary>
        /// 私钥证书
        /// cert开头时为证书路径 否则是私书内容
        /// </summary>
        [JsonProperty("PrivateKey")]
        [JsonPropertyName("PrivateKey")]
        public string PrivateKey { 
            get {
                if (privateKey.StartsWith("cert")&& RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    privateKey = privateKey.Replace("/", "\\");
                }
                return privateKey;
            } set {
                privateKey = value;
            } }
        /// <summary>
        /// 商户私钥证书密码
        /// </summary>
        [JsonProperty("CertPassword")]
        [JsonPropertyName("CertPassword")]
        public string CertPassword { get; set; } = "";

        string publicKey = "";
        /// <summary>
        /// 公钥证书路径
        /// </summary>
        [JsonProperty("PublicKey")]
        [JsonPropertyName("PublicKey")]
        public string PublicKey { 
            get {
                if (publicKey.StartsWith("cert")&& RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    publicKey = publicKey.Replace("/", "\\");
                }
                    return publicKey;
            } set {
                publicKey = value;
            } }


        /// <summary>
        /// 平台根证书路径
        /// </summary>
        [JsonProperty("PlatformRootCert")]
        [JsonPropertyName("PlatformRootCert")]
        public string PlatformRootCert { get; set; }

        /// <summary>
        /// 平台公钥
        /// </summary>
        [JsonProperty("PlatformPublicKey")]
        [JsonPropertyName("PlatformPublicKey")]
        public string PlatformPublicKey { get; set; }

        
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

        
    }
}
