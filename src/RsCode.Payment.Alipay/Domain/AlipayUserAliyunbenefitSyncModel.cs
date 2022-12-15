using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayUserAliyunbenefitSyncModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayUserAliyunbenefitSyncModel : AopObject
    {
        /// <summary>
        /// 阿里云商品类目编码
        /// </summary>
        [XmlElement("category_code")]
        public string CategoryCode { get; set; }

        /// <summary>
        /// 阿里云商品Id
        /// </summary>
        [XmlElement("item_id")]
        public string ItemId { get; set; }

        /// <summary>
        /// 权益的名称
        /// </summary>
        [XmlElement("item_title")]
        public string ItemTitle { get; set; }

        /// <summary>
        /// 主图地址
        /// </summary>
        [XmlElement("main_pic")]
        public string MainPic { get; set; }

        /// <summary>
        /// 用于表示该接口的操作，CREATE表示创建，EDIT表示编辑权益，OFF_LINE表示下线权益，其他码则不进行任何操作
        /// </summary>
        [XmlElement("op_action")]
        public string OpAction { get; set; }

        /// <summary>
        /// 权益发起同步的时间戳，对于同一变更内容的同步，多次请求，必须保证每次请求的时间戳一样
        /// </summary>
        [XmlElement("op_timestamp")]
        public long OpTimestamp { get; set; }

        /// <summary>
        /// 当前选品操作人的信息
        /// </summary>
        [XmlElement("operator")]
        public string Operator { get; set; }

        /// <summary>
        /// 商品的划线价，以分为单位，12500表示125元
        /// </summary>
        [XmlElement("reserve_price")]
        public long ReservePrice { get; set; }

        /// <summary>
        /// 店铺名称
        /// </summary>
        [XmlElement("shop_name")]
        public string ShopName { get; set; }

        /// <summary>
        /// 商品的SKU信息
        /// </summary>
        [XmlArray("sku_infos")]
        [XmlArrayItem("sku_info")]
        public List<SkuInfo> SkuInfos { get; set; }
    }
}
