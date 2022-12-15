using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayInsSceneInsserviceprodCertifyModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayInsSceneInsserviceprodCertifyModel : AopObject
    {
        /// <summary>
        /// 扩展信息，JSON字符串格式
        /// </summary>
        [XmlElement("biz_data")]
        public string BizData { get; set; }

        /// <summary>
        /// 唯一订单号
        /// </summary>
        [XmlElement("order_no")]
        public string OrderNo { get; set; }

        /// <summary>
        /// 蚂蚁统一会员ID
        /// </summary>
        [XmlElement("user_id")]
        public string UserId { get; set; }
    }
}
