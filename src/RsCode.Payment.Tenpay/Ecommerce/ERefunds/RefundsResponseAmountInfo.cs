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
    /// <summary>
    /// 退款响应的订单金额信息
    /// </summary>
    public  class RefundsResponseAmountInfo
    {
        /// <summary>
        /// 退款金额
        /// </summary>
        [JsonPropertyName("refund")]
        public int Refund { get; set; }
        /// <summary>
        /// 用户退款金额
        /// </summary>
        [JsonPropertyName("payer_refund")]
        public int PayerRefund { get; set; }

        /// <summary>
        /// 优惠退款金额
        /// </summary>
        [JsonPropertyName("discount_refund")]
        public int DiscountRefund { get; set; }
        /// <summary>
        /// 退款币种
        /// </summary>
        [MinLength(1)]
        [MaxLength(18)]
        [JsonPropertyName("currency")]
        public string Currency { get; set; }
    }
}
