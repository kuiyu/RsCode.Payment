using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Partner
{
    /// <summary>
    /// 经营者/法人身份证信息
    /// </summary>
    public class IdCardInfo
    {
        /// <summary>
        /// 身份证人像面照片
        /// </summary>
        //[Required]
        //[MinLength(1)]
        //[MaxLength(256)]
        [JsonPropertyName("id_card_copy")]
        public string IdCardCopy { get; set; }
        /// <summary>
        /// 身份证国徽面照片
        /// </summary>
        //[Required]
        //[MinLength(1)]
        //[MaxLength(256)]
        [JsonPropertyName("id_card_national")]
        public string IdCardNational{ get; set; }
        /// <summary>
        /// 身份证姓名	
        /// </summary>
        //[Required]
        //[MinLength(1)]
        //[MaxLength(256)]
        [JsonPropertyName("id_card_name")]
        public string IdCardName { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        //[Required]
        //[MinLength(15)]
        //[MaxLength(18)]
        [JsonPropertyName("id_card_number")]
        public string IdCardNumber{ get; set; }
        /// <summary>
        /// 身份证有效期开始时间
        /// </summary>
        //[Required]
        //[MinLength(1)]
        //[MaxLength(128)]
        [JsonPropertyName("card_period_begin")]
        public string BeginDate { get; set; }
        /// <summary>
        /// 身份证有效期结束时间
        /// </summary>
        //[Required]
        //[MinLength(1)]
        //[MaxLength(128)]
        [JsonPropertyName("card_period_end")]
        public string EndDate { get; set; }
    }
}
