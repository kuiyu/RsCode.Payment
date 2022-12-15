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
    public class MerchantEndDayBalanceRequest
    {
        /// <summary>
        /// 账户类型
        /// 枚举值：BASIC：基本账户   OPERATION：运营账户  FEES：手续费账户
        /// </summary>
        [MinLength(1)]
        [MaxLength(16)]
        [JsonPropertyName("account_type")]
        public string AccountType { get; set; }

        /// <summary>
        /// 指定查询商户日终余额的日期
        /// 示例值：2019-08-17
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(10)]
        [JsonPropertyName("date")]
        public string Date { get; set; }
    }
}
