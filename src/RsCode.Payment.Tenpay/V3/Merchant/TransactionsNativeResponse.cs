using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Merchant
{
    /// <summary>
    /// Native下单返回信息
    /// </summary>
    public class TransactionsNativeResponse:TenpayBaseResponse
    {
       
        [JsonPropertyName("code_url")]
        public string CodeUrl { get; set; }
    }
}
