using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.ECommerce.Merchant
{
    /// <summary>
    ///  组织机构代码证信息
    /// </summary>
    public class OrganizationCretInfo
    {
        /// <summary>
        /// 组织机构代码证照片
        /// </summary>
        [Required]
        [JsonPropertyName("organization_copy")]
        public string OrganizationCopy { get; set; }

        /// <summary>
        /// 组织机构代码
        /// </summary>
        [Required]
        [JsonPropertyName("organization_number")]
        public string OrganizationNumber { get; set; }

        /// <summary>
        /// 组织机构代码有效期限
        /// </summary>
        [Required] 
        [JsonPropertyName("organization_time")] 
        public string OrganizationTime { get; set; }

        /// <summary>
        /// 经营者/法人证件类型
        /// </summary>
        [JsonPropertyName("id_doc_type")] 
        public string IdDocType { get; set; }
    }
}
