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
    public  class RefundsQueryRequest
    {

        /// <summary>
        /// 商户退款单号
        /// 商户系统内部的退款单号，商户系统内部唯一
        /// </summary> 
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("out_refund_no")]
        public string OutRefundNo { get; set; }
        /// <summary>
        /// 微信退款单号
        /// </summary> 
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("refund_id")]
        public string RefundId { get; set; }

        /// <summary>
        ///  微信支付分配给二级商户的商户号
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("sub_mchid")]
        public string SubMchId { get; set; }

         
    }
}
