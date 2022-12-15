using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Merchant
{
    /// <summary>
    /// 支付者
    /// </summary>
    public class PayerInfo
    {
        /// <summary>
        /// 用户在直连商户appid下的唯一标识。
        /// </summary>
        [JsonPropertyName("openid")]public string SpOpenId { get; set; }
       
    }
}
