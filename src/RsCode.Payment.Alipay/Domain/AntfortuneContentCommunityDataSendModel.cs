using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AntfortuneContentCommunityDataSendModel Data Structure.
    /// </summary>
    [Serializable]
    public class AntfortuneContentCommunityDataSendModel : AopObject
    {
        /// <summary>
        /// 内容流入格式。json格式 sourceId 数据id 、creator 创建者、gmtModified 修改时间、type类型、title标题  gmtCreate创建时间、url地址、operator操作者、duration时长、id 数据id、status 状态
        /// </summary>
        [XmlElement("content")]
        public string Content { get; set; }

        /// <summary>
        /// 来源id
        /// </summary>
        [XmlElement("source_id")]
        public string SourceId { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [XmlElement("soure_type")]
        public string SoureType { get; set; }
    }
}
