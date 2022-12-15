using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayMsaasMediarecogMmtcaftscvTemplateApplyModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayMsaasMediarecogMmtcaftscvTemplateApplyModel : AopObject
    {
        /// <summary>
        /// 模板编号
        /// </summary>
        [XmlElement("template_id")]
        public string TemplateId { get; set; }
    }
}
