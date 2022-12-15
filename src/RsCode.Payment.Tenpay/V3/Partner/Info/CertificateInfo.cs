using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Partner
{
    /// <summary>
    /// 登记证书
    /// </summary>
    public class CertificateInfo
    {
        /// <summary>
        /// 登记证书照片
        /// </summary>
        [JsonPropertyName("cert_copy")]
        public string CertCopy { get; set; }
        /// <summary>
        /// 登记证书类型
        /// </summary>      
        [JsonPropertyName("cert_type")]
        public string CertType { get; set; }
        /// <summary>
        /// 证书号
        /// </summary>      
        [JsonPropertyName("cert_number")]
        public string CertNumber { get; set; }
        /// <summary>
        /// 商户名称
        /// </summary>       
        [JsonPropertyName("merchant_name")]
        public string MerchatName { get; set; }
        /// <summary>
        /// 注册地址
        /// </summary>
        [JsonPropertyName("company_address")]
        public string CompanyAddress { get; set; }
        /// <summary>
        /// 法人姓名
        /// </summary>       
        [JsonPropertyName("legal_person")] 
        public string LegalPerson { get; set; }
        /// <summary>
        /// 有效期限开始日期
        /// </summary>      
        [JsonPropertyName("period_begin")]
        public string PeriodBegin { get; set; }
        /// <summary>
        /// 有效期限结束日期
        /// </summary>
        [JsonPropertyName("period_end")]
        public string PeriodEnd { get; set; }
    }
}
