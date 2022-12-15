using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Partner
{
    public class MiniProgramInfo
    {
        /// <summary>
        /// 服务商小程序APPID
        /// </summary>
        [JsonPropertyName("mini_program_appid")]
        public string AppId { get; set; }
        /// <summary>
        /// 商家小程序APPID
        /// </summary>
        [JsonPropertyName("mini_program_sub_appid")]
        public string SubAppId { get; set; }
        /// <summary>
        /// 小程序截图
        /// </summary>
        [JsonPropertyName("mini_program_pics")]
        public string[] Pics { get; set; }
    }
}
