using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Partner
{
    /// <summary>
    /// 支付成功结果通知
    /// </summary>
    public class TransactionsSuccessNotify    :NotifyData
    {
        #region 参数
        /// <summary>
        /// 服务商申请的公众号或移动应用appid
        /// </summary>
        [JsonPropertyName("sp_appid")] public string SpAppId { get; set; }
        /// <summary>
        /// 服务商户号，由微信支付生成并下发
        /// </summary>
        [JsonPropertyName("sp_mchid")] public string SpMchId { get; set; }
        /// <summary>
        /// 子商户申请的公众号或移动应用appid 
        /// </summary>
        [JsonPropertyName("sub_appid")] public string SubAppId { get; set; }
        /// <summary>
        /// 子商户的商户号，有微信支付生成并下发
        /// </summary>
        [JsonPropertyName("sub_mchid")] public string SubMchId { get; set; }

        /// <summary>
        /// 商户系统内部订单号，要求32个字符内
        /// </summary>
        [JsonPropertyName("out_trade_no")] public string OutTradeNo { get; set; }

        /// <summary>
        /// 微信的订单号
        /// </summary>
        [JsonPropertyName("transaction_id")] public string TransactionId { get; set; }
        /// <summary>
        /// 交易类型
        /// </summary>
        [JsonPropertyName("trade_type")] public string TradeType { get; set; }
        /// <summary>
        /// 交易状态
        /// </summary>
        [JsonPropertyName("trade_state")] public string TradeState { get; set; }
        /// <summary>
        /// 交易状态描述
        /// </summary>
        [JsonPropertyName("trade_state_desc")] public string TradeStateDesc { get; set; }
        /// <summary>
        /// 付款银行
        /// </summary>
        [JsonPropertyName("bank_type")] public string BankType { get; set; }
        /// <summary>
        /// 商家数据包
        /// </summary>
        [JsonPropertyName("attach")] public string Attach { get; set; }
        /// <summary>
        /// 支付完成时间
        /// </summary>
        [JsonPropertyName("success_time")] public string SuccessTime { get; set; }
        /// <summary>
        /// 支付者
        /// </summary>
        [JsonPropertyName("payer")] public PayerInfo Payer { get; set; }
        /// <summary>
        /// 订单金额
        /// </summary>
        [JsonPropertyName("amount")] public OrderAmountInfo AmountInfo { get; set; }
        /// <summary>
        /// 场景信息
        /// </summary>
        [JsonPropertyName("scene_info")] public SceneInfo   SceneInfo { get; set; }
        /// <summary>
        /// 优惠功能
        /// </summary>
        [JsonPropertyName("promotion_detail")] public PromotionDetailInfo PromotionDetail { get; set; }

         


        #endregion
    }
}
