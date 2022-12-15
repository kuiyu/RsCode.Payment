using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.ECommerce.ESubsidies
{
    /// <summary>
    /// 取消补差响应结果
    /// </summary>
    public class SubsidiesCancelResponse
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
        /// 取消补差结果，枚举值：SUCCESS：成功  FAIL：失败
        /// </summary>
        [MinLength(1)]
        [MaxLength(16)]
        [JsonPropertyName("result")]
        public string Result { get; set; }

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
