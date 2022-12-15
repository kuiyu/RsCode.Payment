using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiCateringKmsOrderSyncModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiCateringKmsOrderSyncModel : AopObject
    {
        /// <summary>
        /// 同步动作. "PUSH":推送订单; "CANCEL_PUSH": 取消推送
        /// </summary>
        [XmlElement("action")]
        public string Action { get; set; }

        /// <summary>
        /// 渠道码. "ELE_ME": 饿了么; "KERUYUN": 客如云
        /// </summary>
        [XmlElement("biz_channel")]
        public string BizChannel { get; set; }

        /// <summary>
        /// 菜品信息列表. action=PUSH时必填, aciton=CANCEL_PUSH不填
        /// </summary>
        [XmlArray("kds_dish_info_list")]
        [XmlArrayItem("kds_dish_info_d_t_o")]
        public List<KdsDishInfoDTO> KdsDishInfoList { get; set; }

        /// <summary>
        /// 订单信息. action=PUSH时必填, aciton=CANCEL_PUSH不填
        /// </summary>
        [XmlElement("kds_order_info")]
        public KdsOrderInfoDTO KdsOrderInfo { get; set; }

        /// <summary>
        /// 口碑订单号 (口碑订单必传) 退款时, 以order_no为主. 如果order_no不存在, 以out_order_no为准.
        /// </summary>
        [XmlElement("order_no")]
        public string OrderNo { get; set; }

        /// <summary>
        /// 外部订单号
        /// </summary>
        [XmlElement("out_order_no")]
        public string OutOrderNo { get; set; }

        /// <summary>
        /// 口碑店铺id
        /// </summary>
        [XmlElement("shop_id")]
        public string ShopId { get; set; }

        /// <summary>
        /// 原始订单来源. 来自客如云的订单: keruyun(客如云本地pos下单/客如云线上扫码点餐),koubei(口碑点餐),other(其他平台)
        /// </summary>
        [XmlElement("source")]
        public string Source { get; set; }
    }
}
