using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayUserCertdocUrlQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayUserCertdocUrlQueryModel : AopObject
    {
        /// <summary>
        /// 业务类型。向支付宝证件夹PD申请。
        /// </summary>
        [XmlElement("biz_type")]
        public string BizType { get; set; }

        /// <summary>
        /// 证件类型。支持传泛电子证件类型，或某地方具体的电子证件类型。传电子证件类型包括：E_IDENTITY_CARD 代表电子身份证。
        /// </summary>
        [XmlElement("cert_doc_type")]
        public string CertDocType { get; set; }

        /// <summary>
        /// 中文城市名字。当url_type为SHOW时，cert_doc_type为泛电子证件类型时，必传。
        /// </summary>
        [XmlElement("city")]
        public string City { get; set; }

        /// <summary>
        /// 链接类型。目前支持：SHOW 代表证件卡面页.
        /// </summary>
        [XmlElement("url_type")]
        public string UrlType { get; set; }
    }
}
