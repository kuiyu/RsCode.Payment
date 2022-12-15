/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V2.Partner
{
    /// <summary>
    /// 申请退款的结果
    /// https://pay.weixin.qq.com/wiki/doc/api/jsapi_sl.php?chapter=9_4
    /// </summary>
    public class RefundResponse : TenpayBaseResponse
    {
        /// <summary>
        /// SUCCESS/FAIL 此字段是通信标识，非交易标识
        /// </summary>
        [JsonPropertyName("return_code")]
        public string ReturnCode { get; set; }
        /// <summary>
        /// 返回信息，如非空，为错误原因
        /// </summary>
        [JsonPropertyName("return_msg")]
        public string ReturnMsg { get; set; } = "";
        /// <summary>
        /// SUCCESS：分账申请接收成功，结果通过分账查询接口查询
        ///FAIL ：提交业务失败
        /// </summary>
        [JsonPropertyName("result_code")]
        public string ResultCode { get; set; }
        /// <summary>
        /// 列表详见错误码列表
        /// </summary>
        [JsonPropertyName("err_code")]
        public string ErrCode { get; set; }
        /// <summary>
        /// 结果信息描述
        /// </summary>
        [JsonPropertyName("err_code_des")]
        public string ErrCodeDes { get; set; }
        #region 参数
        /// <summary>
        /// 服务商商户的APPID 
        /// </summary>
        [JsonPropertyName("appid")] public string AppId { get; set; }
        /// <summary>
        /// 微信支付分配的商户号
        /// </summary>
        [JsonPropertyName("mch_id")] public string MchId { get; set; }
        /// <summary>
        /// 子应用Id
        /// </summary>
        [JsonPropertyName("sub_appid")] public string SubAppId { get; set; }
        /// <summary>
        /// 子商户号
        /// </summary>
        [JsonPropertyName("sub_mch_id")] public string SubMchId { get; set; }
      
        /// <summary>
        /// 随机字符串，不长于32位
        /// </summary>
        [JsonPropertyName("nonce_str")] public string NonceStr { get; set; }
        [JsonPropertyName("sign")] public string Sign { get; set; }
        [JsonPropertyName("sign_type")] public string SignType { get; set; }

        /// <summary>
        /// 微信的订单号
        /// </summary>
        [JsonPropertyName("transaction_id")] public string TransactionId { get; set; }




        /// <summary>
        /// 商户订单号
        /// </summary>
        [JsonPropertyName("out_trade_no")] public string OutTradeNo { get; set; }
        /// <summary>
        /// 商户退款单号
        /// </summary>
        [JsonPropertyName("out_refund_no")] public string OutRefundNo { get; set; }

        /// <summary>
        /// 微信退款单号
        /// </summary>
        [JsonPropertyName("refund_id")] public string RefundId { get; set; }
        /// <summary>
        /// 申请退款金额
        /// </summary>
        [JsonPropertyName("refund_fee")] public int RefundFee { get; set; }
       
        /// <summary>
        /// 退款金额 
        /// </summary>
        [JsonPropertyName("settlement_refund_fee")] public int SettlementRefundFee { get; set; }
        /// <summary>
        /// 订单总金额，单位为分
        /// </summary>
        [JsonPropertyName("total_fee")] public string TotalFee { get; set; }
        /// <summary>
        /// 应结订单金额 
        /// </summary>
        [JsonPropertyName("settlement_total_fee")] public int SettlementTotalFee { get; set; }
        /// <summary>
        /// 货币类型，符合ISO4217标准的三位字母代码，默认人民币：CNY，其他值列表
        /// </summary>
        [JsonPropertyName("fee_type")] public string FeeType { get; set; }

        /// <summary>
        /// 现金支付金额
        /// </summary>
        [JsonPropertyName("cash_fee")] public int CashFee { get; set; }
        /// <summary>
        /// 现金退款金额
        /// </summary>
        [JsonPropertyName("cash_refund_fee")] public int CashRefundFee { get; set; }
        /// <summary>
        /// 代金券退款总金额
        /// </summary>
        [JsonPropertyName("coupon_refund_fee")] public int CouponRefundFee { get; set; }
        /// <summary>
        /// 退款代金券使用数量
        /// </summary>
        [JsonPropertyName("coupon_refund_count")] public int CouponRefundCount { get; set; }
        /// <summary>
        /// 现金支付货币类型
        /// </summary>
        [JsonPropertyName("cash_fee_type")] public string CashFeeType { get; set; }

        /// <summary>
        /// 退款代金券ID 
        /// </summary>
        [JsonPropertyName("coupon_refund_id_")] public string  CouponRefundId_ { get; set; }
        /// <summary>
        /// 代金券使用数量
        /// </summary>
        [JsonPropertyName("coupon_count")] public int CouponCount { get; set; }
        /// <summary>
        /// 代金券类型
        /// CASH--充值代金券         NO_CASH---非充值代金券  
        /// 并且订单使用了免充值券后有返回（取值：CASH、NO_CASH）。$n为下标,从0开始编号，举例：coupon_type_0
        ///注意：只有下单时订单使用了优惠，回调通知才会返回券信息。
        /// 下列情况可能导致订单不可以享受优惠
        /// </summary>
        [JsonPropertyName("coupon_type_$n")] public string CouponType_ { get; set; }

        /// <summary>
        /// 单个代金券退款金额
        /// </summary>
        [JsonPropertyName("coupon_refund_fee_$n")] public int CouponRefundFee_ { get; set; }
       


        #endregion

    }
}
