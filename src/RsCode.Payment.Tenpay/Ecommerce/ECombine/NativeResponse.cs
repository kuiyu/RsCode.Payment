using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.ECommerce.ECombine
{
   public class NativeResponse : AppRequest
    {
        /// <summary>
        /// 预支付交易会话标识
        /// </summary>
        [JsonPropertyName("prepay_id")]
        public string PrepayId { get; set; }
    }
}
