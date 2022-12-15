using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// TicketCodeQueryResponse Data Structure.
    /// </summary>
    [Serializable]
    public class TicketCodeQueryResponse : AopObject
    {
        /// <summary>
        /// 当前可用份数
        /// </summary>
        [XmlElement("available_quantity")]
        public string AvailableQuantity { get; set; }

        /// <summary>
        /// 凭证生效时间 yyyy-MM-dd HH:mm:ss
        /// </summary>
        [XmlElement("effect_date")]
        public string EffectDate { get; set; }

        /// <summary>
        /// 凭证失效时间 格式 yyyy-MM-dd HH:mm:ss
        /// </summary>
        [XmlElement("expire_date")]
        public string ExpireDate { get; set; }

        /// <summary>
        /// 商品编码
        /// </summary>
        [XmlArray("item_goods_ids")]
        [XmlArrayItem("string")]
        public List<string> ItemGoodsIds { get; set; }

        /// <summary>
        /// 商品id
        /// </summary>
        [XmlElement("item_id")]
        public string ItemId { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [XmlElement("item_name")]
        public string ItemName { get; set; }

        /// <summary>
        /// 凭证核销方式
        /// </summary>
        [XmlElement("ticket_display_mode")]
        public string TicketDisplayMode { get; set; }

        /// <summary>
        /// ticket id
        /// </summary>
        [XmlElement("ticket_id")]
        public string TicketId { get; set; }

        /// <summary>
        /// 券状态
        /// </summary>
        [XmlElement("ticket_status")]
        public string TicketStatus { get; set; }

        /// <summary>
        /// 是否次卡
        /// </summary>
        [XmlElement("time_cards")]
        public bool TimeCards { get; set; }

        /// <summary>
        /// 初始份数
        /// </summary>
        [XmlElement("total_quantity")]
        public string TotalQuantity { get; set; }
    }
}
