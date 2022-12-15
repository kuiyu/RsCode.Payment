using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayOpenServicemarketOrderSyncModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayOpenServicemarketOrderSyncModel : AopObject
    {
        /// <summary>
        /// 实际支付金额，单位分
        /// </summary>
        [XmlElement("actual_amount")]
        public long ActualAmount { get; set; }

        /// <summary>
        /// 购买者uid
        /// </summary>
        [XmlElement("consumer_uid")]
        public string ConsumerUid { get; set; }

        /// <summary>
        /// 优惠券抵扣金额，单位分
        /// </summary>
        [XmlElement("coupon_amount")]
        public long CouponAmount { get; set; }

        /// <summary>
        /// 商品折扣金额，单位分
        /// </summary>
        [XmlElement("discount_amount")]
        public long DiscountAmount { get; set; }

        /// <summary>
        /// 有业务含义的外部订单号，用做页面跳转等操作
        /// </summary>
        [XmlElement("fin_tech_order_no")]
        public string FinTechOrderNo { get; set; }

        /// <summary>
        /// 金融科技产品码
        /// </summary>
        [XmlElement("fin_tech_product_code")]
        public string FinTechProductCode { get; set; }

        /// <summary>
        /// 最后修改时间，用做防请求乱序，针对同一条数据的更新，如果值小于上一个请求的值，该次请求会被丢弃。建议使用数据的修改时间，或者乐观锁的version作为参数值。
        /// </summary>
        [XmlElement("gmt_modified")]
        public long GmtModified { get; set; }

        /// <summary>
        /// 金融科技订单状态
        /// </summary>
        [XmlElement("order_status")]
        public string OrderStatus { get; set; }

        /// <summary>
        /// 下单时间，格式yyyy-MM-dd HH:mm:ss
        /// </summary>
        [XmlElement("order_time")]
        public string OrderTime { get; set; }

        /// <summary>
        /// 金融科技订单类型
        /// </summary>
        [XmlElement("order_type")]
        public string OrderType { get; set; }

        /// <summary>
        /// 商品原始金额，单位分
        /// </summary>
        [XmlElement("original_amount")]
        public long OriginalAmount { get; set; }

        /// <summary>
        /// 幂等参数，比如某种业务标准外部订单号,比如交易外部订单号，代表商户端自己订单号
        /// </summary>
        [XmlElement("out_biz_no")]
        public string OutBizNo { get; set; }
    }
}
