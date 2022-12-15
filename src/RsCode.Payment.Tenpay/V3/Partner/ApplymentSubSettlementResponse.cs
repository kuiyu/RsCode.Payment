using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Partner
{
    /// <summary>
    /// 查询结算账户返回的结果
    /// </summary>
    public class ApplymentSubSettlementResponse:TenpayBaseResponse
    {
        /// <summary>
        ///  账户类型
        /// </summary>
        [JsonPropertyName("account_type")]
        public string AccountType { get; set; }

        /// <summary>
        ///  开户银行
        /// </summary>
        [JsonPropertyName("account_bank")]
        public string AccountBank { get; set; }
        /// <summary>
        ///  开户银行全称（含支行]
        /// </summary>
        [JsonPropertyName("bank_name")]
        public string BankName { get; set; }
        /// <summary>
        ///  开户银行联行号
        /// </summary>
        [JsonPropertyName("bank_branch_id")]
        public string BankBranchId { get; set; }
        /// <summary>
        ///  银行账号
        /// </summary>
        [JsonPropertyName("account_number")]
        public string AccountNumber { get; set; }
        /// <summary>
        ///  汇款验证结果
        /// </summary>
        [JsonPropertyName("verify_result")]
        public string VerifyResult { get; set; }
    }
}
