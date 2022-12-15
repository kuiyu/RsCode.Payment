using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayOpenMiniInnerclientinfoCreateModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayOpenMiniInnerclientinfoCreateModel : AopObject
    {
        /// <summary>
        /// 端ID，不可重复，接入方需要和小程序平台约定格式
        /// </summary>
        [XmlElement("bundle_id")]
        public string BundleId { get; set; }

        /// <summary>
        /// 端名称
        /// </summary>
        [XmlElement("bundle_name")]
        public string BundleName { get; set; }

        /// <summary>
        /// 端信息缓存前缀，不可重复，接入方需要和小程序平台约定前后缀信息
        /// </summary>
        [XmlElement("bundle_prefix")]
        public string BundlePrefix { get; set; }
    }
}
