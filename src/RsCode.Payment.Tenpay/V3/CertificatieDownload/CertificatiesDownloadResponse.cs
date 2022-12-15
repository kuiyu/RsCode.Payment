using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3
{
    public class CertificatiesDownloadResponse:TenpayBaseResponse
    {
        [JsonPropertyName("data")]
        public List<CertificatiesDownInfo> Data { get; set; }
    }
}
