/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.ECommerce.Profitsharing
{
    public class ProfitSharingReceiverDeleteResponse
    {
        
        /// <summary>
        /// 接收方类型
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("type")]
        public string ReceiverType { get; set; }


        /// <summary>
        /// 接收方账号
        /// </summary> 
        [MinLength(1)]
        [MaxLength(64)]
        [JsonPropertyName("account")]
        public string Account { get; set; }
 
    }
}
