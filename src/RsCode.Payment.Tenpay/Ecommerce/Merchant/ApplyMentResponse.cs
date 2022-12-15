using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.ECommerce.Merchant
{
    public class ApplyMentResponse
    {
        /// <summary>
        /// 微信支付申请单号
        /// </summary>
        [JsonPropertyName("applyment_id")]
        public long ApplymentId { get; set; }

        /// <summary>
        /// 业务申请编号
        /// </summary>
        [JsonPropertyName("out_request_no")]
        public string OutRequestNo { get; set; }
    }
}
