/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Merchant
{

    public class TransactionH5Response:TenpayBaseResponse
    {
        /// <summary>
        /// 支付跳转链接
        /// </summary>
        [JsonPropertyName("h5_url")]
        public string H5Url { get; set; }

        [JsonPropertyName("status_code")]
        public int StatusCode { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("detail")]
        public object Detail { get; set; }
    }
}
