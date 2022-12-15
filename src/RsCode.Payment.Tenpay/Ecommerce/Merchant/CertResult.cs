using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.Ecommerce.Merchant
{
    public class CertResult
    {
        [JsonPropertyName("data")]
        public List<CertInfo> CertInfos { get; set; }
        
    }
    public class CertInfo
        {
            [JsonPropertyName("serial_no")]
            public string SerialNo { get; set; }

            [JsonPropertyName("encrypt_certificate")]
            public string EncryptCertificate { get; set; }
        }
}
