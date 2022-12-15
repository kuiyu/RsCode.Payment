/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.ECommerce.ERefunds
{
    public class NotifyAmountInfo 
    {
        /// <summary>
        /// 原订单金额
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; }
        /// <summary>
        /// 退款金额
        /// </summary>
        [JsonPropertyName("refund")]
        public int Refund { get; set; }

        /// <summary>
        /// 用户支付金额
        /// </summary>
        [JsonPropertyName("payer_total")]
        public int PayerTotal { get; set; }

        /// <summary>
        /// 用户退款金额
        /// 退款给用户的金额，不包含所有优惠券金额
        /// </summary>
        [JsonPropertyName("payer_refund")]
        public int PayerRefund { get; set; }
 

    }
}
