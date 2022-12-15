using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiServindustryExerciseMemberphoneSyncModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiServindustryExerciseMemberphoneSyncModel : AopObject
    {
        /// <summary>
        /// 存量健身会员手机号
        /// </summary>
        [XmlArray("phone_list")]
        [XmlArrayItem("string")]
        public List<string> PhoneList { get; set; }

        /// <summary>
        /// 请求ID
        /// </summary>
        [XmlElement("request_id")]
        public string RequestId { get; set; }
    }
}
