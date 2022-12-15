using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.ECommerce.ECombine
{
    public class AppRequest
    {
        /// <summary>
        /// 合单发起方的appid	
        /// </summary>
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("combine_appid")]
        public string CombineAppId { get; set; }

        /// <summary>
        /// 合单商户号
        /// </summary>
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("combine_mchid")]
        public string CombineMchId { get; set; }

        /// <summary>
        /// 合单商户订单号
        /// 合单支付总订单号
        /// </summary>
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("combine_out_trade_no")]
        public string CombineOutTradeNo { get; set; }

        /// <summary>
        /// 支付场景信息描述
        /// </summary>
        [JsonPropertyName("scene_info")]
        public SceneInfo SceneInfo { get; set; }

        /// <summary>
        /// 子单信息
        /// </summary> 
        [Required][JsonPropertyName("sub_orders")]
        public SubOrderInfo SubOrders { get; set; }

        /// <summary>
        /// 支付者信息
        /// </summary> 
        [JsonPropertyName("combine_payer_info")]
        public CombinePayerInfo CombinePayerInfo { get; set; }

        /// <summary>
        /// 交易起始时间
        /// </summary>
        [MinLength(1)]
        [MaxLength(14)]
        [JsonPropertyName("time_start")]
        public string TimeStart { get; set; }

        /// <summary>
        /// 交易结束时间
        /// </summary>
        [MinLength(1)]
        [MaxLength(14)]
        [JsonPropertyName("time_expire")]
        public string TimeExpire { get; set; }

        /// <summary>
        /// 通知地址
        /// </summary>
        [MinLength(1)]
        [MaxLength(256)]
        [JsonPropertyName("notify_url")]
        public string NotifyUrl { get; set; }

        
    }
}
