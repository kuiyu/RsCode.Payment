using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Partner
{
    /// <summary>
    /// 结算银行账户
    /// </summary>
    public class BankAccountInfo
    {
        /// <summary>
        /// 账户类型
        /// </summary>
        [JsonPropertyName("bank_account_type")]
        public string BankAccountType { get; set; }
        /// <summary>
        /// 开户名称
        /// </summary>
        [JsonPropertyName("account_name")]
        public string AccountName { get; set; }
        /// <summary>
        /// 开户银行	
        /// </summary>
        [JsonPropertyName("account_bank")]
        public string AccountBank { get; set; }
        /// <summary>
        /// 开户银行省市编码
        /// </summary>
        [JsonPropertyName("bank_address_code")]
        public string BankAddressCode { get; set; }
        /// <summary>
        /// 开户银行联行号
        /// </summary>
        [JsonPropertyName("bank_branch_id")]
        public string BankBranchId { get; set; }
        /// <summary>
        /// 开户银行全称（含支行]
        /// </summary>
        [JsonPropertyName("bank_name")]
        public string BankName { get; set; }
        /// <summary>
        /// 银行账号
        /// </summary>
        [JsonPropertyName("account_number")]
        public string AccountNumber { get; set; }
    }
}
