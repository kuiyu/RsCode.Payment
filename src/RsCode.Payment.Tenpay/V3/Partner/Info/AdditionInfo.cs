using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Partner
{
    /// <summary>
    /// 补充材料
    /// </summary>
    public class AdditionInfo
    {
        /// <summary>
        /// 法人开户承诺函
        /// </summary>
        [JsonPropertyName("legal_person_commitment")]
        public string LegalPersonCommitment { get; set; }
        /// <summary>
        /// 法人开户意愿视频
        /// </summary>
        [JsonPropertyName("legal_person_video")]
        public string LegalPersonVideo { get; set; }
        /// <summary>
        /// 补充材料
        /// </summary>
        [JsonPropertyName("business_addition_pics")]
        public string[] BusinessAdditionPics { get; set; }
        /// <summary>
        /// 补充说明
        /// </summary>
        [JsonPropertyName("business_addition_msg")]
        public string  BusinessAdditionMsg { get; set; }
    }
}
