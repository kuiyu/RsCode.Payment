/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.ECommerce.Withdraw
{
    public  class SubMchWithdrawResponse
    {
        /// <summary>
        /// 电商平台二级商户号，由微信支付生成并下发。
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("sub_mchid")]
        public string SubMchId { get; set; }

        /// <summary>
        /// 微信支付提现单号
        /// 电商平台提交二级商户提现申请后，由微信支付返回的申请单号，作为查询申请状态的唯一标识
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(128)]
        [JsonPropertyName("withdraw_id")]
        public string WithdrawId { get; set; }

        /// <summary>
        /// 商户提现单号 必须是字母数字
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("out_request_no")]
        public string OutRequestNo { get; set; } 
         
    }
}
