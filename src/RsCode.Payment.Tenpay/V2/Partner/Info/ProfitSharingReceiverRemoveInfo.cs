using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace RsCode.Payment.Tenpay.V2.Partner
{
    public class ProfitSharingReceiverRemoveInfo: TenpayDataInfo
    {
        /// <summary>
        /// 分账接收方类型
        /// MERCHANT_ID：商户号（mch_id或者sub_mch_id）
        ///PERSONAL_OPENID：个人openid（由父商户APPID转换得到）PERSONAL_SUB_OPENID: 个人sub_openid（由子商户APPID转换得到）        
        /// </summary>
        [JsonPropertyName("type")]
        [XmlElement("type")]
        public string Type { get; set; }
        /// <summary>
        /// 分账接收方帐号
        /// 类型是MERCHANT_ID时，是商户号（mch_id或者sub_mch_id）
        ///类型是PERSONAL_OPENID时，是个人openid
        ///类型是PERSONAL_SUB_OPENID时，是个人sub_openid
        /// </summary>
        [JsonPropertyName("account")]
        [XmlElement("account")]
        public string Account { get; set; }

        
    }
}
