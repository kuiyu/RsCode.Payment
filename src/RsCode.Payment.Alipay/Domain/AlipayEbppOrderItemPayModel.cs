using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayEbppOrderItemPayModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayEbppOrderItemPayModel : AopObject
    {
        /// <summary>
        /// 支付宝侧对预下单订单项的唯一标识
        /// </summary>
        [XmlElement("alipay_item_id")]
        public string AlipayItemId { get; set; }
    }
}
