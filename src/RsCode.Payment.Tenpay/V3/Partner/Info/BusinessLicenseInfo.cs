using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Partner
{
    /// <summary>
    /// 营业执照/登记证书信息
    /// </summary>
    public class BusinessLicenseInfo
    {
        /// <summary>
        /// 营业执照照片
        /// </summary>
        //[MinLength(1)]
        //[MaxLength(255)]
        [JsonPropertyName("license_copy")]
        public string LicenesCopy { get; set; }
        /// <summary>
        /// 注册号/统一社会信用代码
        /// </summary>
        //[MinLength(1)]
        //[MaxLength(32)]
        [JsonPropertyName("license_number")]
        public string LicenseNumber { get; set; }
        /// <summary>
        /// 商户名称
        /// </summary>
        //[MinLength(1)]
        //[MaxLength(128)]
        [JsonPropertyName("merchant_name")]
        public string MerchantName { get; set; }
        /// <summary>
        /// 经营者/法定代表人姓名
        /// </summary>
        //[MinLength(1)]
        //[MaxLength(64)]
        [JsonPropertyName("legal_person")]
        public string LegalPerson { get; set; }
      

    }
}
