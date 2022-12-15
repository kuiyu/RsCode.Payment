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
    /// <summary>
    /// 商家转帐响应
    /// </summary>
    public class TransfersResponse:TenpayBaseResponse
    {
        /// <summary>
        /// 商家批次单号 
        /// </summary>
        [JsonPropertyName("out_batch_no")] public string OutBatchNo { get; set; }
        /// <summary>
        /// 微信批次单号
        /// </summary>
        [JsonPropertyName("batch_id")] public string BatchId { get; set; }
        /// <summary>
        /// 批次创建时间
        /// 批次受理成功时返回，遵循rfc3339标准格式，格式为yyyy-MM-DDTHH:mm:ss.sss+TIMEZONE，yyyy-MM-DD表示年月日，T出现在字符串中，表示time元素的开头，HH:mm:ss.sss表示时分秒毫秒，TIMEZONE表示时区（+08:00表示东八区时间，领先UTC 8小时，即北京时间）。例如：2015-05-20T13:29:35.120+08:00表示北京时间2015年05月20日13点29分35秒
        /// </summary>
        [JsonPropertyName("create_time")] public string CreateTime { get; set; }

         
    }
}
