using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// ItemOrderInfoResult Data Structure.
    /// </summary>
    [Serializable]
    public class ItemOrderInfoResult : AopObject
    {
        /// <summary>
        /// 商品图片链接
        /// </summary>
        [XmlElement("image_url")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [XmlElement("item_name")]
        public string ItemName { get; set; }

        /// <summary>
        /// 商户商品链接
        /// </summary>
        [XmlElement("merchant_item_link_page")]
        public string MerchantItemLinkPage { get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        [XmlElement("quantity")]
        public long Quantity { get; set; }

        /// <summary>
        /// 商品单价（单位：元）
        /// </summary>
        [XmlElement("unit_price")]
        public string UnitPrice { get; set; }
    }
}
