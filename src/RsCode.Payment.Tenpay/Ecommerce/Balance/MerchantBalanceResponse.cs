/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.ECommerce.Balance
{
    public class MerchantBalanceResponse
    {
        /// <summary>
        /// 可用余额（单位：分），此余额可做提现操作
        /// </summary> 
        [JsonPropertyName("available_amount")]
        public long AvailableAmount { get; set; }


        /// <summary>
        /// 不可用余额（单位：分）
        /// </summary> 
        [JsonPropertyName("pending_amount")]
        public int PendingAmount { get; set; }
    }
}
