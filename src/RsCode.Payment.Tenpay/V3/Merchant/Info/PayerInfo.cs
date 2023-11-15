/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Merchant
{
    /// <summary>
    /// 支付者
    /// </summary>
    public class PayerInfo
    {
        /// <summary>
        /// 用户在直连商户appid下的唯一标识。
        /// </summary>
        [JsonPropertyName("openid")]public string SpOpenId { get; set; }
       
    }
}
