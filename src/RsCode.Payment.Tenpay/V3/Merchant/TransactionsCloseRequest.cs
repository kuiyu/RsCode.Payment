using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Merchant
{
    public class TransactionsCloseRequest : TenpayBaseRequest
    {
        public string GetApiUrl()
        {
            return $"https://api.mch.weixin.qq.com/v3/pay/transactions/out-trade-no/{OutTradeNo}/close";
        }

        public string RequestMethod()
        {
            return "POST";
        }

        /// <summary>
        ///  直连商户的商户号
        /// </summary>
        [JsonPropertyName("mchid")]
        public string MchId { get; set; }
       
        /// <summary>
        ///  商户系统内部订单号
        /// </summary>
        [JsonPropertyName("out_trade_no")]
        public string OutTradeNo { get; set; }
    }
}
