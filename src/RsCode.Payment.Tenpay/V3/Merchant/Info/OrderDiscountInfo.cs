/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Merchant
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
        public string InvoiceId { get; set; } = "";
        /// <summary>
        ///  单品列表
        /// </summary>
        [JsonPropertyName("goods_detail")]
        public GoodsDetailInfo[] GoodsDetail { get; set; }
    }
}
