using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// TextInstance Data Structure.
    /// </summary>
    [Serializable]
    public class TextInstance : AopObject
    {
        /// <summary>
        /// 元素C端渲染关联位置key值
        /// </summary>
        [XmlElement("key")]
        public string Key { get; set; }

        /// <summary>
        /// 物料元素类型，TITLE-标题；DESC-描述
        /// </summary>
        [XmlElement("material_type")]
        public string MaterialType { get; set; }

        /// <summary>
        /// 标题/描述文本值
        /// </summary>
        [XmlElement("value")]
        public string Value { get; set; }
    }
}
