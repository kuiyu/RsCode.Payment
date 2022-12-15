using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KbdishPropertyInfo Data Structure.
    /// </summary>
    [Serializable]
    public class KbdishPropertyInfo : AopObject
    {
        /// <summary>
        /// “属性最多可选数”，默认为1，与“属性最少可选数”同时为空或同时非空，不能为0，数值不能大于销售属性值的数量，即property_value_info_list的长度
        /// </summary>
        [XmlElement("max_count_limit")]
        public string MaxCountLimit { get; set; }

        /// <summary>
        /// “属性最少可选数”，默认为1，与“属性最多可选数”同时为空或同时非空，不能为0，数值不能大于“属性最多可选数”
        /// </summary>
        [XmlElement("min_count_limit")]
        public string MinCountLimit { get; set; }

        /// <summary>
        /// 菜品属性名称
        /// </summary>
        [XmlElement("property_name")]
        public string PropertyName { get; set; }

        /// <summary>
        /// 菜品销售属性属性值模型
        /// </summary>
        [XmlArray("property_value_info_list")]
        [XmlArrayItem("kbdish_property_value_info")]
        public List<KbdishPropertyValueInfo> PropertyValueInfoList { get; set; }

        /// <summary>
        /// 菜品属性排序字段，从1一直递增到4
        /// </summary>
        [XmlElement("sort")]
        public string Sort { get; set; }
    }
}
