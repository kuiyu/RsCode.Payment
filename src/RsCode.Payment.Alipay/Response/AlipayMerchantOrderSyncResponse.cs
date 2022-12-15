using System;
using System.Xml.Serialization;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipayMerchantOrderSyncResponse.
    /// </summary>
    public class AlipayMerchantOrderSyncResponse : AopResponse
    {
        /// <summary>
        /// 同步成功后的订单号
        /// </summary>
        [XmlElement("order_id")]
        public string OrderId { get; set; }
    }
}
