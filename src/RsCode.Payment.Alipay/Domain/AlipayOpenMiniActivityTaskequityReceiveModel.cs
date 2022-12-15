using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayOpenMiniActivityTaskequityReceiveModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayOpenMiniActivityTaskequityReceiveModel : AopObject
    {
        /// <summary>
        /// 任务完成的业务时间，用于做权益发放的原始时间戳，将以任务完成时间为准发放权益
        /// </summary>
        [XmlElement("biz_time")]
        public string BizTime { get; set; }

        /// <summary>
        /// 蚂蚁统一会员ID
        /// </summary>
        [XmlElement("user_id")]
        public string UserId { get; set; }
    }
}
