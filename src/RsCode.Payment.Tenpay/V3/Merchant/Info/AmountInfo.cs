/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Merchant
{
    /// <summary>
    /// 订单金额信息
    /// </summary>
    public class AmountInfo
    {
        public AmountInfo()
        {

        }
   
        /// <summary>
        /// 订单总金额，单位为分。
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; }
        /// <summary>
        /// CNY：人民币，境内商户号仅支持人民币
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; } = "CNY";


        /// <summary>
        /// 用户支付金额
        /// </summary>
        [JsonPropertyName("payer_total")]
        public int PayerTotal { get; set; }
        /// <summary>
        /// 用户支付币种
        /// </summary>
        [JsonPropertyName("payer_currency")]
        public string PayerCurrency { get; set; }

    }
}
