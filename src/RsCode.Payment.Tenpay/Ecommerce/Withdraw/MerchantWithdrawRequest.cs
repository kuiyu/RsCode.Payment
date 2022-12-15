/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.ECommerce.Withdraw
{
    /*
     注意：
• 只能在电商平台指定账户的可用余额中进行提现。

• 发起提现后如果微信支付正确返回了微信支付提现单号，查询状态需要隔日早上8点后进行。

• 查询结果可能存在延迟，提现发起后查询无单据并不代表没有发起提现，应以隔日查询结果为准判断单据是否存在。

• 查询结果中状态为INIT时并不代表一定未受理成功，需要等待7日后确定单据最终状态或者原单（所有请求参数保持不变）重入请求。
     */
    /// <summary>
    /// 电商平台通过该接口可将其平台的收入进行提现
    /// </summary>
    public class MerchantWithdrawRequest
    { 
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
        [MinLength(1)]
        [MaxLength(255)]
        [JsonPropertyName("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 银行附言
        /// 展示在收款银行系统中的附言，数字、字母最长32个汉字（能否成功展示依赖银行系统支持）。
        /// </summary> 
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("bank_memo")]
        public string BankMemo { get; set; }

        /// <summary>
        /// 账户类型 枚举值：
        ///BASIC：基本账户
        ///OPERATION：运营账户
        ///FEES：手续费账户
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(16)]
        [JsonPropertyName("account_type")]
        public string AccountType { get; set; }
    }
}
