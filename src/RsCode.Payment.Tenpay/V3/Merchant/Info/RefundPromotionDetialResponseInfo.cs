/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Merchant.Info
{
    /// <summary>
    /// 退款响应：优惠退款信息
    /// </summary>
    public  class RefundPromotionDetialResponseInfo
    {
        /// <summary>
        /// 券ID
        /// </summary>
        [JsonPropertyName("promotion_id")]
        public string PromotionId { get; set; }
        /// <summary>
        /// 优惠范围
        /// 枚举值：
        /// GLOBAL：全场代金券
        /// SINGLE：单品优惠
        /// </summary>
        [JsonPropertyName("scope")] public string Scope { get; set; }
        /// <summary>
        /// 优惠类型
        /// 枚举值：
       /// COUPON：代金券，需要走结算资金的充值型代金券
       /// DISCOUNT：优惠券，不走结算资金的免充值型优惠券
                /// </summary>
                [JsonPropertyName("type")] public string PromotionType { get; set; }
        /// <summary>
        /// 优惠券面额
        /// </summary>
        [JsonPropertyName("amount")] public int Amount { get; set; }
        /// <summary>
        /// 优惠退款金额
        /// </summary>
        [JsonPropertyName("refund_amount")] public int RefundAmount { get; set; }

    
        /// <summary>
        /// 商品列表
        /// </summary>
        [JsonPropertyName("goods_detail")] public RefundGoodsInfo[] GoodsDetail { get; set; }
    }
}
