/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.ECommerce.ESubsidies
{
    /// <summary>
    /// 取消补差
    /// </summary>
    public class SubsidiesCancelRequest
    {
        /// <summary>
        /// 补差的电商平台二级商户
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("sub_mchid")]
        public string SubMchId { get; set; }
        /// <summary>
        /// 微信退款单号
        /// </summary> 
        [MinLength(1)]
        [MaxLength(64)]
        [JsonPropertyName("refund_id")]

        public string RefundId { get; set; }
        /// <summary>
        /// 微信订单号
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(64)]
        [JsonPropertyName("transaction_id")]
        public string TransactionId { get; set; }
        /// <summary>
        /// 取消补差描述
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(80)]
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
