using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Merchant.Info
{
    public  class RefundAmountResponseInfo
    {
        /// <summary>
        /// 原订单金额
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; }
        /// <summary>
        /// 退款金额，单位为分，只能为整数，不能超过原订单支付金额。
        /// </summary>
        [JsonPropertyName("refund")]
        public int Refund { get; set; }
        /// <summary>
        /// 退款出资账户及金额
        /// </summary>
        [JsonPropertyName("from")]
        public RefundFromInfo[] From { get; set; }

        /// <summary>
        /// 用户支付金额
        /// </summary>
        [JsonPropertyName("payer_total")]
        public int PayerTotal { get; set; }
        /// <summary>
        /// 用户退款金额	
        /// </summary>
        [JsonPropertyName("payer_refund")]
        public int PayerRefund { get; set; }
        /// <summary>
        /// 应结退款金额	
        /// </summary>
        [JsonPropertyName("settlement_refund")]
        public int SettlementRefund { get; set; }
        /// <summary>
        /// 应结订单金额
        /// 应结订单金额=订单金额-免充值代金券金额，应结订单金额<=订单金额，单位为分
        /// </summary>
        [JsonPropertyName("settlement_total")]
        public int SettlementTotal { get; set; }
        /// <summary>
        /// 优惠退款金额
        /// 优惠退款金额<=退款金额，退款金额-代金券或立减优惠退款金额为现金，说明详见代金券或立减优惠，单位为分
        /// </summary>
        [JsonPropertyName("discount_refund")]
        public int DiscountRefund { get; set; }

        /// <summary>
        /// 退款币种 CNY：人民币，境内商户号仅支持人民币
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; }
        /// <summary>
        /// 手续费退款金额
        /// </summary>
        [JsonPropertyName("refund_fee")]
        public int RefundFee { get; set; }

        
    }
}
