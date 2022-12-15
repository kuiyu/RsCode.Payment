using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace RsCode.Payment.Tenpay.V2.Partner
{
    public class TransactionNotifyData: NotifyData
    {
        /// <summary>
        /// SUCCESS/FAIL 此字段是通信标识，非交易标识
        /// </summary>
        [JsonPropertyName("return_code")]
        [XmlElement("return_code")]
        public string ReturnCode { get; set; }
        /// <summary>
        /// 返回信息，如非空，为错误原因
        /// </summary>
        [JsonPropertyName("return_msg")]
        [XmlElement("return_msg")]
        public string ReturnMsg { get; set; } = "";
        /// <summary>
        /// SUCCESS：分账申请接收成功，结果通过分账查询接口查询
        ///FAIL ：提交业务失败
        /// </summary>
        [JsonPropertyName("result_code")]
        [XmlElement("result_code")]
        public string ResultCode { get; set; }
        /// <summary>
        /// 列表详见错误码列表
        /// </summary>
        [JsonPropertyName("err_code")]
        [XmlElement("err_code")]
        public string ErrCode { get; set; }
        /// <summary>
        /// 结果信息描述
        /// </summary>
        [JsonPropertyName("err_code_des")]
        [XmlElement("err_code_des")]
        public string ErrCodeDes { get; set; }
        #region 参数
        /// <summary>
        /// 服务商商户的APPID 
        /// </summary>
        [JsonPropertyName("appid")] [XmlElement("appid")] public string AppId { get; set; }
        /// <summary>
        /// 微信支付分配的商户号
        /// </summary>
        [JsonPropertyName("mch_id")] [XmlElement("mch_id")] public string MchId { get; set; }
        /// <summary>
        /// 子应用Id
        /// </summary>
        [JsonPropertyName("sub_appid")] [XmlElement("sub_appid")] public string SubAppId { get; set; }
        /// <summary>
        /// 子商户号
        /// </summary>
        [JsonPropertyName("sub_mch_id")] [XmlElement("sub_mch_id")] public string SubMchId { get; set; }
        /// <summary>
        /// 微信支付分配的终端设备号
        /// </summary>
        [JsonPropertyName("device_info")] [XmlElement("device_info")] public string DeviceInfo { get; set; }
        /// <summary>
        /// 随机字符串，不长于32位
        /// </summary>
         [JsonPropertyName("nonce_str")] [XmlElement("nonce_str")] public string NonceStr { get; set; }
        [JsonPropertyName("sign")] [XmlElement("sign")] public string Sign { get; set; }
        [JsonPropertyName("sign_type")] [XmlElement("sign_type")] public string SignType { get; set; }
         
        /// <summary>
        /// 用户标识
        /// </summary>
        [JsonPropertyName("openid")] [XmlElement("openid")] public string OpenId { get; set; }
        /// <summary>
        /// 用户是否关注公众账号
        /// </summary>
        [JsonPropertyName("is_subscribe")] [XmlElement("is_subscribe")] public string IsSubscribe { get; set; }
        /// <summary>
        /// 用户子标识
        /// </summary>
        [JsonPropertyName("sub_openid")] [XmlElement("sub_openid")] public string SubOpenId { get; set; }
        /// <summary>
        /// 是否关注子公众账号
        /// </summary>
        [JsonPropertyName("sub_is_subscribe")] [XmlElement("sub_is_subscribe")] public string SubIsSubscribe { get; set; }
        /// <summary>
        /// 交易类型
        /// </summary>
        [JsonPropertyName("trade_type")] [XmlElement("trade_type")] public string TradeType { get; set; }
        /// <summary>
        /// 付款银行
        /// </summary>
        [JsonPropertyName("bank_type")] [XmlElement("bank_type")] public string BankType { get; set; }
        /// <summary>
        /// 订单总金额，单位为分
        /// </summary>
        [JsonPropertyName("total_fee")] [XmlElement("total_fee")] public string TotalFee { get; set; }
       

        /// <summary>
        /// 货币类型，符合ISO4217标准的三位字母代码，默认人民币：CNY，其他值列表
        /// </summary>
        [JsonPropertyName("fee_type")] [XmlElement("fee_type")] public string FeeType { get; set; }

        /// <summary>
        /// 现金支付金额
        /// </summary>
        [JsonPropertyName("cash_fee")] [XmlElement("cash_fee")] public string CashFee { get; set; }
        /// <summary>
        /// 现金支付货币类型
        /// </summary>
        [JsonPropertyName("cash_fee_type")] [XmlElement("cash_fee_type")] public string CashFeeType { get; set; }
        /// <summary>
        /// 应结订单金额 当该订单有使用非充值券时，返回此字段。
        /// 应结订单金额=订单金额-非充值代金券金额，应结订单金额<=订单金额。
        /// </summary>
        [JsonPropertyName("settlement_total_fee")] [XmlElement("settlement_total_fee")] public int SettlementTotalFee { get; set; }
        /// <summary>
        /// 总代金券金额
        /// 代金券金额<=订单金额，订单金额-代金券金额=现金支付金额
        /// </summary>
        [JsonPropertyName("coupon_fee")] [XmlElement("coupon_fee")] public int CouponFee { get; set; }
        /// <summary>
        /// 代金券使用数量
        /// </summary>
        [JsonPropertyName("coupon_count")] [XmlElement("coupon_count")] public int CouponCount { get; set; }
        /// <summary>
        /// 代金券类型
        /// CASH--充值代金券         NO_CASH---非充值代金券  
        /// 并且订单使用了免充值券后有返回（取值：CASH、NO_CASH）。$n为下标,从0开始编号，举例：coupon_type_0
        ///注意：只有下单时订单使用了优惠，回调通知才会返回券信息。
        /// 下列情况可能导致订单不可以享受优惠
        /// </summary>
        [JsonPropertyName("coupon_type_$n")] [XmlElement("coupon_type_$n")] public string CouponType_ { get; set; }

        /// <summary>
        /// 代金券ID
        /// </summary>
        [JsonPropertyName("coupon_id_$n")] [XmlElement("coupon_id_$n")] public string CouponId_ { get; set; }
        /// <summary>
        /// 单个代金券支付金额
        /// </summary>
        [JsonPropertyName("coupon_fee_$n")] [XmlElement("coupon_fee_$n")] public int CouponFee_ { get; set; }

        /// <summary>
        /// 微信的订单号
        /// </summary>
        [JsonPropertyName("transaction_id")] [XmlElement("transaction_id")] public string TransactionId { get; set; }

        /// <summary>
        /// 商户系统内部订单号，要求32个字符内
        /// </summary>
        [JsonPropertyName("out_trade_no")] [XmlElement("out_trade_no")] public string OutTradeNo { get; set; }

        /// <summary>
        /// 商家数据包
        /// </summary>
        [JsonPropertyName("attach")] [XmlElement("attach")] public string Attach { get; set; }
        /// <summary>
        /// 支付完成时间
        /// </summary>
        [JsonPropertyName("time_end")] [XmlElement("time_end")] public string TimeEnd { get; set; }



        #endregion








         
    }
}
