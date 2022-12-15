using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.ECommerce.Merchant
{
    /// <summary>
    /// 汇款账户验证信息
    /// </summary>
    public class AccountValidationInfo
    {
        /// <summary>
        /// 付款户名
        /// </summary> 
        [JsonPropertyName("account_name")]
        public long AccountName { get; set; }

        /// <summary>
        /// 付款卡号
        /// </summary>
        [JsonPropertyName("account_no")]
        public string AccountNo { get; set; }

        /// <summary>
        /// 汇款金额
        /// </summary>
        [JsonPropertyName("pay_amount")]
        public string PayAmount { get; set; }

        /// <summary>
        /// 收款卡号
        /// </summary>
        [JsonPropertyName("destination_account_number")]
        public string DestinationAccountNumber { get; set; }


        /// <summary>
        /// 收款户名
        /// </summary>
        [JsonPropertyName("destination_account_name")]
        public string DestinationAccountName { get; set; }


        /// <summary>
        /// 开户银行
        /// </summary>
        [JsonPropertyName("destination_account_bank")]
        public string DestinationAccountBank { get; set; }


        /// <summary>
        /// 省市信息
        /// </summary>
        [JsonPropertyName("city")]
        public string City { get; set; }

        /// <summary>
        /// 备注信息
        /// </summary>
        [JsonPropertyName("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 汇款截止时间
        /// </summary>
        [JsonPropertyName("deadline")]
        public string Deadline { get; set; }
         
    }
}
