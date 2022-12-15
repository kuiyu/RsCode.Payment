using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Partner
{
    /// <summary>
    /// 修改结算帐号API
    /// https://pay.weixin.qq.com/wiki/doc/apiv3/wxpay/tool/applyment4sub/chapter3_3.shtml
    /// </summary>
    public class ApplymentSubModifySettlementRequest:TenpayBaseRequest
    {
        /// <summary>
        ///  特约商户号
        /// </summary>
        [JsonPropertyName("sub_mchid")]
        public string SubMchId { get; set; }
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
        ///  开户银行省市编码
        /// </summary>
        [JsonPropertyName("bank_address_code")]
        public string BankAddressCode { get; set; }
        /// <summary>
        ///  开户银行全称（含支行）
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

        public string GetApiUrl()
        {
            return "https://api.mch.weixin.qq.com/v3/apply4sub/sub_merchants/{sub_mchid}/modify-settlement";
        }
        public string RequestMethod()
        {
            return "POST";
        }
    }
}
