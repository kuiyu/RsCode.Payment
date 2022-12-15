using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Partner
{
    /// <summary>
    /// 经营者/法人身份证件
    /// </summary>
    public class IdentityInfo
    {
        /// <summary>
        /// 证件类型
        /// </summary>
        [JsonPropertyName("id_doc_type")]
        public string IdDocType { get; set; }

        [JsonPropertyName("id_card_info")]
        public IdCardInfo CardInfo { get; set; }
        /// <summary>
        /// 其他类型证件信息
        /// </summary>
        [JsonPropertyName("id_doc_info")]
        public IdDocInfo IdDocInfo { get; set; }

        /// <summary>
        /// 经营者/法人是否为受益人
        /// </summary> 
        [JsonPropertyName("owner")]
        public bool Owner { get; set; } = true;
    }
}
