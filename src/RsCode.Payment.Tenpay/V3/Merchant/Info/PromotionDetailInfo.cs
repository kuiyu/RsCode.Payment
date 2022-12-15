using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Merchant
{
    /// <summary>
    /// 优惠功能，享受优惠时返回该字段
    /// </summary>
    public class PromotionDetailInfo
    {
        /// <summary>
        ///  券ID
        /// </summary>
        [JsonPropertyName("coupon_id")]
        public string CouponId { get; set; }
        /// <summary>
        ///  优惠名称
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
        /// <summary>
        ///  优惠范围
        /// </summary>
        [JsonPropertyName("scope")]
        public string Scope { get; set; }
        /// <summary>
        ///  优惠类型
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
        /// <summary>
        ///  优惠券面额
        /// </summary>
        [JsonPropertyName("amount")]
        public int Amount { get; set; }
        /// <summary>
        ///  活动ID
        /// </summary>
        [JsonPropertyName("stock_id")]
        public string StockId { get; set; }
        /// <summary>
        ///  微信出资
        /// </summary>
        [JsonPropertyName("wechatpay_contribute")]
        public int WechatPayContribute { get; set; }
        /// <summary>
        ///  商户出资
        /// </summary>
        [JsonPropertyName("merchant_contribute")]
        public int MerchantContribute { get; set; }
        /// <summary>
        ///  其他出资
        /// </summary>
        [JsonPropertyName("other_contribute")]
        public int OtherContribute { get; set; }
        /// <summary>
        ///  优惠币种
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; }
        /// <summary>
        ///  单品列表
        /// </summary>
        [JsonPropertyName("goods_detail")]
        public GoodDetailInfo GoodsDetail { get; set; }
    }
}
