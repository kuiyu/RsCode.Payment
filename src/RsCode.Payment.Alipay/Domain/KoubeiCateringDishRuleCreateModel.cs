using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiCateringDishRuleCreateModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiCateringDishRuleCreateModel : AopObject
    {
        /// <summary>
        /// 菜品规则通用模型
        /// </summary>
        [XmlElement("kb_dish_rule_info")]
        public KbdishRuleInfo KbDishRuleInfo { get; set; }
    }
}
