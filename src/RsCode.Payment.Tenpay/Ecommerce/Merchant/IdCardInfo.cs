using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.ECommerce.Merchant
{
    /// <summary>
    /// 经营者/法人身份证信息
    /// </summary>
    public class IdCardInfo
    {
        /// <summary>
        /// 身份证人像面照片
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(256)]
        [JsonPropertyName("id_card_copy")]
        public string IdCardCopy { get; set; }
        /// <summary>
        /// 身份证国徽面照片
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(256)]
        [JsonPropertyName("id_card_national")]
        public string IdCardNational{ get; set; }
        /// <summary>
        /// 身份证姓名	
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(256)]
        [JsonPropertyName("id_card_name")]
        public string IdCardName { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        [Required]
        [MinLength(15)]
        [MaxLength(18)]
        [JsonPropertyName("id_card_number")]
        public string IdCardNumber{ get; set; }
        /// <summary>
        /// 身份证有效期限
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(128)]
        [JsonPropertyName("id_card_valid_time")]
        public string IdCardValidTime { get; set; }
    }
}
