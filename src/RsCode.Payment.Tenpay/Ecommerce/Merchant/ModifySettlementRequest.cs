using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.ECommerce.Merchant
{
    public class ModifySettlementRequest
    {
        /// <summary>
        /// 特约商户号
        /// </summary>
        [Required]
        [MaxLength(10)]
        [JsonPropertyName("sub_mchid")]
        public string SubMchId { get; set; }

        /// <summary>
        /// 账户类型
        /// </summary>
        [Required] 
        [JsonPropertyName("account_type")]
        public string AccountType { get; set; }

        /// <summary>
        /// 开户银行
        /// </summary>
        [Required]
        [MaxLength(128)]
        [JsonPropertyName("account_bank")]
        public string AccountBank { get; set; }

        /// <summary>
        /// 开户银行省市编码
        /// </summary>
        [Required]
        [MaxLength(128)]
        [JsonPropertyName("bank_address_code")]
        public string BankAddressCode { get; set; }

        /// <summary>
        /// 开户银行全称（含支行）
        /// </summary> 
        [MaxLength(128)]
        [JsonPropertyName("bank_name")]
        public string BankName { get; set; }

        /// <summary>
        /// 开户银行联行号	
        /// </summary> 
        [MaxLength(128)]
        [JsonPropertyName("bank_branch_id")]
        public string BankBranchId { get; set; }
        /// <summary>
        /// 银行账号
        /// </summary>
        [Required]
        [MaxLength(128)]
        [JsonPropertyName("account_number")]
        public string AccountNumber { get; set; }


        


    }
}
