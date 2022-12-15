/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.ECommerce.Balance
{
    public class EcommerceBalanceResponse
    {
        /// <summary>
        /// 电商平台二级商户号，由微信支付生成并下发
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("sub_mchid")]
        public string SubMchId { get; set; }


        /// <summary>
        /// 可用余额（单位：分），此余额可做提现操作
        /// </summary> 
        [JsonPropertyName("available_amount")]
        public int AvailableAmount { get; set; }


        /// <summary>
        /// 不可用余额（单位：分）
        /// </summary> 
        [JsonPropertyName("pending_amount")]
        public int PendingAmount { get; set; }
    }
}
