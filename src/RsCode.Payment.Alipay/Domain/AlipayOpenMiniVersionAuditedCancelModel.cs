using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayOpenMiniVersionAuditedCancelModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayOpenMiniVersionAuditedCancelModel : AopObject
    {
        /// <summary>
        /// 小程序版本号
        /// </summary>
        [XmlElement("app_version")]
        public string AppVersion { get; set; }

        /// <summary>
        /// 小程序投放的端参数，例如投放到支付宝钱包是支付宝端。该参数可选，默认支付宝端 com.alipay.alipaywallet:支付宝端
        /// </summary>
        [XmlElement("bundle_id")]
        public string BundleId { get; set; }
    }
}
