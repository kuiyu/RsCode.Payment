using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.Ecommerce.Merchant
{
    public class CertExceptionResult
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
