using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Partner
{
    /// <summary>
    /// 订单查询响应的结果
    /// </summary>
    public class TransactionsQueryResponse:TenpayBaseResponse
    {
        /// <summary>
        ///服务商申请的公众号或移动应用appid。
        /// </summary>
         
        [JsonPropertyName("sp_appid")]
        public string SpAppId { get; set; }

        /// <summary>
        /// 服务商户号
        /// </summary>
          [JsonPropertyName("sp_mchid")] public string SpMchId { get; set; }
        /// <summary>
        /// 子商户申请的公众号或移动应用appid。如果传入sub_openid，则sub_appid必传
        /// </summary>
        [JsonPropertyName("sub_appid")] public string SubAppId { get; set; }

        /// <summary>
        /// 子商户号
        /// </summary>
        [JsonPropertyName("sub_mchid")] public string SubMchId { get; set; }
        /// <summary>
        ///   订单号
        /// </summary>
        [JsonPropertyName("out_trade_no")]
        public string OutTradeNo { get; set; }
        /// <summary>
        /// 微信支付系统生成的订单号
        /// </summary>
        [JsonPropertyName("transaction_id")]
        public string TransactionId { get; set; }

        /// <summary>
        ///  交易类型
        /// </summary>
        [JsonPropertyName("trade_type")]
        public string TradeType { get; set; }
        /// <summary>
        ///  交易状态
        /// </summary>
        [JsonPropertyName("trade_state")]
        public string TradeState { get; set; }
        /// <summary>
        ///  交易状态描述
        /// </summary>
        [JsonPropertyName("trade_state_desc")]
        public string TradeStateDesc { get; set; }
        /// <summary>
        ///  付款银行
        /// </summary>
        [JsonPropertyName("bank_type")]
        public string BankType { get; set; }
        /// <summary>
        ///  附加数据
        /// </summary>
        [JsonPropertyName("attach")]
        public string Attach { get; set; }
        /// <summary>
        ///  支付完成时间
        /// </summary>
        [JsonPropertyName("success_time")]
        public string SuccessTime { get; set; }
        /// <summary>
        /// 支付者信息
        /// </summary>
        [JsonPropertyName("payer")]
        public PayerInfo PayerInfo { get; set; }

        [JsonPropertyName("amount")]
        public OrderAmountInfo AmountInfo { get; set; }

        [JsonPropertyName("scene_info")]
        public SceneInfo SceneInfo { get; set; }

        [JsonPropertyName("promotion_detail")]
        public PromotionDetailInfo[] PromotionDetail { get; set; }
    }
}
