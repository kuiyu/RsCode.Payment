﻿/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay
{

    /// <summary>
    /// 详细错误码
    /// </summary>
    public class ErrorDetail
    {
        /// <summary>
        /// 指示错误参数的位置。当错误参数位于请求body的JSON时，填写指向参数的JSON Pointer。当错误参数位于请求的url或者querystring时，填写参数的变量名。
        /// </summary>
        [JsonPropertyName("field")] 
        public string Field { get; set; }
        /// <summary>
        /// 错误的值
        /// </summary>
        [JsonPropertyName("value")] 
        public object Value { get; set; }
        /// <summary>
        /// 具体错误原因
        /// </summary>
        [JsonPropertyName("issue")] 
        public string Issue { get; set; }
         
        [JsonPropertyName("location")] 
        public  string Location { get; set; }
    }
}
