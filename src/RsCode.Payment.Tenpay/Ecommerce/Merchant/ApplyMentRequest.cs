using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.ECommerce.Merchant
{
    /// <summary>
    /// 二级商户进件
    /// 电商平台，可使用该接口，帮助其二级商户进件成为微信支付商户
    /// https://pay.weixin.qq.com/wiki/doc/apiv3/wxpay/ecommerce/applyments/chapter3_1.shtml
    /// </summary>
    public class ApplyMentRequest
    {
        /// <summary>
        /// 业务申请编号
        /// </summary>
        [Required] 
        [MinLength(1)]
        [MaxLength(124)]
        [JsonPropertyName("out_request_no")]
        public string OutRequestNo { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(4)]
        [JsonPropertyName("organization_type")]
        public string OrganizationType { get; set; }
        /// <summary>
        /// 营业执照/登记证书信息
        /// </summary>
        [JsonPropertyName("business_license_info")]
        public BusinessLicenseInfo BusinessLicenesInfo { get; set; }
        /// <summary>
        /// 组织机构代码证信息
        /// </summary>
        [JsonPropertyName("organization_cert_info")]
        public OrganizationCretInfo OrganizationCertInfo { get; set; }

        /// <summary>
        /// 经营者/法人证件类型
        /// </summary> 
        [JsonPropertyName("id_doc_type")]
        public string IdDocType { get; set; }

        /// <summary>
        /// 经营者/法人身份证信息
        /// </summary>
        [JsonPropertyName("id_card_info")]
        public IdCardInfo IdCardInfo { get; set; }

        /// <summary>
        /// -经营者/法人其他类型证件信息
        /// </summary>
        [JsonPropertyName("id_doc_info")]
        public IdDocInfo IdDocInfo { get; set; }

        /// <summary>
        /// 是否填写结算银行账户
        /// </summary>
        [JsonPropertyName("need_account_info")]
        public bool NeedAccountInfo { get; set; }
        /// <summary>
        /// -结算银行账户
        /// </summary>
        [JsonPropertyName("account_info")]
        public AccountInfo AccountInfo { get; set; }
        /// <summary>
        /// 超级管理员信息
        /// </summary>
        [Required]
        [JsonPropertyName("contact_info")]
        public ContactInfo ContactInfo { get; set; }

        /// <summary>
        /// 店铺信息
        /// </summary>
        [Required]
        [JsonPropertyName("sales_scene_info")]
        public SalesSceneInfo SaleSceneInfo { get; set; }
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
        [JsonPropertyName("business_addition_pics")]
        public string BusinessAdditionPics { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        [JsonPropertyName("business_addition_desc")]
        public string BusinessAdditionDesc { get; set; }
    }

      
}
