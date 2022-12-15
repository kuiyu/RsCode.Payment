using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayTradePeerpayprodRelationCreateModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayTradePeerpayprodRelationCreateModel : AopObject
    {
        /// <summary>
        /// 支付宝userId，可以为空，用于传递被开通人
        /// </summary>
        [XmlElement("aliapy_related_id")]
        public string AliapyRelatedId { get; set; }

        /// <summary>
        /// 支付宝userId，可以为空，用于开通人
        /// </summary>
        [XmlElement("alipay_user_id")]
        public string AlipayUserId { get; set; }

        /// <summary>
        /// 开通人与被开通人的关系标签，user_id,related_id关系
        /// </summary>
        [XmlElement("relation_name")]
        public string RelationName { get; set; }

        /// <summary>
        /// 开通人和被开通人的关系类型
        /// </summary>
        [XmlElement("relation_type")]
        public string RelationType { get; set; }

        /// <summary>
        /// 淘宝userId，可以为空，用于传递被开通人
        /// </summary>
        [XmlElement("taobao_related_id")]
        public string TaobaoRelatedId { get; set; }

        /// <summary>
        /// 淘宝用户userId,可以传递空，用于开通人
        /// </summary>
        [XmlElement("taobao_user_id")]
        public string TaobaoUserId { get; set; }
    }
}
