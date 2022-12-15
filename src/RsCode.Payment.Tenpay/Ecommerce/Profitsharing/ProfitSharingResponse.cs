/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.ECommerce.Profitsharing
{
    /// <summary>
    /// 请求分账的响应
    /// </summary>
    public class ProfitSharingResponse
    {
        /// <summary>
        /// 分账出资的电商平台二级商户，填写微信支付分配的商户号
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("sub_mchid")]
        public string SubMchId { get; set; }

        /// <summary>
        /// 微信订单号
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(64)]
        [JsonPropertyName("transaction_id")]
        public string TransactionId { get; set; }

        /// <summary>
        /// 商户分账单号
        /// </summary> 
        [MinLength(1)]
        [MaxLength(64)]
        [JsonPropertyName("out_order_no")]
        public string OutOrderNo { get; set; }

        /// <summary>
        /// 微信分账单号
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(64)]
        [JsonPropertyName("order_id")]
        public string Description { get; set; }

    }
}
