using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Partner
{
    /// <summary>
    /// 互联网网站场景
    /// </summary>
    public class WebInfo
    {
        /// <summary>
        /// 互联网网站域名
        /// </summary>
        [JsonPropertyName("domain")]
        public string Domain { get; set; }
        /// <summary>
        /// 网站授权函	
        /// </summary>
        [JsonPropertyName("web_authorisation")]
        public string WebAuthorisation { get; set; }
        /// <summary>
        /// 互联网网站对应的商家APPID
        /// </summary>
        [JsonPropertyName("web_appid")]
        public string WebAppId { get; set; }
    }
}
