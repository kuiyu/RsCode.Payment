using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Merchant
{
    public  class TransactionsResponse:TenpayBaseResponse
    {
        /// <summary>
        /// 此URL用于生成支付二维码，然后提供给用户扫码支付。
        ///注意：code_url并非固定值，使用时按照URL格式转成二维码即可
        /// </summary>
        [JsonPropertyName("code_url")]
        public string CodeUrl { get; set; }

        /// <summary>
        /// 预支付交易会话标识。用于后续接口调用中使用，该值有效期为2小时
        /// </summary>
        [JsonPropertyName("prepay_id")]
        public string PrepayId { get; set; }
    }
}
