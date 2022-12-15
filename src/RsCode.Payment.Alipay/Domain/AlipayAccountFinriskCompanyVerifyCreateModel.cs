using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayAccountFinriskCompanyVerifyCreateModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayAccountFinriskCompanyVerifyCreateModel : AopObject
    {
        /// <summary>
        /// 请求系统
        /// </summary>
        [XmlElement("app")]
        public string App { get; set; }

        /// <summary>
        /// 业务参数列表
        /// </summary>
        [XmlElement("param")]
        public string Param { get; set; }

        /// <summary>
        /// 外部请求唯一标识
        /// </summary>
        [XmlElement("request_id")]
        public string RequestId { get; set; }

        /// <summary>
        /// 防伪场景编码
        /// </summary>
        [XmlElement("scene_id")]
        public string SceneId { get; set; }

        /// <summary>
        /// 租户ID
        /// </summary>
        [XmlElement("tnt_inst_id")]
        public string TntInstId { get; set; }
    }
}
