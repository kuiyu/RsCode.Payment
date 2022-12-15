﻿/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 协议:MIT License 2.0 
 * 作者:河南软商网络科技有限公司 
 * 项目己托管于  
 * github
   https://github.com/kuiyu/RsCode.Payment.git
 */
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace RsCode.Payment.Tenpay.V2.Partner
{
    /// <summary>
    /// 完结分账
    /// https://pay.weixin.qq.com/wiki/doc/api/allocation_sl.php?chapter=25_5&index=6
    /// </summary>
    public class ProfitSharingFinishRequest : WxPayData, TenpayBaseRequest
    {
        #region 参数
        /// <summary>
        /// 微信支付分配的服务商商户号
        /// </summary>
        [Required] [JsonPropertyName("mch_id")]
        [XmlElement("mch_id")]
        public string MchId { get; set; }
        /// <summary>
        /// 微信支付分配的子商户号，即分账的出资商户号
        /// </summary>
        [JsonPropertyName("sub_mch_id")]
        [XmlElement("sub_mch_id")] 
        public string SubMchId { get; set; }
        /// <summary>
        /// 品牌主商户号
        /// </summary>
        [JsonPropertyName("brand_mch_id")]
        [XmlElement("brand_mch_id")] 
        public string BrandMchId { get; set; }
        /// <summary>
        /// 微信分配的服务商appid
        /// </summary>
        [Required]
        [JsonPropertyName("appid")]
        [XmlElement("appid")] 
        public string AppId { get; set; }
        [Required]
        [JsonPropertyName("nonce_str")]
        [XmlElement("nonce_str")]
        public string NonceStr { get { return TenpayTool.GetNonceStr(); } } 
        
        /// <summary>
        /// 签名
        /// </summary>
        [Required]
        [JsonPropertyName("sign")]
        [XmlElement("sign")]
        public string Sign { get; set; }

        /// <summary>
        /// 签名类型，目前只支持HMAC-SHA256
        /// </summary>
        [Required]
        [JsonPropertyName("sign_type")]
        [XmlElement("sign_type")]
        public string SignType { get; set; } = "HMAC-SHA256";

        /// <summary>
        /// 微信订单号
        /// </summary>
        [Required]
        [JsonPropertyName("transaction_id")]
        [XmlElement("transaction_id")]
        public string TransactionId { get; set; }
        /// <summary>
        /// 商户分账单号
        /// </summary>
        [Required]
        [JsonPropertyName("out_order_no")]
        [XmlElement("out_order_no")]
        public string OutOrderNo { get; set; }
        /// <summary>
        /// 分账完结的原因描述
        /// </summary>
        [Required]
        [JsonPropertyName("description")]
        [XmlElement("description")]
        public string Description { get; set; } = "分账已完成";


        #endregion
        public string GetApiUrl()
        {
            return "https://api.mch.weixin.qq.com/secapi/pay/profitsharingfinish";
        }

        public string RequestMethod()
        {
            return "POST";
        }
    }
}
