/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace RsCode.Payment.Tenpay.V2.Merchant
{
    public class RefundQueryResponse:TenpayBaseResponse
    {
        /// <summary>
        /// 返回状态码
        /// </summary>
        [JsonPropertyName("return_code")]
        public string ReturnCode { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        [JsonPropertyName("return_msg")]
        public string ReturnMsg { get; set; }

        /// <summary>
        /// 业务结果
        /// </summary>
        [JsonPropertyName("result_code")]
        public string ResultCode { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        [JsonPropertyName("err_code")]
        public string ErrCode { get; set; }

        /// <summary>
        /// 错误描述	
        /// </summary>
        [JsonPropertyName("err_code_des")]
        public string ErrCodeDes { get; set; }

        /// <summary>
        /// 应用号
        /// </summary>
        [JsonPropertyName("appid")]
        public string AppId { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        [JsonPropertyName("mch_id")]
        public string MchId { get; set; }

        /// <summary>
        /// 子商户应用号
        /// </summary>
        [JsonPropertyName("sub_appid")]
        public string SubAppId { get; set; }

        /// <summary>
        /// 子商户号
        /// </summary>
        [JsonPropertyName("sub_mch_id")]
        public string SubMchId { get; set; }

        /// <summary>
        /// 随机字符串
        /// </summary>
        [JsonPropertyName("nonce_str")]
        public string NonceStr { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        [JsonPropertyName("sign")]
        public string Sign { get; set; }

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
        /// 商户退款单号	
        /// </summary>
        [JsonPropertyName("out_refund_no")]
        public string OutRefundNo { get; set; }

        /// <summary>
        /// 微信退款单号	
        /// </summary>
        [JsonPropertyName("refund_id")]
        public string RefundId { get; set; }

        /// <summary>
        /// 申请退款金额	
        /// </summary>
        [JsonPropertyName("refund_fee")]
        public int RefundFee { get; set; }

        /// <summary>
        /// 退款金额	
        /// </summary>
        [JsonPropertyName("settlement_refund_fee")]
        public int SettlementRefundFee { get; set; }

        /// <summary>
        /// 订单金额	
        /// </summary>
        [JsonPropertyName("total_fee")]
        public int TotalFee { get; set; }

        /// <summary>
        /// 应结订单金额
        /// </summary>
        [JsonPropertyName("settlement_total_fee")]
        public int SettlementTotalFee { get; set; }

        /// <summary>
        /// 货币种类
        /// </summary>
        [JsonPropertyName("fee_type")]
        public string FeeType { get; set; }

        /// <summary>
        /// 现金支付金额	
        /// </summary>
        [JsonPropertyName("cash_fee")]
        public int CashFee { get; set; }

        /// <summary>
        /// 现金退款金额	
        /// </summary>
        [JsonPropertyName("cash_refund_fee")]
        public int CashRefundFee { get; set; }

        /// <summary>
        /// 代金券退款总金额	
        /// </summary>
        [JsonPropertyName("coupon_refund_fee")]
        public int RefundCount { get; set; }

        /// <summary>
        /// 退款代金券使用数量	
        /// </summary>
        [JsonPropertyName("coupon_refund_count")]
        public int CouponRefundCount { get; set; }

       

    }
}
