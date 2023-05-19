using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Merchant
{
    /// <summary>
    /// 结算信息
    /// </summary>
    public class SettleInfo
    {
        [JsonPropertyName("profit_sharing")]
        public bool ProfitSharing { get; set; }
    }
}
