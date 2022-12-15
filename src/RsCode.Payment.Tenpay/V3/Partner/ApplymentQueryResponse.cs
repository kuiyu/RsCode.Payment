using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Partner
{
    /// <summary>
    /// 查询申请单状态返回的结果
    /// </summary>
    public class ApplymentQueryResponse:TenpayBaseResponse
    {
        /// <summary>
        ///  业务申请编号
        /// </summary>
        [JsonPropertyName("business_code")]
        public string BusinessCode { get; set; }
        /// <summary>
        ///  微信支付申请单号
        /// </summary>
        [JsonPropertyName("applyment_id	")]
        public long ApplymentId { get; set; }
        /// <summary>
        ///  特约商户号
        /// </summary>
        [JsonPropertyName("sub_mchid")]
        public string SubMchId { get; set; }
        /// <summary>
        ///  超级管理员签约链接
        /// </summary>
        [JsonPropertyName("sign_url")]
        public string SignUrl { get; set; }
        /// <summary>
        ///  申请单状态
        /// </summary>
        [JsonPropertyName("applyment_state")]
        public string ApplymentState { get; set; }
        /// <summary>
        ///  申请状态描述
        /// </summary>
        [JsonPropertyName("applyment_state_msg")]
        public string ApplymentStateMsg { get; set; }
        /// <summary>
        ///  驳回原因详情
        /// </summary>
        [JsonPropertyName("audit_detail")]
        public AuditDetailInfo[] AuditDetail { get; set; }
    }
}
