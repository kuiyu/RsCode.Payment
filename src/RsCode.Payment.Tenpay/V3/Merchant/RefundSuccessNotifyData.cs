using RsCode.Payment.Tenpay.V3.Merchant.Info;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Merchant
{
    /// <summary>
    /// 退款成功（明文）
    /// </summary>
    public class RefundSuccessNotifyData:NotifyData
    {
       
        /// <summary>
        /// 直连商户的商户号
        /// </summary>
        [JsonPropertyName("mchid")] public string MchId { get; set; }

        /// <summary>
        /// 商户系统内部订单号，要求32个字符内
        /// </summary>
        [JsonPropertyName("out_trade_no")] public string OutTradeNo { get; set; }

        /// <summary>
        /// 微信的订单号
        /// </summary>
        [JsonPropertyName("transaction_id")] public string TransactionId { get; set; }
        /// <summary>
        /// 商户退款单号
        /// </summary>
        [JsonPropertyName("out_refund_no")] public string OutRefundNo { get; set; }
        /// <summary>
        /// 微信支付退款单号
        /// </summary>
        [JsonPropertyName("refund_id")] public string RefundId { get; set; }
        /// <summary>
        /// 退款状态
        /// </summary>
        [JsonPropertyName("refund_status")] public string RefundStatus { get; set; }
        /// <summary>
        /// 退款成功时间
        /// </summary>
        [JsonPropertyName("success_time")] public string SuccessTime { get; set; }
        /// <summary>
        /// 退款入账账户
        /// </summary>
        [JsonPropertyName("user_received_account")] public string UserREceivedAccount { get; set; }

        [JsonPropertyName("amount")]
        public RefundNotifyAmount  Amount { get; set; }
    }
}
