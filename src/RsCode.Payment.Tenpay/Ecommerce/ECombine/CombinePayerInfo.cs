using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.ECommerce.ECombine
{
    /// <summary>
    /// 支付者信息
    /// </summary>
    public class CombinePayerInfo
    {
        /// <summary>
        /// 使用合单appid获取的对应用户openid。是用户在商户appid下的唯一标识。
        /// </summary>
        [JsonPropertyName("openid")]
        public string OpenId { get; set; }
    }
}
