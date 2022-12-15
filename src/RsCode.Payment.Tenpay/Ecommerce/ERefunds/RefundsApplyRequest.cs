/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using RsCode.Payment.Tenpay.ECommerce.Merchant;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.ECommerce.ERefunds
{
    public class RefundsApplyRequest
    {
        /// <summary>
        /// 微信支付分配二级商户的商户号
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("sub_mchid")]
        public string SubMchId { get; set; }

        /// <summary>
        /// 电商平台APPID
        /// 电商平台在微信公众平台申请服务号对应的APPID，申请商户功能的时候微信支付会配置绑定关系。
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("sp_appid")]
        public string SpAppId { get; set; }


        /// <summary>
        /// 二级商户APPID
        /// </summary> 
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("sub_appid")]
        public string SubAppId { get; set; }

        /// <summary>
        /// 微信订单号
        /// </summary> 
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("transaction_id")]
        public string TransactionId { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("out_trade_no")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 商户退款单号
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(64)]
        [JsonPropertyName("out_refund_no")]
        public string OutRefundNo { get; set; }


        /// <summary>
        /// 退款原因
        /// </summary> 
        [MinLength(1)]
        [MaxLength(80)]
        [JsonPropertyName("reason")]
        public string Reason { get; set; }

        /// <summary>
        /// 订单金额信息	
        /// </summary> 
        [MinLength(1)]
        [MaxLength(64)]
        [JsonPropertyName("amount")]
        public AccountInfo Amount { get; set; }

        /// <summary>
        /// 退款结果回调url
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("notify_url")]
        public string NotifyUrl { get; set; }

 
    }
}
