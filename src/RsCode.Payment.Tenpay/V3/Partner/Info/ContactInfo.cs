using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Partner
{
    /// <summary>
    /// 超级管理员信息
    /// </summary>
    public  class ContactInfo
  {
        /// <summary>
        /// 超级管理员姓名
        /// </summary>
        //[MinLength(2)]
        //[MaxLength(2048)]
        [JsonPropertyName("contact_name")]
        public string ContactName { get; set; }

        /// <summary>
        /// 超级管理员身份证件号码
        /// </summary> 
        //[MinLength(1)]
        //[MaxLength(2048)]
        [JsonPropertyName("contact_id_number")]
        public string ContactIdCardNumber { get; set; }
        /// <summary>
        /// 超级管理员微信openid
        /// </summary>
        [JsonPropertyName("openid")]
        public string OpenId { get; set; }


        /// <summary>
        /// 超级管理员手机
        /// </summary>
        //[Required]
        //[MinLength(1)]
        //[MaxLength(2048)]
        [JsonPropertyName("mobile_phone")]
        public string MobilePhone { get; set; }
         


        /// <summary>
        /// 超级管理员邮箱
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(2048)]
        [JsonPropertyName("contact_email")]
        public string Email { get; set; }
 
    }
}
