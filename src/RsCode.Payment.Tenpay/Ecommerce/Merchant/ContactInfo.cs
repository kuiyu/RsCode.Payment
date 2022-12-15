using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.ECommerce.Merchant
{
    /// <summary>
    /// 超级管理员信息
    /// </summary>
  public  class ContactInfo
  {
        /// <summary>
        /// 超级管理员类型
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(2)]
        [JsonPropertyName("contact_type")]
        public string ContactType { get; set; }

        /// <summary>
        /// 超级管理员姓名
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(256)]
        [JsonPropertyName("contact_name")]
        public string ContactName { get; set; }

        /// <summary>
        /// 超级管理员身份证件号码
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(256)]
        [JsonPropertyName("contact_id_card_number")]
        public string ContactIdCardNumber { get; set; }


        /// <summary>
        /// 超级管理员手机
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(256)]
        [JsonPropertyName("mobile_phone")]
        public string MobilePhone { get; set; }

        /// <summary>
        /// 超级管理员邮箱
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(256)]
        [JsonPropertyName("contact_email")]
        public string BankBranchId { get; set; }
 
    }
}
