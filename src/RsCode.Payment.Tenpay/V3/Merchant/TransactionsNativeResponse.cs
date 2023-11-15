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
    /// Native下单返回信息
    /// </summary>
    public class TransactionsNativeResponse:TenpayBaseResponse
    {
       
        [JsonPropertyName("code_url")]
        public string CodeUrl { get; set; }
    }
}
