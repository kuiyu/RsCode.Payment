using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayOpenMiniInnerversionGrayPublishModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayOpenMiniInnerversionGrayPublishModel : AopObject
    {
        /// <summary>
        /// 业务来源
        /// </summary>
        [XmlElement("app_origin")]
        public string AppOrigin { get; set; }

        /// <summary>
        /// 小程序版本
        /// </summary>
        [XmlElement("app_version")]
        public string AppVersion { get; set; }

        /// <summary>
        /// 端信息
        /// </summary>
        [XmlElement("bundle_id")]
        public string BundleId { get; set; }

        /// <summary>
        /// 灰度值
        /// </summary>
        [XmlElement("gray_strategy")]
        public string GrayStrategy { get; set; }

        /// <summary>
        /// 小程序ID
        /// </summary>
        [XmlElement("mini_app_id")]
        public string MiniAppId { get; set; }

        /// <summary>
        /// 小程序所属PID
        /// </summary>
        [XmlElement("pid")]
        public string Pid { get; set; }
    }
}
