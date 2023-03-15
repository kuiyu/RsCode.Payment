/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using RsCode.Payment.Tenpay.V3.Merchant.Info;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Merchant
{
    /// <summary>
    /// 订单金额信息
    /// </summary>
    public class RefundAmountRequestInfo
    {
        /// <summary>
        /// 退款单金额信息
        /// </summary>
        /// <param name="refundAmount">退款额度( 元)</param>
        /// <param name="totalAmount">订单总额</param>
        /// <param name="fromInfo">退款出资账户及金额</param>
        /// <param name="currency">退款币种</param>
        public RefundAmountRequestInfo(decimal refundAmount,decimal totalAmount, RefundFromInfo[] fromInfo=null, string currency="CNY")
        {
            Refund = TenpayTool.Price(refundAmount);
            Total = TenpayTool.Price(totalAmount);
            From = fromInfo;
            Currency = currency;
        }
        /// <summary>
        /// 退款金额，单位为分，只能为整数，不能超过原订单支付金额。
        /// </summary>
        [JsonPropertyName("refund")]
        public int Refund { get; set; }
        /// <summary>
        /// 退款出资账户及金额
        /// </summary>
        [JsonPropertyName("from")]
        public RefundFromInfo[] From { get; set; }
        /// <summary>
        /// 原订单金额
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; }
        /// <summary>
        /// 退款币种 CNY：人民币，境内商户号仅支持人民币
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; } = "CNY";

    }
}
