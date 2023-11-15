/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Merchant
{
    /// <summary>
    /// 支付场景描述
    /// </summary>
    public class NativateSceneInfo
    {
        /// <summary>
        /// 用户终端IP
        /// 调用微信支付API的机器IP，支持IPv4和IPv6两种格式的IP地址。
        /// </summary>
        [JsonPropertyName("payer_client_ip")] public string PayerClientIp { get; set; }

        /// <summary>
        /// 商户端设备号
        /// </summary>
        [JsonPropertyName("device_id")] public string DeviceId { get; set; } = "";

        /// <summary>
        /// 商户门店信息
        /// </summary>
        [JsonPropertyName("store_info")]
        public StoreInfo StoreInfo { get; set; }
     
    }
}
