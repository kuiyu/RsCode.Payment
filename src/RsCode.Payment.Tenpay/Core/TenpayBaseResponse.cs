/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay
{
    public class TenpayBaseResponse:WxPayData
    {
        /// <summary>
        /// 状态码
        /// </summary>
        [JsonPropertyName("status_code")] 
        public int StatusCode { get; set; } = 200;

        /// <summary>
        /// 详细错误码
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }
        /// <summary>
        /// 错误描述，使用易理解的文字表示错误的原因
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("detail")]
        public ErrorDetail ErrorDetail { get; set; }
        
        
    }
}
