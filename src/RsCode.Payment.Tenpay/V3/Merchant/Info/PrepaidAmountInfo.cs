using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Merchant
{
    /// <summary>
    /// 预支付额度
    /// </summary>
    public class PrepaidAmountInfo
    {
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


    }
}
