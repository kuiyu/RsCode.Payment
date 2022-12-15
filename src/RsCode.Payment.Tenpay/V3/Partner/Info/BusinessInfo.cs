using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Partner
{
    /// <summary>
    /// 经营资料
    /// </summary>
  public  class BusinessInfo
    {
        /// <summary>
        /// 商户简称
        /// </summary>
        [JsonPropertyName("merchant_shortname")]
        public string MerchantShortName { get; set; }

        /// <summary>
        /// 客服电话
        /// </summary>
        [JsonPropertyName("service_phone")]
        public string ServicePhone { get; set; }
        /// <summary>
        /// 经营场景
        /// </summary>
        [JsonPropertyName("sales_info")]
        public SaleInfo SaleInfo { get; set; }
    }
}
