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
    public class SubMchWithdrawRequest
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
        /// 商户提现单号 必须是字母数字
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("out_request_no")]
        public string OutRequestNo { get; set; }



        /// <summary>
        /// 提现金额（单位：分）
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(64)]
        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(56)]
        [JsonPropertyName("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 银行附言
        /// 展示在收款银行系统中的附言，数字、字母最长32个汉字（能否成功展示依赖银行系统支持）。
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("bank_memo")]
        public string BankMemo { get; set; }
    }
}
