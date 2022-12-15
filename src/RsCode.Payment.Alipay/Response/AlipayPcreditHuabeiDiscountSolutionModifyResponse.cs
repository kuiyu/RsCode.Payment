using System;
using System.Xml.Serialization;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipayPcreditHuabeiDiscountSolutionModifyResponse.
    /// </summary>
    public class AlipayPcreditHuabeiDiscountSolutionModifyResponse : AopResponse
    {
        /// <summary>
        /// success，是否更新成功，true成功，false失败
        /// </summary>
        [XmlElement("success")]
        public bool Success { get; set; }
    }
}
