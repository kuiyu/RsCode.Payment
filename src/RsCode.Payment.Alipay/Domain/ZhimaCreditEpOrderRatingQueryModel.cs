using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// ZhimaCreditEpOrderRatingQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class ZhimaCreditEpOrderRatingQueryModel : AopObject
    {
        /// <summary>
        /// 芝麻企业信用评估订单号
        /// </summary>
        [XmlElement("order_no")]
        public string OrderNo { get; set; }
    }
}
