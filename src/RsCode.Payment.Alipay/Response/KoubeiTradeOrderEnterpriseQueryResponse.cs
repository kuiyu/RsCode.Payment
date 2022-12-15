using System;
using System.Xml.Serialization;

namespace Aop.Api.Response
{
    /// <summary>
    /// KoubeiTradeOrderEnterpriseQueryResponse.
    /// </summary>
    public class KoubeiTradeOrderEnterpriseQueryResponse : AopResponse
    {
        /// <summary>
        /// 订单下单主体id，一般是支付宝账号，也可能是虚拟账号
        /// </summary>
        [XmlElement("buyer_user_id")]
        public string BuyerUserId { get; set; }

        /// <summary>
        /// json格式的字符串，订单的扩展信息
        /// </summary>
        [XmlElement("ext_info")]
        public string ExtInfo { get; set; }

        /// <summary>
        /// 订单对应的商家补贴的金额
        /// </summary>
        [XmlElement("merchant_subsidy_amount")]
        public string MerchantSubsidyAmount { get; set; }

        /// <summary>
        /// 口碑订单号
        /// </summary>
        [XmlElement("order_no")]
        public string OrderNo { get; set; }

        /// <summary>
        /// 订单产品码
        /// </summary>
        [XmlElement("order_product")]
        public string OrderProduct { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        [XmlElement("out_order_no")]
        public string OutOrderNo { get; set; }

        /// <summary>
        /// 商户签约支付宝账号
        /// </summary>
        [XmlElement("partner_id")]
        public string PartnerId { get; set; }

        /// <summary>
        /// 订单支付的实际资金
        /// </summary>
        [XmlElement("real_amount")]
        public string RealAmount { get; set; }

        /// <summary>
        /// 订单打款对应的商家收款账户
        /// </summary>
        [XmlElement("seller_id")]
        public string SellerId { get; set; }

        /// <summary>
        /// 口碑门店id
        /// </summary>
        [XmlElement("shop_id")]
        public string ShopId { get; set; }

        /// <summary>
        /// 订单状态:INITIAL（订单初始化）、WAIT_PAY（订单已创建待支付）、ERROR（订单异常）、PAID（已支付）、SUCCESS（订单成功）、WAIT_PAY_CLOSE（订单未支付后自动关闭或者未支付用户主动关闭）、CLOSED（订单支付成功后，全部退款）、FINISH（订完完结）
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }

        /// <summary>
        /// 订单标题
        /// </summary>
        [XmlElement("subject")]
        public string Subject { get; set; }

        /// <summary>
        /// 订单对应的平台补贴的金额
        /// </summary>
        [XmlElement("subsidy_amount")]
        public string SubsidyAmount { get; set; }

        /// <summary>
        /// 订单总金额
        /// </summary>
        [XmlElement("total_amount")]
        public string TotalAmount { get; set; }
    }
}
