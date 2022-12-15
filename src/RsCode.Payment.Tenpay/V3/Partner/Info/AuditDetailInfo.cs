using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Partner
{
    /// <summary>
    /// 各项资料的审核情况
    /// </summary>
    public class AuditDetailInfo
    {
        /// <summary>
        /// 字段名
        /// </summary>
        [JsonPropertyName("field")]
        public string Field { get; set; }
        /// <summary>
        /// 字段名称
        /// </summary>
        [JsonPropertyName("field_name")]
        public string FieldName { get; set; }
        /// <summary>
        /// 驳回原因
        /// </summary>
        [JsonPropertyName("reject_reason")]
        public string RejectReason { get; set; }
    }
}
