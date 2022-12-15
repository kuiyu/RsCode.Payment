using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// CreditPayOrderInfoVO Data Structure.
    /// </summary>
    [Serializable]
    public class CreditPayOrderInfoVO : AopObject
    {
        /// <summary>
        /// 外部平台订单号，如果传给支付宝收单时带着前缀，此处也需要
        /// </summary>
        [XmlElement("out_order_no")]
        public string OutOrderNo { get; set; }

        /// <summary>
        /// 卖家支付宝账户ID
        /// </summary>
        [XmlElement("seller_user_id")]
        public string SellerUserId { get; set; }
    }
}
