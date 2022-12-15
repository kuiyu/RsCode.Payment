using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// ZhimaCreditEpProductCodeModifyModel Data Structure.
    /// </summary>
    [Serializable]
    public class ZhimaCreditEpProductCodeModifyModel : AopObject
    {
        /// <summary>
        /// 二维码唯一标识id
        /// </summary>
        [XmlElement("code_id")]
        public string CodeId { get; set; }
    }
}
