using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// TradePrecreateConfirmPrecreateCodeInfo Data Structure.
    /// </summary>
    [Serializable]
    public class TradePrecreateConfirmPrecreateCodeInfo : AopObject
    {
        /// <summary>
        /// 预下单阶段产生的码串，对应预下单订单。
        /// </summary>
        [XmlElement("precreate_code")]
        public string PrecreateCode { get; set; }

        /// <summary>
        /// 码创建时间
        /// </summary>
        [XmlElement("precreate_code_create_time")]
        public string PrecreateCodeCreateTime { get; set; }

        /// <summary>
        /// 预下单阶段的码串类型  订单二维码，取值：qr_code
        /// </summary>
        [XmlElement("precreate_code_type")]
        public string PrecreateCodeType { get; set; }
    }
}
