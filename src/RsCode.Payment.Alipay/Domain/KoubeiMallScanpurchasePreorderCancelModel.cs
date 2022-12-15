using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiMallScanpurchasePreorderCancelModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiMallScanpurchasePreorderCancelModel : AopObject
    {
        /// <summary>
        /// 预订单编号
        /// </summary>
        [XmlElement("advance_order_id")]
        public string AdvanceOrderId { get; set; }
    }
}
