using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Partner
{
   public class AppInfo
    {
        /// <summary>
        /// 服务商应用APPID
        /// </summary>
        [JsonPropertyName("app_appid")]
        public string AppId { get; set; }
        /// <summary>
        /// 商家应用APPID
        /// </summary>
        [JsonPropertyName("app_sub_appid")]
        public string SubAppId { get; set; }
        /// <summary>
        /// APP截图
        /// </summary>

        [JsonPropertyName("app_pics")]
        public string[] Pics { get; set; }
    }
}
