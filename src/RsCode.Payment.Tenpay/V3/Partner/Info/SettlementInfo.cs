using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Partner
{ 
    /// <summary>
    /// 结算规则
    /// </summary>
public class SettlementInfo
    {
        /// <summary>
        /// 入驻结算规则ID
        /// </summary>
        [JsonPropertyName("settlement_id")]
        public string   SettlementId { get; set; }
        /// <summary>
        /// 所属行业
        /// </summary>
        [JsonPropertyName("qualification_type")]
        public string QualificationType { get; set; }
        /// <summary>
        /// 特殊资质图片
        /// </summary>
        [JsonPropertyName("qualifications")]
        public string[] Qualifications { get; set; }
        /// <summary>
        /// 优惠费率活动ID
        /// </summary>
        [JsonPropertyName("activities_id")]
        public string ActivitiesId { get; set; }
        /// <summary>
        /// 优惠费率活动值
        /// </summary>
        [JsonPropertyName("activities_rate")]
        public string ActivitiesRate { get; set; }
        /// <summary>
        /// 优惠费率活动补充材料
        /// </summary>
        [JsonPropertyName("activities_additions")]
        public string[] ActivitiesAdditions { get; set; }

    }
}
