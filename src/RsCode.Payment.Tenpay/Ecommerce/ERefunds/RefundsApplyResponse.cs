/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.ECommerce.ERefunds
{
    public  class RefundsApplyResponse
    {
        /// <summary>
        /// 微信退款单号
        /// </summary> 
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("refund_id")]
        public string SubAppId { get; set; }

        /// <summary>
        /// 商户退款单号
        /// </summary> 
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("out_refund_no")]
        public string TransactionId { get; set; }

        /// <summary>
        /// 退款创建时间
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("create_time")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 订单金额信息
        /// </summary>
        [JsonPropertyName("amount")]
        public RefundsResponseAmountInfo Amount { get; set; }

        /// <summary>
        /// 优惠退款功能信息
        /// </summary> 
        [JsonPropertyName("promotion_detail")]
        public PromotionDetailInfo[] PromotionDetail { get; set; }

    }
}
