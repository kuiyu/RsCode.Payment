/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace RsCode.Payment.Tenpay.V2.Partner
{
    /// <summary>
    /// 删除分账接收方
    /// https://pay.weixin.qq.com/wiki/doc/api/allocation_sl.php?chapter=25_4&index=5
    /// </summary>
    public class ProfitSharingReceiverRemoveRequest: WxPayData, TenpayBaseRequest
    {
        #region 参数
        /// <summary>
        /// 微信支付分配的服务商商户号
        /// </summary>

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
        /// 品牌主商户号
        /// </summary>
        [JsonPropertyName("brand_mch_id")]
        [XmlElement("brand_mch_id")]
        public string BrandMchId { get; set; }
        /// <summary>
        /// 微信分配的服务商appid
        /// </summary>

        [JsonPropertyName("appid")]
        [XmlElement("appid")]
        public string AppId { get; set; }
        /// <summary>
        /// 微信分配的子商户
        /// </summary>
        [JsonPropertyName("sub_appid")]
        [XmlElement("sub_appid")]
        public string SubAppId { get; set; }

        [JsonPropertyName("nonce_str")]
        [XmlElement("nonce_str")]
        public string NonceStr { get { return TenpayTool.GetNonceStr(); } }

        /// <summary>
        /// 签名
        /// </summary>

        [JsonPropertyName("sign")]
        [XmlElement("sign")]
        public string Sign { get; set; }

        /// <summary>
        /// 签名类型，目前只支持HMAC-SHA256
        /// </summary>

        [JsonPropertyName("sign_type")]
        [XmlElement("sign_type")]
        public string SignType { get; set; } = "HMAC-SHA256";

        /// <summary>
        /// 分账接收方对象，json格式
        /// </summary>
        [JsonPropertyName("receiver")]
        [XmlElement("receiver")]
        public ProfitSharingReceiverRemoveInfo ReceiverInfo { get; set; }
        #endregion
        public string GetApiUrl()
        {
            return "https://api.mch.weixin.qq.com/pay/profitsharingremovereceiver";
        }

        public string RequestMethod()
        {
            return "POST";
        }
    }
}
