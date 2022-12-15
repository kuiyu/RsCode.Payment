using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.ECommerce.Merchant
{
    public class SettlementResponse
    {
        /// <summary>
        /// 账户类型
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("account_type")]
        public string AccountType { get; set; }

        /// <summary>
        /// 开户银行
        /// 返回特约商户的结算账户-开户银行全称
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(128)]
        [JsonPropertyName("account_bank")]
        public string AccountBank { get; set; }

        /// <summary>
        /// 开户银行全称（含支行]
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(128)]
        [JsonPropertyName("bank_name")]
        public string BankName { get; set; }


        /// <summary>
        /// 开户银行联行号
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(128)]
        [JsonPropertyName("bank_branch_id")]
        public string BankBranchId { get; set; }

        /// <summary>
        /// 银行账号
        /// </summary>
        [MinLength(1)]
        [MaxLength(128)]
        [JsonPropertyName("account_number")]
        public string AccountNumber { get; set; }

        /// <summary>
        /// 汇款验证结果
        /// </summary>
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("verify_result")]
        public string VerifyResult { get; set; }

      
    }
}
