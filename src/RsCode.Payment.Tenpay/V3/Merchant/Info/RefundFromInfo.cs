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
    /// 退款出资账户及金额
    /// </summary>
    public  class RefundFromInfo
    {
        /// <summary>
        /// 出资账户类型	
        /// 枚举值： AVAILABLE : 可用余额   UNAVAILABLE : 不可用余额
        /// </summary>
        [JsonPropertyName("account")]
        public string Account { get; set; } 
        /// <summary>
        /// 出资金额
        /// </summary>
        [JsonPropertyName("amount")]public int Amount { get; set; }
    }
}
