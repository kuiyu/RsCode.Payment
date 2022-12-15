using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.ECommerce.Merchant
{

    /// <summary>
    /// +驳回原因详情
    /// </summary>
    public class AuditDetailInfo
    {
        /// <summary>
        /// 参数名称
        /// </summary> 
        [JsonPropertyName("param_name")]
        public long ParamName { get; set; }

        /// <summary>
        /// 驳回原因
        /// </summary>
        [JsonPropertyName("reject_reason")]
        public string RejectReason { get; set; }

        /// <summary>
        /// 法人验证链接
        /// </summary>
        [JsonPropertyName("legal_validation_url")]
        public string LegalValidationUrl { get; set; }

        /// <summary>
        /// 业务申请编号	
        /// </summary>
        [JsonPropertyName("out_request_no")]
        public string OutRequestNo { get; set; }


        /// <summary>
        /// 微信支付申请单号
        /// </summary>
        [JsonPropertyName("applyment_id")]
        public string ApplymentId { get; set; }


       
    }
}
