/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.ECommerce.ERefunds
{
    public class AmountInfo
    {
        /// <summary>
        /// 退款金额
        /// </summary>
        [JsonPropertyName("refund")]
        public int Refund { get; set; }
        /// <summary>
        /// 原订单金额
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; }
        /// <summary>
        /// 退款币种
        /// </summary>
        [MinLength(1)]
        [MaxLength(18)]
        [JsonPropertyName("currency")]
        public string Currency { get; set; }
        
    }
}
