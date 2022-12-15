using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Partner
{
    /// <summary>
    /// 支付者
    /// </summary>
    public class PayerInfo
    {
        /// <summary>
        /// 用户在服务商appid下的唯一标识。
        /// </summary>
        [JsonPropertyName("sp_openid")]public string SpOpenId { get; set; }
        /// <summary>
        /// 用户在子商户appid下的唯一标识。 如果传入sub_openid，则sub_appid必传
        /// </summary>
        [JsonPropertyName("sub_openid")] public string SubOpenId { get; set; }
    }
}
