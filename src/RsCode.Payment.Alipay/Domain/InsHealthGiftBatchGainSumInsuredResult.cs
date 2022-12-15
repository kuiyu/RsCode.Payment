using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// InsHealthGiftBatchGainSumInsuredResult Data Structure.
    /// </summary>
    [Serializable]
    public class InsHealthGiftBatchGainSumInsuredResult : AopObject
    {
        /// <summary>
        /// 是否准入。true标识准入，false标识不准入
        /// </summary>
        [XmlElement("admit")]
        public bool Admit { get; set; }

        /// <summary>
        /// 赠险业务标志  HEALTH_BEAN_SIMPLE_UPGRADE 免费医疗金、HEALTH_GUARDIAN_GOLD 守护金、HEALTH_DSDB_NEW_OUTPATIENT 多收多宝新门诊
        /// </summary>
        [XmlElement("biz_type")]
        public string BizType { get; set; }

        /// <summary>
        /// 本次可领取保额
        /// </summary>
        [XmlElement("delta_sum_insured")]
        public string DeltaSumInsured { get; set; }

        /// <summary>
        /// 赠险产品组类型。 赠险通用产品组 COMMON_GIFT_INSURANCE_PRODUCT_GROUP、 C端赠险产品组 CUSTOMER_GIFT_INSURANCE_PRODUCT_GROUP、 B端赠险产品组 BUSINESS_GIFT_INSURANCE_PRODUCT_GROUP、 相互保赠险产品组 XHB_GIFT_INSURANCE_PRODUCT_GROUP
        /// </summary>
        [XmlElement("product_group_biz_type")]
        public string ProductGroupBizType { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        [XmlElement("source")]
        public string Source { get; set; }
    }
}
