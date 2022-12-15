using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiSalesKbassetStuffInventoryrealtimeSyncModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiSalesKbassetStuffInventoryrealtimeSyncModel : AopObject
    {
        /// <summary>
        /// 扩展字段
        /// </summary>
        [XmlElement("ext_info")]
        public string ExtInfo { get; set; }

        /// <summary>
        /// 库存时间
        /// </summary>
        [XmlElement("inventory_time")]
        public string InventoryTime { get; set; }

        /// <summary>
        /// 库存明细
        /// </summary>
        [XmlArray("items")]
        [XmlArrayItem("inventory_item")]
        public List<InventoryItem> Items { get; set; }
    }
}
