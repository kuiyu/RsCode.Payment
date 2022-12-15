using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Partner
{
    /// <summary>
    ///  组织机构代码证信息
    /// </summary>
    public class OrganizationInfo
    {
        /// <summary>
        /// 组织机构代码证照片
        /// </summary>      
        [JsonPropertyName("organization_copy")]
        public string OrganizationCopy { get; set; }

        /// <summary>
        /// 组织机构代码
        /// </summary>        
        [JsonPropertyName("organization_code")]
        public string OrganizationNumber { get; set; }

        /// <summary>
        /// 组织机构代码证有效期开始日期
        /// </summary>

        [JsonPropertyName("org_period_begin")]
        public string OrganizationStartTime { get; set; }

        /// <summary>
        ///组织机构代码证有效期结束日期
        /// </summary>
        [JsonPropertyName("org_period_end")]
        public string OrganizationEndTime { get; set; }

    }
}
