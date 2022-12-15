using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.ECommerce.ECombine
{
    /// <summary>
    /// 	结算信息
    /// </summary>
    public class SettleInfo
    {
        /// <summary>
        /// 是否指定分账
        /// </summary>
        [JsonPropertyName("profit_sharing")]
        public bool ProfitSharing { get; set; }

        /// <summary>
        /// 补差金额
        /// </summary>
        [JsonPropertyName("subsidy_amount")]
        public long SubsidyAmount { get; set; }
    }
}
