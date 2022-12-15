using System;
using System.Xml.Serialization;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipayTradeRoyaltyRelationUnbindResponse.
    /// </summary>
    public class AlipayTradeRoyaltyRelationUnbindResponse : AopResponse
    {
        /// <summary>
        /// 业务结果码。SUCCESS：分账关系解绑成功； FAIL：分账关系解绑失败。
        /// </summary>
        [XmlElement("result_code")]
        public string ResultCode { get; set; }
    }
}
