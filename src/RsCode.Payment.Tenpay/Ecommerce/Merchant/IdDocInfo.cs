using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.ECommerce.Merchant
{
    public class IdDocInfo
    {
        /// <summary>
        /// 证件姓名
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(128)]
        [JsonPropertyName("id_doc_name")]
        public string IdDocName { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(128)]
        [JsonPropertyName("id_doc_number")]
        public string IdDocNumber { get; set; }

        /// <summary>
        /// 证件照片
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(256)]
        [JsonPropertyName("id_doc_copy")]
        public string IdDocCopy { get; set; }


        /// <summary>
        /// 证件结束日期
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(128)]
        [JsonPropertyName("doc_period_end")]
        public string DocPeriodEnd { get; set; }

        /// <summary>
        /// 是否填写结算银行账户
        /// </summary>
        [Required]
        [JsonPropertyName("need_account_info")]
        public bool NeedAccountInfo { get; set; }
    }
}
