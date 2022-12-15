using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayCommerceIotAdvertiserMaterialQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayCommerceIotAdvertiserMaterialQueryModel : AopObject
    {
        /// <summary>
        /// 物料id
        /// </summary>
        [XmlElement("id")]
        public long Id { get; set; }
    }
}
