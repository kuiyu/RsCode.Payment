using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Partner
{
    /// <summary>
    /// 经营场景
    /// </summary>
    public class SaleInfo
    {
        /// <summary>
        /// SALES_SCENES_STORE：线下门店
        /// SALES_SCENES_MP：公众号
        /// SALES_SCENES_MINI_PROGRAM：小程序
        /// SALES_SCENES_WEB：互联网
        /// SALES_SCENES_APP：APP
        /// SALES_SCENES_WEWORK：企业微信
        /// </summary>
        [JsonPropertyName("sales_scenes_type")]
        public string[] SalesScenesType { get; set; }
        /// <summary>
        /// 线下门店场景
        /// </summary>
        [JsonPropertyName("biz_store_info")]
        public BizStoreInfo BizStoreInfo { get; set; }
        /// <summary>
        /// 公众号场景
        /// </summary>
        [JsonPropertyName("mp_info")]
        public MpInfo MpInfo { get; set; }
        /// <summary>
        /// 小程序场景
        /// </summary>
        [JsonPropertyName("mini_program_info")]
        public MiniProgramInfo MiniProgramInfo { get; set; }
        /// <summary>
        /// APP场景
        /// </summary>
        [JsonPropertyName("app_info")]
        public AppInfo AppInfo { get; set; }
        /// <summary>
        /// 互联网网站场景
        /// </summary>
        [JsonPropertyName("web_info")]
        public WebInfo WebInfo { get; set; }
        /// <summary>
        /// 企业微信场景
        /// </summary>
        [JsonPropertyName("wework_info")]
        public WeWorkInfo WeWorkInfo { get; set; }
    }
}
