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
    /// 查询分账回退结果
    /// </summary>
    public class ProfitSharingReturnOrdersQueryRequest
    {
        /// <summary>
        /// 分账回退的接收商户，对应原分账出资的电商平台二级商户，填写微信支付分配的商户号
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
        /// 原发起分账请求时使用的商户系统内部的分账单号单号多次请求等同一次。
        /// </summary> 
        [MinLength(1)]
        [MaxLength(64)]
        [JsonPropertyName("out_order_no")]
        public string OutOrderNo { get; set; }

        /// <summary>
        /// 商户回退单号 此回退单号是商户在自己后台生成的一个新的回退单号，在商户后台唯一 	
        /// </summary> 
        [MinLength(1)]
        [MaxLength(64)]
        [JsonPropertyName("out_return_no")]
        public string OutReturnNo { get; set; }

     
    }
}
