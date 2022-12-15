
/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 协议:MIT License 2.0 
 * 作者:河南软商网络科技有限公司 
 * 项目己托管于  
 * github
   https://github.com/kuiyu/RsCode.Payment.git
 */
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V2.Merchant
{
    public class OrderQueryResponse:TenpayBaseResponse
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
        /// 设备号 
        /// </summary>
        [JsonPropertyName("device_info")] public string DeviceInfo { get; set; }
        /// <summary>
        ///用户标识
        /// </summary>
        [JsonPropertyName("openid")] public string OpenId { get; set; }
        /// <summary>
        /// 是否关注公众账号
        /// </summary>
        [JsonPropertyName("is_subscribe")] public string IsSubscribe { get; set; }


        /// <summary>
        ///  交易类型
        /// </summary>
        [JsonPropertyName("trade_type")] public string TradeType { get; set; }


        /// <summary>
        /// 交易状态
        /// </summary>
        [JsonPropertyName("trade_state")] public string TradeState { get; set; }

        /// <summary>
        /// 付款银行
        /// </summary>
        [JsonPropertyName("bank_type")] public string BankTye { get; set; }

        /// <summary>
        /// 标价金额
        /// </summary>
        [JsonPropertyName("total_fee")] public int TotalFee { get; set; }
        /// <summary>
        /// 应结订单金额
        /// </summary>
        [JsonPropertyName("settlement_total_fee")] public int SettlementTotalFee { get; set; }
        /// <summary>
        /// 标价币种
        /// </summary>
        [JsonPropertyName("fee_type")] public string FeeType { get; set; }
        /// <summary>
        /// 现金支付金额
        /// </summary>
        [JsonPropertyName("cash_fee")] public int CashFee { get; set; }
        /// <summary>
        /// 现金支付币种
        /// </summary>
        [JsonPropertyName("cash_fee_type")] public string CashFeeType { get; set; }
        /// <summary>
        /// 代金券金额
        /// </summary>
        [JsonPropertyName("coupon_fee")] public string CouponFee { get; set; }
        /// <summary>
        /// 代金券使用数量	
        /// </summary>
        [JsonPropertyName("coupon_count")] public int CouponCount { get; set; }

        /// <summary>
        /// 代金券类型
        /// </summary>
        [JsonPropertyName("coupon_type_")] public string CouponType { get; set; }
        /// <summary>
        /// 代金券ID
        /// </summary>
        [JsonPropertyName("coupon_id_")] public string CouponId { get; set; }
        /// <summary>
        /// 单个代金券支付金额
        /// </summary>
        [JsonPropertyName("coupon_fee_")] public int CouponFee_ { get; set; }
        /// <summary>
        /// 微信支付订单号
        /// </summary>
        [JsonPropertyName("transaction_id")] public string TransactionId { get; set; }
        /// <summary>
        /// 商户订单号
        /// </summary>
        [JsonPropertyName("out_trade_no")] public string OutTradeNo { get; set; }
        /// <summary>
        /// 附加数据
        /// </summary>
        [JsonPropertyName("attach")] public string Attach { get; set; }
        /// <summary>
        /// 支付完成时间	
        /// </summary>
        [JsonPropertyName("time_end")] public string TimeEnd { get; set; }
        /// <summary>
        /// 交易状态描述
        /// </summary>
        [JsonPropertyName("trade_state_desc")] public string TradeStateDesc { get; set; }
       
        #endregion
    }
}
