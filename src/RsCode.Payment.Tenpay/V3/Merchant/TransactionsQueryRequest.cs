/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Merchant
{
    /// <summary>
    /// 微信支付订单查询
    /// <see cref="https://pay.weixin.qq.com/wiki/doc/apiv3/apis/chapter3_4_2.shtml"/>
    /// </summary>
    public class TransactionsQueryRequest : TenpayBaseRequest
    {
        /// <summary>
        /// 直连商户号
        /// </summary>
        [JsonPropertyName("mchid")]
        public string MchId { get; set; }
        /// <summary>
        /// 微信支付订单号
        /// </summary>
        [JsonPropertyName("transaction_id")]
        public string TransactionId { get; set; }
        /// <summary>
        /// 商户系统内部订单号
        /// </summary>
        [JsonPropertyName("out_trade_no")]
        public string OutTradeNo { get; set; }
        public string GetApiUrl()
        {
            if(!string.IsNullOrWhiteSpace(TransactionId))
            {
                return $"https://api.mch.weixin.qq.com/v3/pay/transactions/id/{TransactionId}?mchid={MchId}";
            }
            if(!string.IsNullOrWhiteSpace(OutTradeNo))
            {
                return $"https://api.mch.weixin.qq.com/v3/pay/transactions/out-trade-no/{OutTradeNo}?mchid={MchId}";
            }
            throw new Exception("缺少必要的查询参数：微信支付订单号或商户订单号");
        }

        public string RequestMethod()
        {
            return "GET";
        }
    }
}
