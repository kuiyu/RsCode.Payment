using System;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Partner
{
    public  class TransactionsQueryRequest:TenpayBaseRequest
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

        /// <summary>
        ///  微信支付订单号
        /// </summary>
        [JsonPropertyName("transaction_id")]
        public string TransactionId { get; set; }

         

       

        public string RequestMethod()
        {
            return "GET";
        }

        public string GetApiUrl()
        {
            if (!string.IsNullOrWhiteSpace(TransactionId))
            {
                return $"https://api.mch.weixin.qq.com/v3/pay/partner/transactions/id/{TransactionId}?sp_mchid={SpMchId}&sub_mchid={SubMchId}";
            }
            if (!string.IsNullOrWhiteSpace(OutTradeNo))
            { 
                return $"https://api.mch.weixin.qq.com/v3/pay/partner/transactions/out-trade-no/{OutTradeNo}?sp_mchid={SpMchId}&sub_mchid={SubMchId}";
            }
            throw new Exception("缺少必要的查询参数：微信支付订单号或商户订单号");
        }
    }
}
