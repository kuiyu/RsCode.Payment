using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// ApplyCodeRequest Data Structure.
    /// </summary>
    [Serializable]
    public class ApplyCodeRequest : AopObject
    {
        /// <summary>
        /// biz_id，唯一，业务id，用于业务请求的幂等标志
        /// </summary>
        [XmlElement("biz_id")]
        public string BizId { get; set; }

        /// <summary>
        /// context_data，发码的上下文信息，比如子业务code，场景code等。此值为一个Map<string, string>类型的json串字符，传入规则如下： {"key1":"val2","key2":"val2"}。必填业务字段：SUB_BIZ_TYPE，SCENE，url
        /// </summary>
        [XmlElement("context_data")]
        public string ContextData { get; set; }

        /// <summary>
        /// logo_url，logo图片地址
        /// </summary>
        [XmlElement("logo_url")]
        public string LogoUrl { get; set; }
    }
}
