/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */

using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace RsCode.Payment
{
    /// <summary>
    /// authkey
    /// </summary>
    public  class AuthKeyOptions
    {
        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public string id { get; set; }

        [JsonProperty("create_date")]
        [JsonPropertyName("create_date")]
        public string create_date { get; set; }
        [JsonProperty("authkey")]
        [JsonPropertyName("authkey")]
        public string authkey { get; set; }
    }
}
