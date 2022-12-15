using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.Domain
{
    /// <summary>
    /// 退款通信息成功时返回的内容
    /// </summary>
    public class RefundResult
    {
        /// <summary>
        /// 业务结果
        /// </summary>
        [JsonPropertyName("result_code")]public string ResultCode { get; set; }
        /// <summary>
        /// 错误代码
        /// </summary>
        [JsonPropertyName("err_code")]public string ErrCode { get; set; }
        /// <summary>
        /// 结果信息描述
        /// </summary>
        [JsonPropertyName("err_code_des")]public string ErrCodeDes   { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("appid")]public string AppId { get; set; }
        /// <summary>
        /// 微信支付分配的商户号
        /// </summary>
        [JsonPropertyName("mch_id")]public string MchId { get; set; }
        [JsonPropertyName("nonce_str")]public string NonceStr { get; set; }
        [JsonPropertyName("sign")]public string Sign { get; set; }
        /// <summary>
        /// 微信订单号
        /// </summary>
        [JsonPropertyName("transaction_id")]public string TransactionId { get; set; }
        /// <summary>
        /// 商户系统内部订单号，要求32个字符内，只能是数字、大小写字母_-|*@ ，且在同一个商户号下唯一。
        /// </summary>
        [JsonPropertyName("out_trade_no")]public string OutTradeNo { get; set; }
        /// <summary>
        /// 商户系统内部的退款单号，商户系统内部唯一，只能是数字、大小写字母_-|*@ ，同一退款单号多次请求只退一笔。
        /// </summary>
        [JsonPropertyName("out_refund_no")]public string OutRefundNo { get; set; }
        /// <summary>
        /// 微信退款单号
        /// </summary>
        [JsonPropertyName("refund_id")]public string RefundId { get; set; }
        /// <summary>
        /// 退款总金额,单位为分,可以做部分退款
        /// </summary>
        [JsonPropertyName("refund_fee")]public string RefundFee { get; set; }
        /// <summary>
        /// 去掉非充值代金券退款金额后的退款金额，退款金额=申请退款金额-非充值代金券退款金额，退款金额<=申请退款金额
        /// </summary>
        [JsonPropertyName("settlement_refund_fee")]public string SettlementRefundFee { get; set; }
        /// <summary>
        /// 订单总金额，单位为分，只能为整数
        /// </summary>
        [JsonPropertyName("total_fee")]public string TotalFee { get; set; }
        /// <summary>
        /// 去掉非充值代金券金额后的订单总金额，应结订单金额=订单金额-非充值代金券金额，应结订单金额<=订单金额。
        /// </summary>
        [JsonPropertyName("settlement_total_fee")]public string SettlementTotalFee { get; set; }
        /// <summary>
        /// 订单金额货币类型
        /// </summary>
        [JsonPropertyName("fee_type")]public string FeeType { get; set; }
        /// <summary>
        /// 现金支付金额，单位为分，只能为整数
        /// </summary>
        [JsonPropertyName("cash_fee")]public string CashFee { get; set; }
        /// <summary>
        /// 货币类型，符合ISO 4217标准的三位字母代码，默认人民币：CNY
        /// </summary>
        [JsonPropertyName("cash_fee_type")]public string CashFeeType { get; set; }
        /// <summary>
        /// 现金退款金额，单位为分，只能为整数
        /// </summary>
        [JsonPropertyName("cash_refund_fee")]public string CashRefundFee { get; set; }
        /// <summary>
        /// 代金券类型
        /// </summary>
        [JsonPropertyName("coupon_type_0")]public string CouponType { get; set; }
        /// <summary>
        /// 代金券退款金额<=退款金额，退款金额-代金券或立减优惠退款金额为现金，
        /// </summary>
        [JsonPropertyName("coupon_refund_fee")]public string CouponRefundFee { get; set; }
        /// <summary>
        /// 退款代金券使用数量
        /// </summary>
        [JsonPropertyName("coupon_refund_count")]public string CouponRefundCount { get; set; }
        /// <summary>
        /// 退款代金券ID, $n为下标，从0开始编号
        /// </summary>
        [JsonPropertyName("coupon_refund_id_0")]public string CouponRefundId { get; set; }
        #region 退款单号
        #endregion
        /// <summary>
        /// 退款渠道
        /// </summary>
        [JsonPropertyName("refund_channel")] public string RefundChannel { get; set; }
    }   
}
