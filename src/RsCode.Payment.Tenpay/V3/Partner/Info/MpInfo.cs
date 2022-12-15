using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Partner
{
    /// <summary>
    /// 公众号场景
    /// </summary>
    public class MpInfo
    {
        /// <summary>
        /// 服务商公众号APPID
        /// </summary>
        [JsonPropertyName("mp_appid")]
        public string AppId { get; set; }
        /// <summary>
        /// 商家公众号APPID
        /// </summary>
        [JsonPropertyName("mp_sub_appid")]
        public string  SubAppId { get; set; }
        /// <summary>
        /// 公众号页面截图
        /// </summary>
        [JsonPropertyName("mp_pics")]
        public string[] Pics { get; set; }
    }
}
