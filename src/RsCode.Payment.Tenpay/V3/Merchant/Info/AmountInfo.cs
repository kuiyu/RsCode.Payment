using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Merchant
{
    /// <summary>
    /// 订单金额信息
    /// </summary>
    public class AmountInfo
    {
        public AmountInfo()
        {

        }
   
        /// <summary>
        /// 订单总金额，单位为分。
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; }
        /// <summary>
        /// CNY：人民币，境内商户号仅支持人民币
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; } = "CNY";


        /// <summary>
        /// 用户支付金额
        /// </summary>
        [JsonPropertyName("payer_total")]
        public int PayerTotal { get; set; }
        /// <summary>
        /// 用户支付币种
        /// </summary>
        [JsonPropertyName("payer_currency")]
        public string PayerCurrency { get; set; }

    }
}
