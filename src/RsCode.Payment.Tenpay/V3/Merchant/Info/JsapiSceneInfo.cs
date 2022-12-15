using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Merchant
{
    /// <summary>
    /// jsapi支付场景描述
    /// </summary>
    public class JsapiSceneInfo
    {
        /// <summary>
        /// 用户终端IP
        /// 调用微信支付API的机器IP，支持IPv4和IPv6两种格式的IP地址。
        /// </summary>
        [JsonPropertyName("payer_client_ip")] public string PayerClientIp { get; set; }

        /// <summary>
        /// 商户端设备号
        /// </summary>
        [JsonPropertyName("device_id")] public string DeviceId { get; set; }

        /// <summary>
        /// 商户门店信息
        /// </summary>
        [JsonPropertyName("store_info")]
        public StoreInfo StoreInfo { get; set; }
       
    }
}
