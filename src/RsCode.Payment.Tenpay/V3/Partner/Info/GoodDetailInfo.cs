using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Partner
{
    /// <summary>
    /// 单品列表信息   条目个数限制
    /// </summary>
    public class GoodDetailInfo
    {
        /// <summary>
        ///  商户侧商品编码
        /// </summary>
        [JsonPropertyName("merchant_goods_id")]
        public string MerchantGoodsId { get; set; }
        /// <summary>
        ///  微信侧商品编码
        /// </summary>
        [JsonPropertyName("wechatpay_goods_id")]
        public string WechatPayGoodsId { get; set; }
        /// <summary>
        ///  商品名称
        /// </summary>
        [JsonPropertyName("goods_name")]
        public string GoodsName { get; set; }
        /// <summary>
        ///  商品数量
        /// </summary>
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
        /// <summary>
        ///  商品单价
        /// </summary>
        [JsonPropertyName("unit_price")]
        public int UnitPrice { get; set; }
    }
}
