using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Partner
{
    public class IdDocInfo
    {
        //[Required]
        //[MinLength(1)]
        //[MaxLength(256)]
        [JsonPropertyName("id_doc_copy")]
        public string IdDocCopy { get; set; }

        /// <summary>
        /// 证件姓名
        /// </summary>
        //[Required]
        //[MinLength(1)]
        //[MaxLength(128)]
        [JsonPropertyName("id_doc_name")]
        public string IdDocName { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        //[Required]
        //[MinLength(1)]
        //[MaxLength(128)]
        [JsonPropertyName("id_doc_number")]
        public string IdDocNumber { get; set; }


        /// <summary>
        /// 证件结束日期
        /// </summary>
        //[Required]
        //[MinLength(1)]
        //[MaxLength(128)]
        [JsonPropertyName("doc_period_begin")]
        public string StartDate { get; set; }

        /// <summary>
        /// 证件结束日期
        /// </summary>
        //[Required]
        //[MinLength(1)]
        //[MaxLength(128)]
        [JsonPropertyName("doc_period_end")]
        public string EndDate { get; set; }

        
    }
}
