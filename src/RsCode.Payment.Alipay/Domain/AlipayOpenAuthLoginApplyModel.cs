using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayOpenAuthLoginApplyModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayOpenAuthLoginApplyModel : AopObject
    {
        /// <summary>
        /// 当前登录调用方平台的开发者登录渠道，如阿里云允许用阿里云账号、淘宝账号、支付宝账号、1688账号、钉钉账号、新浪账号登录，可选值有：aliyun、taobao、alipay、dingtalk、1688、sina
        /// </summary>
        [XmlElement("login_channel")]
        public string LoginChannel { get; set; }

        /// <summary>
        /// 第三方登录来源
        /// </summary>
        [XmlElement("sign_from")]
        public string SignFrom { get; set; }

        /// <summary>
        /// 信登后跳转的目标地址
        /// </summary>
        [XmlElement("target_url")]
        public string TargetUrl { get; set; }
    }
}
