using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.Media
{
    public class MetaInfo
    {
        [JsonPropertyName("filename")]
        public string FileName { get; set; }
        [JsonPropertyName("sha256")]
        public string Sha256 { get; set; }
    }
}
