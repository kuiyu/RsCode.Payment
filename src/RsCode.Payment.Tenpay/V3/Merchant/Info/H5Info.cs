/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Merchant
{
    public class H5Info
    {
        /// <summary>
        /// 场景类型
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// 应用名称
        /// </summary>
        [JsonPropertyName("app_name")]
        public string AppName { get; set; }

        /// <summary>
        /// 网站URL
        /// </summary>
        [JsonPropertyName("app_url")]
        public string AppUrl { get; set; }

        /// <summary>
        /// iOS平台BundleID
        /// </summary>
        [JsonPropertyName("bundle_id")]
        public string BundleId { get; set; }

        /// <summary>
        /// Android平台PackageName
        /// </summary>
        [JsonPropertyName("package_name")]
        public string PackageName { get; set; }
    }
}
