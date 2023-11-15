/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.Domain
{
    /// <summary>
    /// 退款回调通知
    /// https://pay.weixin.qq.com/wiki/doc/api/micropay.php?chapter=9_16&index=10
    /// https://pay.weixin.qq.com/wiki/doc/api/jsapi.php?chapter=9_16&index=10
    /// https://pay.weixin.qq.com/wiki/doc/api/native.php?chapter=9_16&index=11
    /// </summary>
    public class RefundNotify:INotifyData
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
        /// 随机字符串，不长于32位
        /// </summary>
        [Required] [JsonPropertyName("nonce_str")] public string NonceStr { get; set; }
        /// <summary>
        /// 加密信息
        /// 请用商户秘钥进行解密
        /// </summary>
        [Required] [JsonPropertyName("req_info")] public string ReqInfo { get; set; }
        
        /// <summary>
        /// 微信的订单号，建议优先使用 
        /// </summary>
        [JsonPropertyName("transaction_id")] public string TransactionId { get; set; }

        /// <summary>
        /// 商户系统内部订单号，要求32个字符内
        /// </summary>
        [JsonPropertyName("out_trade_no")] public string OutTradeNo { get; set; }
        /// <summary>
        /// 微信退款单号
        /// </summary>
        [JsonPropertyName("refund_id")] public string RefundId { get; set; } 
        /// <summary>
        /// 商户系统内部的退款单号
        /// </summary>
        [Required] [JsonPropertyName("out_refund_no")] public string OutRefundNo { get; set; }
        /// <summary>
        /// 订单总金额，单位为分
        /// </summary>
        [Required] [JsonPropertyName("total_fee")] public int TotalFee { get; set; }
        /// <summary>
        /// 应结订单金额 当该订单有使用非充值券时，返回此字段。
        /// 应结订单金额=订单金额-非充值代金券金额，应结订单金额<=订单金额。
        /// </summary>
        [JsonPropertyName("settlement_total_fee")] public int SettlementTotalFee { get; set; }  

        /// <summary>
        /// 退款总金额，订单总金额，单位为分
        /// </summary>
        [Required] [JsonPropertyName("refund_fee")] public int RefundFee { get; set; }
        /// <summary>
        /// 退款金额 
        /// 退款金额=申请退款金额-非充值代金券退款金额，退款金额<=申请退款金额
        /// </summary>
        [JsonPropertyName("settlement_refund_fee")] public int SettlementRefundFee { get; set; }
        /// <summary>
        /// 退款状态
        /// SUCCESS-退款成功  CHANGE-退款异常   REFUNDCLOSE—退款关闭
        /// </summary>
        [JsonPropertyName("refund_status")] public string RefundStatus { get; set; }
        /// <summary>
        /// 退款成功时间 
        /// 资金退款至用户帐号的时间，格式2017-12-15 09:46:01 
        /// </summary>
        [JsonPropertyName("success_time")] public string SuccessTime { get; set; }
        /// <summary>
        /// 退款入账账户
        /// 取当前退款单的退款入账方 
         ///1）退回银行卡：{银行名称}{卡类型}{卡尾号}
         ///2）退回支付用户零钱:支付用户零钱
         ///3）退还商户:商户基本账户 商户结算银行账户
         ///4）退回支付用户零钱通:支付用户零钱通 
        /// </summary>
        [JsonPropertyName("refund_recv_accout")] public string RefundRecvAccount { get; set; }
        /// <summary>
        /// 退款资金来源
        /// REFUND_SOURCE_RECHARGE_FUNDS 可用余额退款/基本账户
        /// REFUND_SOURCE_UNSETTLED_FUNDS 未结算资金退款
        /// </summary>
        [JsonPropertyName("refund_account")] public string RefundAccount { get; set; }
        /// <summary>
        /// 退款发起来源
        /// </summary>
        [JsonPropertyName("refund_request_source")] public string RefundRequestSource { get; set; }



        #endregion

      
    }
}
