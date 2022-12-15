using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayDataDataserviceAdOnlineModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayDataDataserviceAdOnlineModel : AopObject
    {
        /// <summary>
        /// 灯火平台提供给外部系统的访问token
        /// </summary>
        [XmlElement("biz_token")]
        public string BizToken { get; set; }

        /// <summary>
        /// 操作的广告层级类型，如计划(plan)，单元(group)，创意 （creative）
        /// </summary>
        [XmlElement("op_type")]
        public string OpType { get; set; }

        /// <summary>
        /// 外部平台导入广告库后，广告投放层级的对应的外部资源ID
        /// </summary>
        [XmlArray("outer_id_list")]
        [XmlArrayItem("string")]
        public List<string> OuterIdList { get; set; }
    }
}
