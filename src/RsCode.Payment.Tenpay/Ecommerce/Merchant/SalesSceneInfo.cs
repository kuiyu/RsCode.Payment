using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.ECommerce.Merchant
{
    public  class SalesSceneInfo
    {
        /// <summary>
        /// 店铺名称
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(256)]
        [JsonPropertyName("store_name")]
        public string StoreName { get; set; }

        /// <summary>
        /// 店铺链接
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(1024)]
        [JsonPropertyName("store_url")]
        public string StoreUrl { get; set; }

        /// <summary>
        /// 店铺二维码
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(256)]
        [JsonPropertyName("store_qr_code")]
        public string StoreQrcode { get; set; }


        /// <summary>
        /// 小程序AppID
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(256)]
        [JsonPropertyName("mini_program_sub_appid")]
        public string MiniProgramSubAppId { get; set; }

        /// <summary>
        /// 商户简称
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(64)]
        [JsonPropertyName("merchant_shortname")]
        public string MerchantShortName { get; set; }

        /// <summary>
        /// 特殊资质
        /// </summary>         
        [JsonPropertyName("qualifications")]
        public string Qualifications { get; set; }

        /// <summary>
        /// 补充材料
        /// </summary>
        [Required]
        [JsonPropertyName("business_addition_pics")]
        public string BusinessAdditionPics { get; set; }


        /// <summary>
        /// 补充说明
        /// </summary>        
        [JsonPropertyName("business_addition_desc")]
        public string BusinessAdditionDesc { get; set; }

      
    }
}
