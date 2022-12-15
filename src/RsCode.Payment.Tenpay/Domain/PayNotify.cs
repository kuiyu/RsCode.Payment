using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.Domain
{
    /// <summary>
    /// 支付结果通知
    /// https://pay.weixin.qq.com/wiki/doc/api/jsapi.php?chapter=9_7&index=8
    /// </summary>
    public class PayNotify:INotifyData
    {
        #region 参数
        /// <summary>
        /// 公众账号ID 
        /// </summary>
        [Required] [JsonPropertyName("appid")] public string AppId { get; set; }
        /// <summary>
        /// 商户号
        /// </summary>
        [Required] [JsonPropertyName("mch_id")] public string MchId { get; set; }
        /// <summary>
        /// 微信支付分配的终端设备号
        /// </summary>
        [JsonPropertyName("device_info")] public string DeviceInfo { get; set; }
        /// <summary>
        /// 随机字符串，不长于32位
        /// </summary>
        [Required] [JsonPropertyName("nonce_str")] public string NonceStr { get; set; }
        [Required] [JsonPropertyName("sign")] public string Sign { get; set; }
         [JsonPropertyName("sign_type")] public string SignType { get; set; }
        /// <summary>
        /// 业务结果
        /// </summary>
        [JsonPropertyName("result_code")] public string ResultCode { get; set; }
        /// <summary>
        /// 错误代码
        /// </summary>
        [JsonPropertyName("err_code")] public string ErrCode { get; set; }
        /// <summary>
        /// 错误代码描述
        /// </summary>
        [JsonPropertyName("err_code_des")] public string ErrCodeDes { get; set; }
        /// <summary>
        /// 用户标识
        /// </summary>
        [JsonPropertyName("openid")] public string OpenId { get; set; }
        /// <summary>
        /// 用户是否关注公众账号
        /// </summary>
        [JsonPropertyName("is_subscribe")] public string IsSubscribe { get; set; }
        /// <summary>
        /// 交易类型
        /// </summary>
        [JsonPropertyName("trade_type")] public string TradeType { get; set; }
        /// <summary>
        /// 付款银行
        /// </summary>
        [JsonPropertyName("bank_type")] public string BankType { get; set; }
        /// <summary>
        /// 订单总金额，单位为分
        /// </summary>
       [JsonPropertyName("total_fee")] public string TotalFee { get; set; }
        /// <summary>
        /// 应结订单金额 当该订单有使用非充值券时，返回此字段。
        /// 应结订单金额=订单金额-非充值代金券金额，应结订单金额<=订单金额。
        /// </summary>
        [JsonPropertyName("settlement_total_fee")] public int SettlementTotalFee { get; set; }

        /// <summary>
        /// 货币类型，符合ISO4217标准的三位字母代码，默认人民币：CNY，其他值列表
        /// </summary>
        [JsonPropertyName("fee_type")] public string FeeType { get; set; }

        /// <summary>
        /// 现金支付金额
        /// </summary>
        [JsonPropertyName("cash_fee")] public string CashFee { get; set; }
        /// <summary>
        /// 现金支付货币类型
        /// </summary>
        [JsonPropertyName("cash_fee_type")] public string CashFeeType { get; set; }
        /// <summary>
        /// 总代金券金额
        /// 代金券金额<=订单金额，订单金额-代金券金额=现金支付金额
        /// </summary>
        [JsonPropertyName("coupon_fee")] public int CouponFee { get; set; }
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
        /// 代金券ID
        /// </summary>
        [JsonPropertyName("coupon_id_$n")] public string CouponId_ { get; set; }
        /// <summary>
        /// 单个代金券支付金额
        /// </summary>
        [JsonPropertyName("coupon_fee_$n")] public int CouponFee_ { get; set; }

        /// <summary>
        /// 微信的订单号
        /// </summary>
        [JsonPropertyName("transaction_id")] public string TransactionId { get; set; }

        /// <summary>
        /// 商户系统内部订单号，要求32个字符内
        /// </summary>
        [JsonPropertyName("out_trade_no")] public string OutTradeNo { get; set; }

        /// <summary>
        /// 商家数据包
        /// </summary>
        [JsonPropertyName("attach")] public string Attach { get; set; }
        /// <summary>
        /// 支付完成时间
        /// </summary>
        [JsonPropertyName("time_end")] public string TimeEnd { get; set; }



        #endregion
    }
}
