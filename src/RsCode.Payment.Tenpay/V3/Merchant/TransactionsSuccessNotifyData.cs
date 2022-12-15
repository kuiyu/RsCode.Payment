/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Merchant
{
    public class TransactionsSuccessNotifyData:NotifyData
    {
        #region 参数
        /// <summary>
        /// 直连商户申请的公众号或移动应用appid
        /// </summary>
        [JsonPropertyName("appid")] public string AppId { get; set; }
        /// <summary>
        /// 直连商户的商户号
        /// </summary>
        [JsonPropertyName("mchid")] public string MchId { get; set; }
      
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
        [JsonPropertyName("scene_info")] public SceneInfo SceneInfo { get; set; }
        /// <summary>
        /// 优惠功能
        /// </summary>
        [JsonPropertyName("promotion_detail")] public PromotionDetailInfo PromotionDetail { get; set; }




        #endregion
    }
}
