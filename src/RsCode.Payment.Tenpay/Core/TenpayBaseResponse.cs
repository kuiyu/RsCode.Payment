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
