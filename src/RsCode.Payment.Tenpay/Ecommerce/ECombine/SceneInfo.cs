using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.ECommerce.ECombine
{
    /// <summary>
    /// 支付场景信息描述
    /// </summary>
    public class SceneInfo
    {
        /// <summary>
        /// 商户端设备号
        /// </summary>
        [JsonPropertyName("device_id")]
        public string DeviceId { get; set; }

        /// <summary>
        /// 用户终端IP
        /// </summary>
        [Required]
        [JsonPropertyName("payer_client_ip")]
        public string PayerClientIp { get; set; }
    }
}
