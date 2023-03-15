using RsCode.Payment.Tenpay.V3.Merchant.Info;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using static System.Net.WebRequestMethods;

namespace RsCode.Payment.Tenpay.V3.Merchant
{
    /// <summary>
    /// 直连商户申请退款
    /// <see cref="https://pay.weixin.qq.com/wiki/doc/apiv3/apis/chapter3_1_9.shtml"/>
    /// </summary>
    public class RefundResponse: TenpayBaseResponse
    {
        /// <summary>
        /// 微信退款单号	
        /// </summary>
        [JsonPropertyName("refund_id")]
        public string RefundId { get; set; }
        /// <summary>
        /// 商户退款单号	
        /// </summary>
        [JsonPropertyName("out_refund_no")]
        public string OutRefundNo { get; set; }
        /// <summary>
        /// 微信订单号	
        /// </summary>
        [JsonPropertyName("transaction_id")]
        public string TransactionId { get; set; }

        /// <summary>
        /// 商户订单号	
        /// </summary>
        [JsonPropertyName("out_trade_no")]
        public string OutTradeNo { get; set; }
        /// <summary>
        /// 退款渠道
        /// 枚举值：
        /// ORIGINAL：原路退款
        /// BALANCE：退回到余额
        /// OTHER_BALANCE：原账户异常退到其他余额账户
        /// OTHER_BANKCARD：原银行卡异常退到其他银行卡
        /// </summary>
        [JsonPropertyName("channel")]
        public string Channel { get; set; }

        /// <summary>
        /// 退款入账账户	
        /// </summary>
        [JsonPropertyName("user_received_account")]
        public string UserReceivedAccount { get; set; }

        /// <summary>
        /// 退款成功时间	
        /// </summary>
        [JsonPropertyName("success_time")]
        public string SuccessTime { get; set; }

        /// <summary>
        /// 退款创建时间	
        /// </summary>
        [JsonPropertyName("create_time")]
        public string CreateTime { get; set; }

        /// <summary>
        /// 退款状态
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// 资金账户
        /// </summary>
        [JsonPropertyName("funds_account")]
        public string FundsAccount { get; set; }

        /// <summary>
        /// 金额详细信息	
        /// </summary>
        [JsonPropertyName("amount")]
        public RefundAmountRequestInfo Amount { get; set; }

        /// <summary>
        /// 优惠退款信息	
        /// </summary>
        [JsonPropertyName("promotion_detail")]
        public RefundPromotionDetialResponseInfo[] PromotionDetail { get; set; }

       
    }
}
