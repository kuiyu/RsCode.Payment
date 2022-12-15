using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace RsCode.Payment
{
    /// <summary>
    /// authkey
    /// </summary>
    public  class AuthKeyOptions
    {
        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public string id { get; set; }

        [JsonProperty("create_date")]
        [JsonPropertyName("create_date")]
        public string create_date { get; set; }
        [JsonProperty("authkey")]
        [JsonPropertyName("authkey")]
        public string authkey { get; set; }
    }
}
