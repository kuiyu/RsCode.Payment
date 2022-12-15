using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayOpenMiniVersionAuditCancelModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayOpenMiniVersionAuditCancelModel : AopObject
    {
        /// <summary>
        /// 小程序版本号, 可不选, 默认撤消正在审核中的版本
        /// </summary>
        [XmlElement("app_version")]
        public string AppVersion { get; set; }

        /// <summary>
        /// 端参数，可不选，默认支付宝端(com.alipay.alipaywallet:支付宝端)
        /// </summary>
        [XmlElement("bundle_id")]
        public string BundleId { get; set; }
    }
}
