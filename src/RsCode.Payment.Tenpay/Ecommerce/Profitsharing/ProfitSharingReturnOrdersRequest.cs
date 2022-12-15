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
    /// 请求分账回退
    /// </summary>
    public class ProfitSharingReturnOrdersRequest
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
        /// 微信分账单号
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(64)]
        [JsonPropertyName("order_id")]
        public string OrderId { get; set; }


        /// <summary>
        /// 商户系统内部的分账单号，在商户系统内部唯一（单次分账、多次分账、完结分账应使用不同的商户分账单号），同一分账单号多次请求等同一次。
        /// </summary> 
        [MinLength(1)]
        [MaxLength(64)]
        [JsonPropertyName("out_order_no")]
        public string OutOrderNo { get; set; }

        /// <summary>
        /// 商户回退单号	
        /// </summary> 
        [MinLength(1)]
        [MaxLength(64)]
        [JsonPropertyName("out_return_no")]
        public string OutReturnNo { get; set; }

        /// <summary>
        /// 回退商户号,只能对原分账请求中成功分给商户接收方进行回退
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("return_mchid")]
        public string ReturnMchId { get; set; }




        /// <summary>
        /// 需要从分账接收方回退的金额，单位为分
        /// </summary>
        [Required]
        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// 分账回退的原因描述
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(80)]
        [JsonPropertyName("description")]
        public string Description { get; set; }

       
    }
}
