using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Partner
{
    public class SubjectInfo
    {
        /// <summary>
        /// 主体类型
        /// SUBJECT_TYPE_INDIVIDUAL（个体户）
        /// SUBJECT_TYPE_ENTERPRISE（企业）
        /// SUBJECT_TYPE_INSTITUTIONS（党政、机关及事业单位）
        /// SUBJECT_TYPE_OTHERS（其他组织）
        /// 参考https://kf.qq.com/faq/180910IBZVnQ180910naQ77b.html
        /// </summary>
        [JsonPropertyName("subject_type")]
        public string SubjectType { get; set; }

        /// <summary>
        /// 营业执照
        /// </summary>
        [JsonPropertyName("business_license_info")]
        public BusinessLicenseInfo BusinessLicenseInfo { get; set; }
        /// <summary>
        /// 登记证书
        /// </summary>
        [JsonPropertyName("certificate_info")]
        public CertificateInfo CertificateInfo { get; set; }

        /// <summary>
        /// 组织机构代码证
        /// </summary>
        [JsonPropertyName("organization_info")]
        public OrganizationInfo OrganizationInfo { get; set; }

        /// <summary>
        /// 单位证明函照片
        /// </summary>        
        [JsonPropertyName("certificate_letter_copy")]
        public string CertificateLetterCopy { get; set; }
        /// <summary>
        /// 经营者/法人身份证件
        /// </summary>
        [JsonPropertyName("identity_info")]
        public IdentityInfo IdentityInfo { get; set; }

        /// <summary>
        /// 最终受益人信息(UBO]
        /// </summary>
        [JsonPropertyName("ubo_info")]
        public UboInfo UboInfo { get; set; }
    }
}
