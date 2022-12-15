using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayOpenAppSilanApigrayQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayOpenAppSilanApigrayQueryModel : AopObject
    {
        /// <summary>
        /// param
        /// </summary>
        [XmlElement("param_1")]
        public string Param1 { get; set; }
    }
}
