/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using RsCode.Payment.Tenpay.V3.Merchant.Info;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Merchant
{
    /// <summary>
    /// 直连商户退款
    /// <see cref="https://pay.weixin.qq.com/wiki/doc/apiv3/apis/chapter3_1_9.shtml"/>
    /// </summary>
    public class RefundRequest : TenpayBaseRequest
    {
        public RefundRequest()
        {

        }
        public RefundRequest(string transactionId, 
            string orderNo, string refundOrderNo, 
            string reason, string notifyUrl, 
             RefundAmountRequestInfo amount, 
            RefundGoodsInfo[] goodsDetail)
        {
            TransactionId = transactionId;
            OrderNo = orderNo;
            RefundOrderNo = refundOrderNo;
            Reason = reason;
            NotifyUrl = notifyUrl;          
            Amount = amount;
            GoodsDetail = goodsDetail;
        }

        public string GetApiUrl()
        {
            return "https://api.mch.weixin.qq.com/v3/refund/domestic/refunds";
        }

        public string RequestMethod()
        {
            return "POST";
        }

        [JsonPropertyName("transaction_id")]
        public string TransactionId { get; set; }
        /// <summary>
        /// 原支付交易对应的商户订单号
        /// </summary>
        [JsonPropertyName("out_trade_no")] public string OrderNo { get; set; }
        /// <summary>
        /// 商户系统内部的退款单号
        /// </summary>
        [JsonPropertyName("out_refund_no")] public string RefundOrderNo { get; set; }
        /// <summary>
        /// 退款原因
        /// </summary>
        [JsonPropertyName("reason")] public string Reason { get; set; }
        /// <summary>
        /// 退款结果回调url
        /// </summary>
        [JsonPropertyName("notify_url")] public string NotifyUrl { get; set; }

        /// <summary>
        /// 退款资金来源
        /// </summary>
        [JsonPropertyName("funds_account")] public string FundsAccount { get; set; }

        [JsonPropertyName("amount")] public RefundAmountRequestInfo  Amount { get; set; }

        [JsonPropertyName("goods_detail")] public RefundGoodsInfo[] GoodsDetail { get; set; }

    }

    
}
