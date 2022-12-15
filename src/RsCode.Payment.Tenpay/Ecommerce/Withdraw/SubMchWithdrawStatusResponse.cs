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
    public class SubMchWithdrawStatusResponse
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
        /// 提现单状态
        /// 提现状态，枚举值：
        ///CREATE_SUCCESS：受理成功
        ///SUCCESS：提现成功
        ///FAIL：提现失败
        ///REFUND：提现退票
        ///CLOSE：关单
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// 微信支付提现单号
        /// 电商平台提交二级商户提现申请后，由微信支付返回的申请单号，作为查询申请状态的唯一标识
        /// </summary> 
        [MinLength(1)]
        [MaxLength(128)]
        [JsonPropertyName("withdraw_id")]
        public string WithdrawId { get; set; }

        /// <summary>
        /// 商户提现单号 必须是字母数字
        /// </summary> 
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("out_request_no")]
        public string OutRequestNo { get; set; }


        /// <summary>
        /// 提现金额（单位：分）
        /// </summary>
        [Required] 
        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// 发起提现时间
        /// </summary> 
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("create_time")]
        public string CreateTime { get; set; }

        /// <summary>
        /// 提现状态更新时间
        /// </summary>
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("update_time")]
        public string UpdateTime { get; set; }

        /// <summary>
        /// 失败原因
        /// </summary>
        [MinLength(1)]
        [MaxLength(255)]
        [JsonPropertyName("reason")]
        public string Reason { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(255)]
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
