using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.ECommerce.ECombine
{
    /// <summary>
    /// 子单信息
    /// 最多支持子单条数：50
    /// </summary>
    public class SubOrderInfo
    {
        /// <summary>
        /// 子单发起方商户号，必须与发起方appid有绑定关系。
        /// </summary>
        [Required]
        [JsonPropertyName("mchid")]
        public string MchId { get; set; }

        
        [JsonPropertyName("attach")]
        public string Attach { get; set; }

         
        [JsonPropertyName("amount")]
        public AmountInfo[] Amount { get; set; }


        [Required]
        [JsonPropertyName("out_trade_no")]
        public string OutTradeNo { get; set; }


        [Required]
        [JsonPropertyName("sub_mchid")]
        public string SubMchId { get; set; }

        [Required]
        [JsonPropertyName("description")]
        public string Description { get; set; }

         
        [JsonPropertyName("settle_info")]
        public SettleInfo SettleInfo { get; set; }
    }
}
