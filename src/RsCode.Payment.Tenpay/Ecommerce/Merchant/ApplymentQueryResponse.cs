using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.ECommerce.Merchant
{
    /// <summary>
    /// 业务申请的查询结果
    /// </summary>
    public  class ApplymentQueryResponse
    {
        /// <summary>
        /// 申请状态
        /// </summary>
        [JsonPropertyName("applyment_state")]
        public string ApplymentState { get; set; }

        /// <summary>
        /// 申请状态描述
        /// </summary>
        [JsonPropertyName("applyment_state_desc")]
        public string ApplymentStateDesc { get; set; }

        /// <summary>
        /// 签约链接
        /// </summary>
        [JsonPropertyName("sign_url")]
        public string SignUrl { get; set; }
        /// <summary>
        /// 电商平台二级商户号
        /// </summary>
        [JsonPropertyName("sub_mchid")]
        public string SubMchId { get; set; }
        /// <summary>
        /// 汇款账户验证信息
        /// </summary>
        [JsonPropertyName("account_validation")]
        public AccountValidationInfo AccountValidation { get; set; }
        /// <summary>
        /// 驳回原因详情
        /// </summary>
        [JsonPropertyName("audit_detail")]
        public AuditDetailInfo AuditDetail { get; set; }

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
        public long ApplymentId { get; set; }
    }
}
