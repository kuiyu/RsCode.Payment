﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Merchant
{
    /// <summary>
    /// 单品列表信息   条目个数限制
    /// </summary>
    public class GoodDetailInfo
    {
        /// <summary>
        ///  商品编码
        /// </summary>
        [JsonPropertyName("goods_id")]
        public string GoodsId { get; set; }

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
        /// <summary>
        ///  商品优惠金额
        /// </summary>
        [JsonPropertyName("discount_amount")]
        public string DiscountAmount { get; set; }
        /// <summary>
        ///  商品备注
        /// </summary>
        [JsonPropertyName("goods_remark")]
        public string GoodsRemark { get; set; }
    }
}
