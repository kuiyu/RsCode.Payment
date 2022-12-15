using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Partner
{
    public class UboInfo
    {
        /// <summary>
        /// 证件类型
        /// IDENTIFICATION_TYPE_IDCARD：中国大陆居民-身份证
        ///IDENTIFICATION_TYPE_OVERSEA_PASSPORT：其他国家或地区居民-护照
        ///IDENTIFICATION_TYPE_HONGKONG_PASSPORT：中国香港居民-来往内地通行证
        ///IDENTIFICATION_TYPE_MACAO_PASSPORT：中国澳门居民-来往内地通行证
        ///IDENTIFICATION_TYPE_TAIWAN_PASSPORT：中国台湾居民-来往大陆通行证
        /// </summary>
        
        [JsonPropertyName("id_type")]
        public string IdType { get; set; }

        /// <summary>
        /// 身份证人像面照片
        /// </summary>
      
        [JsonPropertyName("id_card_copy")]
        public string IdCardCopy { get; set; }
        /// <summary>
        /// 身份证国徽面照片
        /// </summary>
       
        [JsonPropertyName("id_card_national")]
        public string IdCardNational { get; set; }
        /// <summary>
        /// 身份证姓名	
        /// </summary>
      
        [JsonPropertyName("name")]
        public string Name { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
       
        [JsonPropertyName("id_number")]
        public string IdNumber { get; set; }
        /// <summary>
        /// 证有效期开始时间
        /// </summary>
        
        [JsonPropertyName("id_period_begin")]
        public string BeginDate { get; set; }
        /// <summary>
        /// 身份证有效期结束时间
        /// </summary>
        
        [JsonPropertyName("id_period_end")]
        public string EndDate { get; set; }
    }
}
