using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// PosDiscountDetail Data Structure.
    /// </summary>
    [Serializable]
    public class PosDiscountDetail : AopObject
    {
        /// <summary>
        /// 活动id
        /// </summary>
        [XmlElement("activity_id")]
        public string ActivityId { get; set; }

        /// <summary>
        /// 活动类型，可枚举的类型  (1)itemDiscount 商品级优惠  (2) buyItem 购买商品  (3) fullDiscountCamp 全场折活动  (4) fullCutCamp 全场满减活动  (5) fullCutVoucher 全场满减券
        /// </summary>
        [XmlElement("activity_type")]
        public string ActivityType { get; set; }

        /// <summary>
        /// 优惠名称
        /// </summary>
        [XmlElement("discount_name")]
        public string DiscountName { get; set; }

        /// <summary>
        /// 优惠类型
        /// </summary>
        [XmlElement("discount_type")]
        public string DiscountType { get; set; }

        /// <summary>
        /// 菜品id
        /// </summary>
        [XmlElement("dish_id")]
        public string DishId { get; set; }

        /// <summary>
        /// 扩展信息，存储优惠的详细模型。json对象格式，key和value都为字符串，其中DISH_ID为菜品id，USER_ITEM_ID为被核销商品id
        /// </summary>
        [XmlElement("ext_info")]
        public string ExtInfo { get; set; }

        /// <summary>
        /// 商家出资优惠金额，以元为单位，精确到分
        /// </summary>
        [XmlElement("mrt_discount")]
        public string MrtDiscount { get; set; }

        /// <summary>
        /// 平台出资优惠金额，以元为单位，精确到分
        /// </summary>
        [XmlElement("rt_discount")]
        public string RtDiscount { get; set; }

        /// <summary>
        /// 人群要求(会员)，可枚举的类型(1)member 会员(2) normal 普通
        /// </summary>
        [XmlElement("target_user_type")]
        public string TargetUserType { get; set; }

        /// <summary>
        /// 被核销的商品id
        /// </summary>
        [XmlElement("used_item_id")]
        public string UsedItemId { get; set; }
    }
}
