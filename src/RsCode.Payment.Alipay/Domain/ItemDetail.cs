using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// ItemDetail Data Structure.
    /// </summary>
    [Serializable]
    public class ItemDetail : AopObject
    {
        /// <summary>
        /// 商品编号
        /// </summary>
        [XmlElement("item_id")]
        public string ItemId { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [XmlElement("item_name")]
        public string ItemName { get; set; }

        /// <summary>
        /// 商品价格，单位为元，精确到小数点后两位，取值范围[0.01,100000000]
        /// </summary>
        [XmlElement("price")]
        public string Price { get; set; }

        /// <summary>
        /// 商品数量。目前仅支持整数，若需要传小数，请咨询支付宝小二或接口owner
        /// </summary>
        [XmlElement("quantity")]
        public long Quantity { get; set; }
    }
}
