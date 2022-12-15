/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace RsCode.Payment.Tenpay.ECommerce.ECombine
{
   public class CloseRequest
    {
        /// <summary>
        /// 合单商户appid
        /// </summary>
        [JsonPropertyName("combine_appid")]
        public string CombineAppId { get; set; }

        /// <summary>
        /// 合单商户订单号
        /// </summary>
        [JsonPropertyName("combine_out_trade_no")]
        public string CombineOutTradeNo { get; set; }

        /// <summary>
        /// 子单信息
        /// </summary>
        [JsonPropertyName("sub_orders")]
        public SubOrderInfo2 SubOrders { get; set; }
    }

    public class SubOrderInfo2
    {
        /// <summary>
        /// 子单发起方商户号，必须与发起方appid有绑定关系。
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("mchid")]
        public string MchId { get; set; }

        /// <summary>
        /// 商户系统内部订单号
        /// </summary>
        [Required]
        [MinLength(6)]
        [MaxLength(32)]
        [JsonPropertyName("out_trade_no")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 二级商户商户号，由微信支付生成并下发
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("sub_mchid")]
        public string SubMchId { get; set; } 
    }
}
