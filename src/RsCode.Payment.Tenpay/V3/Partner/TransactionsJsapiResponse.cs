using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Partner
{
    public class TransactionsJsapiResponse:TenpayBaseResponse
    {
        [JsonPropertyName("prepay_id")]
        public string PrepayId { get; set; }
    }
}
