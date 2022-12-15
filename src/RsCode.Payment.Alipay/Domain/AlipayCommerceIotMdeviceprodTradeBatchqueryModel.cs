using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayCommerceIotMdeviceprodTradeBatchqueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayCommerceIotMdeviceprodTradeBatchqueryModel : AopObject
    {
        /// <summary>
        /// 真实设备sn
        /// </summary>
        [XmlElement("device_sn")]
        public string DeviceSn { get; set; }

        /// <summary>
        /// 物料id
        /// </summary>
        [XmlElement("item_id")]
        public string ItemId { get; set; }

        /// <summary>
        /// 供应商id
        /// </summary>
        [XmlElement("supplier_sn")]
        public string SupplierSn { get; set; }

        /// <summary>
        /// 交易流水号，优先级最高，如果传入则根据流水号查询
        /// </summary>
        [XmlElement("trade_no")]
        public string TradeNo { get; set; }
    }
}
