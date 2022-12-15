using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Partner
{
    /// <summary>
    /// 服务商JSAPI/小程序下单API
    /// </summary>
    public class TransactionsJsapiRequest:TenpayBaseRequest
    {
      
        /// <summary>
        ///服务商申请的公众号或移动应用appid。
        /// </summary>
        [Required]
        [JsonPropertyName("sp_appid")]
        public string SpAppId { get; set; }

        /// <summary>
        /// 服务商户号
        /// </summary>
        [Required] [JsonPropertyName("sp_mchid")] public string SpMchId { get; set; }
        /// <summary>
        /// 子商户申请的公众号或移动应用appid。如果传入sub_openid，则sub_appid必传
        /// </summary>
        [JsonPropertyName("sub_appid")] public string SubAppId { get; set; }

        /// <summary>
        /// 子商户号
        /// </summary>
        [JsonPropertyName("sub_mchid")] public string SubMchId { get; set; }

        /// <summary>
        /// 商品描述
        /// </summary>
        [Required] [JsonPropertyName("description")] public string Description { get; set; }
        /// <summary>
        /// 商户订单号
        /// </summary>
        [JsonPropertyName("out_trade_no")]
        public string OutTradeNo { get; set; }
        /// <summary>
        /// 交易结束时间
        /// </summary>
        [JsonPropertyName("time_expire")] public string TimeExpire { get; set; }
        /// <summary>
        /// 附加数据
        /// </summary>
        [JsonPropertyName("attach")] public string Attach { get; set; }
        /// <summary>
        /// 通知地址
        /// </summary>
        [Required] [JsonPropertyName("notify_url")] public string NotifyUrl { get; set; }
        /// <summary>
        /// 商品标记
        /// </summary>
        [JsonPropertyName("goods_tag")] public string GoodsTag { get; set; }
        /// <summary>
        /// 结算信息
        /// </summary>
        [JsonPropertyName("settle_info")]
        public SettleInfo SettleInfo { get; set; }
        /// <summary>
        ///  订单金额信息
        /// </summary>
        [JsonPropertyName("amount")]
        public AmountInfo AmountInfo { get; set; }
        /// <summary>
        ///  支付者信息
        /// </summary>
        [JsonPropertyName("payer")]
        public PayerInfo PayerInfo { get; set; }
        /// <summary>
        ///  优惠功能
        /// </summary>
        [JsonPropertyName("detail")]
        public OrderDiscountInfo Detail { get; set; }

        /// <summary>
        /// 支付场景描述
        /// </summary>
        [JsonPropertyName("scene_info")]
        public SceneInfo SceneInfo { get; set; }

 
        public string GetApiUrl()
        {
            return "https://api.mch.weixin.qq.com/v3/pay/partner/transactions/jsapi";
        }
        public string RequestMethod()
        {
            return "POST";
        }

       
    }
}
