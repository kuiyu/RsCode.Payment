using System;
using System.Xml.Serialization;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipayDataDataserviceAdUserCreateResponse.
    /// </summary>
    public class AlipayDataDataserviceAdUserCreateResponse : AopResponse
    {
        /// <summary>
        /// 商家id
        /// </summary>
        [XmlElement("principal_id")]
        public long PrincipalId { get; set; }

        /// <summary>
        /// 账户id
        /// </summary>
        [XmlElement("user_id")]
        public long UserId { get; set; }
    }
}
