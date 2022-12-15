using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Partner
{
    /// <summary>
    /// 申请二级商户响应结果
    /// </summary>
   public class ApplymentSubResponse:TenpayBaseResponse
    {
        [JsonPropertyName("applyment_id")]
        public long ApplymentId { get; set; }
    }
}
