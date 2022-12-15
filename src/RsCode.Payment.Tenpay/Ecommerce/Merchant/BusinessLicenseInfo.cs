using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.ECommerce.Merchant
{
    /// <summary>
    /// 营业执照/登记证书信息
    /// </summary>
    public class BusinessLicenseInfo
    {
        /// <summary>
        /// 证件扫描件
        /// </summary>
        [MinLength(1)]
        [MaxLength(256)]
        [JsonPropertyName("business_license_copy")]
        public string BusinessLicenesCopy { get; set; }
        /// <summary>
        /// 证件注册号
        /// </summary>
        [MinLength(15)]
        [MaxLength(18)]
        [JsonPropertyName("business_license_number")]
        public string BusinessLicenseNumber { get; set; }
        /// <summary>
        /// 商户名称
        /// </summary>
        [MinLength(1)]
        [MaxLength(128)]
        [JsonPropertyName("merchant_name")]
        public string MerchantName { get; set; }
        /// <summary>
        /// 经营者/法定代表人姓名
        /// </summary>
        [MinLength(1)]
        [MaxLength(128)]
        [JsonPropertyName("legal_person")]
        public string LegalPerson { get; set; }
        /// <summary>
        /// 注册地址
        /// </summary>
        [MinLength(1)]
        [MaxLength(128)]
        [JsonPropertyName("company_address")]
        public string CompanyAddress { get; set; }
        /// <summary>
        /// 营业期限
        /// </summary>
        [MinLength(1)]
        [MaxLength(256)]
        [JsonPropertyName("business_time")]
        public string BusinessTime { get; set; }


    }
}
