using System.Text.Json.Serialization;

namespace RsCode.Payment.Alipay.Core
{
    public class TradeQueryRequest
    {
        [JsonPropertyName("out_trade_no")]
        public string OutTradeNo { get; set; }


        /// <summary>
        /// 支付宝交易号，和商户订单号不能同时为空
        /// </summary>
        [JsonPropertyName("trade_no")]
        public string TradeNo { get; set; }
    }
}
