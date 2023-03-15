/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Merchant.Info
{
    /// <summary>
    /// 退款通知中的金额信息
    /// </summary>
    public class RefundNotifyAmount
    {
        /// <summary>
        /// 订单总金额，单位为分，只能为整数
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; }
        /// <summary>
        /// 退款金额，币种的最小单位，只能为整数，不能超过原订单支付金额，如果有使用券，后台会按比例退。
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
        /// </summary>
        [JsonPropertyName("payer_refund")]
        public int PayerRefund { get; set; }
        
    }
}
