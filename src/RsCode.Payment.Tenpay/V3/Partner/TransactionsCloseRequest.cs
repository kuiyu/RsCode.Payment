using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Partner
{
    /// <summary>
    /// 服务商关闭订单
    /// </summary>
    public class TransactionsCloseRequest:TenpayBaseRequest
    {
        /// <summary>
        ///  服务商户号
        /// </summary>
        [JsonPropertyName("sp_mchid")]
        public string SpMchId { get; set; }
        /// <summary>
        ///  子商户号
        /// </summary>
        [JsonPropertyName("sub_mchid")]
        public string SubMchId { get; set; }
        /// <summary>
        ///  商户订单号
        /// </summary>
        [JsonPropertyName("out_trade_no")]
        public string OutTradeNo { get; set; }
        public string GetApiUrl()
        {
            return $"https://api.mch.weixin.qq.com/v3/pay/partner/transactions/out-trade-no/{OutTradeNo}/close";
        }
        public string RequestMethod()
        {
            return "POST";
        }
    }
}
