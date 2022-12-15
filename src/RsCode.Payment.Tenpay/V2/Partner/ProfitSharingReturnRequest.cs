using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace RsCode.Payment.Tenpay.V2.Partner
{
    /// <summary>
    /// 分账回退
    /// 此功能需要接收方在商户平台-交易中心-分账-分账接收设置下，开启同意分账回退后，才能使用。
    /// https://pay.weixin.qq.com/wiki/doc/api/allocation_sl.php?chapter=25_5&index=6
    /// </summary>
    public class ProfitSharingReturnRequest : WxPayData, TenpayBaseRequest
    {
        #region 参数
        /// <summary>
        /// 微信支付分配的服务商商户号
        /// </summary>
        [Required]
        [JsonPropertyName("mch_id")]
        [XmlElement("mch_id")]
        public string MchId { get; set; }
        /// <summary>
        /// 微信支付分配的子商户号，即分账的出资商户号
        /// </summary>
        [JsonPropertyName("sub_mch_id")]
        [XmlElement("sub_mch_id")]
        public string SubMchId { get; set; }
      
        /// <summary>
        /// 微信分配的服务商appid
        /// </summary>
        [Required]
        [JsonPropertyName("appid")]
        [XmlElement("appid")]
        public string AppId { get; set; }

        /// <summary>
        /// 微信分配的子商户公众账号ID
        /// </summary>
        [JsonPropertyName("sub_appid")]
        [XmlElement("sub_appid")]
        public string SubAppId { get; set; }
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
        [JsonPropertyName("order_id")]
        [XmlElement("order_id")]
        public string TransactionId { get; set; }
        /// <summary>
        /// 商户分账单号
        /// </summary>
        [Required]
        [JsonPropertyName("out_order_no")]
        [XmlElement("out_order_no")]
        public string OutOrderNo { get; set; }

        /// <summary>
        /// 回退单号是商户在自己后台生成的一个新的回退单号，在商户后台唯一
        /// </summary>
        [JsonPropertyName("out_return_no")]
        [XmlElement("out_return_no")]
        public string OutReturnNo { get; set; }

        /// <summary>
        /// 回退方类型
        /// MERCHANT_ID：商户号（mch_id或者sub_mch_id）
        ///暂时只支持从商户接收方回退分账金额
        /// </summary>
        [JsonPropertyName("return_account_type")]
        [XmlElement("return_account_type")]
        public string ReturnAccountType { get; set; }
        /// <summary>
        /// 需要从分账接收方回退的金额，单位为分，只能为整数，不能超过原始分账单分出给该接收方的金额
        /// </summary>
        [JsonPropertyName("return_amount")]
        [XmlElement("return_amount")]
        public int ReturnAmount { get; set; }
        /// <summary>
        /// 分账回退的原因描述
        /// </summary>
        [Required]
        [JsonPropertyName("description")]
        [XmlElement("description")]
        public string Description { get; set; }


        #endregion

        public string GetApiUrl()
        {
            return "https://api.mch.weixin.qq.com/secapi/pay/profitsharingreturn";
        }

        public string RequestMethod()
        {
            return "POST";
        }
    }
}
