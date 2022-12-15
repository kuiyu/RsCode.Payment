using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KdsOrderInfoDTO Data Structure.
    /// </summary>
    [Serializable]
    public class KdsOrderInfoDTO : AopObject
    {
        /// <summary>
        /// 订单业务产品类型.  "KB_ORDER_DISHES": 口碑c端点餐; "KB_RESERVATION": 口碑预约点餐; "KB_POS_ORDER_DISHES": 口碑B端盒子订单 "ISV_ORDER_DISHES": ISV服务商订单 "ISV_RESERVATION": ISV服务商预点餐订单  备注: 口碑的订单, 如果普通订单传 KB_ORDER_DISHES, 预约单传KB_RESERVATION 其他来源订单, 包括客如云和other, 默认ISV_ORDER_DISHES,  如果是预订单就传ISV_RESERVATION
        /// </summary>
        [XmlElement("biz_product")]
        public string BizProduct { get; set; }

        /// <summary>
        /// 下厨时间 (可选, 默认是立即下厨)
        /// </summary>
        [XmlElement("cook_time")]
        public string CookTime { get; set; }

        /// <summary>
        /// 就餐区域
        /// </summary>
        [XmlElement("dinner_area")]
        public string DinnerArea { get; set; }

        /// <summary>
        /// 就餐号：桌号或取餐号
        /// </summary>
        [XmlElement("dinner_no")]
        public string DinnerNo { get; set; }

        /// <summary>
        /// 就餐类型. "TO_GO": 外带; "TAKE_OUT": 外卖; "FOR_HERE": 堂食
        /// </summary>
        [XmlElement("dinner_type")]
        public string DinnerType { get; set; }

        /// <summary>
        /// 扩展字段
        /// </summary>
        [XmlElement("ext_info")]
        public string ExtInfo { get; set; }

        /// <summary>
        /// 整单备注
        /// </summary>
        [XmlElement("memo")]
        public string Memo { get; set; }

        /// <summary>
        /// 手机号 (能取到则传入)
        /// </summary>
        [XmlElement("mobile")]
        public string Mobile { get; set; }

        /// <summary>
        /// 口碑订单号 (口碑订单必传)
        /// </summary>
        [XmlElement("order_no")]
        public string OrderNo { get; set; }

        /// <summary>
        /// 订单创建时间
        /// </summary>
        [XmlElement("order_time")]
        public string OrderTime { get; set; }

        /// <summary>
        /// 原始订单数据(JSON格式)
        /// </summary>
        [XmlElement("out_order_info")]
        public string OutOrderInfo { get; set; }

        /// <summary>
        /// 外部订单号
        /// </summary>
        [XmlElement("out_order_no")]
        public string OutOrderNo { get; set; }

        /// <summary>
        /// 口碑商户PID
        /// </summary>
        [XmlElement("partner_id")]
        public string PartnerId { get; set; }

        /// <summary>
        /// 支付类型. "ADVANCE_PAYMENT": 先付; "AFTER_PAYMENT": 后付
        /// </summary>
        [XmlElement("pay_style")]
        public string PayStyle { get; set; }

        /// <summary>
        /// 预定时间 (预订单必传)
        /// </summary>
        [XmlElement("schedule_time")]
        public string ScheduleTime { get; set; }

        /// <summary>
        /// 口碑门店id
        /// </summary>
        [XmlElement("shop_id")]
        public string ShopId { get; set; }

        /// <summary>
        /// 取餐渠道. "CABINET" 取餐柜;  "COUNTER":取餐台 (预留字段 客如云无需传入)
        /// </summary>
        [XmlElement("take_channel")]
        public string TakeChannel { get; set; }

        /// <summary>
        /// 支付宝用户id (能取到则传入)
        /// </summary>
        [XmlElement("user_id")]
        public string UserId { get; set; }
    }
}
