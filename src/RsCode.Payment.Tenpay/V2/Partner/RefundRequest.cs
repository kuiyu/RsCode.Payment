using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V2.Partner
{
    /// <summary>
    /// 申请退款
    /// https://pay.weixin.qq.com/wiki/doc/api/jsapi_sl.php?chapter=9_4
    /// </summary>
    public class RefundRequest : TenpayBaseRequest
    {
        #region 参数
        /// <summary>
        /// 微信分配的服务商appid
        /// </summary>
        [JsonPropertyName("appid")] public string AppId { get; set; }
        /// <summary>
        /// 商户号
        /// </summary>
        [JsonPropertyName("mch_id")] public string MchId { get; set; }
        /// <summary>
        /// 微信分配的子商户公众账号ID
        /// </summary>
        [JsonPropertyName("sub_appid")] public string SubAppId { get; set; }
        /// <summary>
        /// 微信支付分配的子商户号
        /// </summary>
        [JsonPropertyName("sub_mch_id")] public string SubMchId { get; set; }
        [JsonPropertyName("nonce_str")]
        public string NonceStr { get { return TenpayTool.GetNonceStr(); } }
        /// <summary>
        /// 签名
        /// </summary> 
        [JsonPropertyName("sign")]
        public string Sign { get; set; }
        /// <summary>
        /// 签名类型，目前支持HMAC-SHA256 和MD5
        /// </summary>
        [JsonPropertyName("sign_type")]
        public string SignType { get; set; } 
        /// <summary>
        /// 微信支付订单号
        /// </summary>
       
        [JsonPropertyName("transaction_id")]
        public string TransactionId { get; set; }
        /// <summary>
        /// 商户订单号
        /// </summary> 
        [JsonPropertyName("out_order_no")]
        public string OutOrderNo { get; set; }

        /// <summary>
        /// 商户退款单号
        /// </summary> 
        [JsonPropertyName("out_refund_no")]
        public string OutRefundNo { get; set; }

        /// <summary>
        /// 订单金额
        /// </summary> 
        [JsonPropertyName("total_fee")]
        public int TotalFee { get; set; }

        /// <summary>
        /// 申请退款金额
        /// </summary> 
        [JsonPropertyName("refund_fee")]
        public int RefundFee { get; set; }

        /// <summary>
        /// 退款货币种类
        /// </summary> 
        [JsonPropertyName("refund_fee_type")]
        public string RefundFeeType { get; set; }

        /// <summary>
        /// 退款原因
        /// </summary> 
        [JsonPropertyName("refund_desc")]
        public string RefundDesc { get; set; }
        /// <summary>
        /// 退款资金来源
        /// </summary> 
        [JsonPropertyName("refund_account")]
        public string RefundAccount { get; set; }
        /// <summary>
        /// 退款结果通知url
        /// </summary> 
        [JsonPropertyName("notify_url")]
        public string NotifyUrl { get; set; }

        #endregion

        public string GetApiUrl()
        {
            return "https://api.mch.weixin.qq.com/secapi/pay/refund";
        }

        public string RequestMethod()
        {
            return "POST";
        }
    }
}
