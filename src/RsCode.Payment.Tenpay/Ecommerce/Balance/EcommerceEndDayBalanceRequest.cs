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
    /// <summary>
    /// 电商服务商通过该接口可以查询二级商户指定日期当天24点的账户余额。
    /// </summary>
    public class EcommerceEndDayBalanceRequest
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
