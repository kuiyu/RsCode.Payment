using System;
using System.Xml.Serialization;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipayPcreditHuabeiAuthAgreementCloseResponse.
    /// </summary>
    public class AlipayPcreditHuabeiAuthAgreementCloseResponse : AopResponse
    {
        /// <summary>
        /// 外部请求号
        /// </summary>
        [XmlElement("out_request_no")]
        public string OutRequestNo { get; set; }
    }
}
