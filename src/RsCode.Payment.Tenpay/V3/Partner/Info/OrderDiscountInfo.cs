using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Partner
{
    /// <summary>
    /// 订单优惠信息
    /// </summary>
    public class OrderDiscountInfo
    {
        /// <summary>
        ///  订单原价
        /// </summary>
        [JsonPropertyName("cost_price")]
        public int CostPrice { get; set; }
        /// <summary>
        ///  商品小票ID
        /// </summary>
        [JsonPropertyName("invoice_id")]
        public string InvoiceId { get; set; }
        /// <summary>
        ///  单品列表
        /// </summary>
        [JsonPropertyName("goods_detail")]
        public List<GoodDetailInfo> GoodsDetail { get; set; }
    }
}
