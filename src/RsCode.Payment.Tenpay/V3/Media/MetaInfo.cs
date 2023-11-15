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

namespace RsCode.Payment.Tenpay.Media
{
    public class MetaInfo
    {
        [JsonPropertyName("filename")]
        public string FileName { get; set; }
        [JsonPropertyName("sha256")]
        public string Sha256 { get; set; }
    }
}
