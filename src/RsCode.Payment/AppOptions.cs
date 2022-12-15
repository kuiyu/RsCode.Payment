
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace RsCode.Payment
{
    /// <summary>
    /// 应用配置
    /// </summary>
    public class AppOptions
    {
        /// <summary>
        /// 应用Id
        /// </summary>
        [JsonProperty("ClientId")]
        [JsonPropertyName("ClientId")]
        public string ClientId { get; set; }

        /// <summary>
        /// 第三方支付分配的应用Id
        /// </summary>
        [JsonProperty("AppId")]
        [JsonPropertyName("AppId")] 
        public string AppId { get; set; }

        /// <summary>
        /// 支付场景
        /// </summary>
        [JsonProperty("PaymentScene")]
        [JsonPropertyName("PaymentScene")]
        public PaymentScene PaymentScene { get; set; }

       
        /// <summary>
        /// 分配的商户号
        /// </summary> 
        [JsonProperty("MchId")]
        [JsonPropertyName("MchId")] 
        public string MchId { get; set; }

        

      

       
    }
}
