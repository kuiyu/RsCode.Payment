using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.ECommerce.Profitsharing
{
    /// <summary>
    /// 分账通知返回的明文数据
    /// </summary>
    public class ProfitSharingNotifyData
    {
        /// <summary>
        /// 直连商户号
        /// 直连模式分账发起和出资商户
        /// </summary>
        [JsonPropertyName("mchid")]public string MchId { get; set; }
        /// <summary>
        /// 服务商商户号
        /// 服务商模式分账发起商户。
        /// </summary>
        [JsonPropertyName("sp_mchid")] public string SpMchId { get; set; }
        /// <summary>
        /// 子商户号
        /// 服务商模式分账出资商户。
        /// </summary>
        [JsonPropertyName("sub_mchid")] public string SubMchId { get; set; }
        /// <summary>
        /// 微信订单号
        /// 微信支付订单号。
        /// </summary>
        [JsonPropertyName("transaction_id")] public string TransactionId { get; set; }
        /// <summary>
        /// 微信分账/回退单号
        /// </summary>
        [JsonPropertyName("order_id")] public string OrderId { get; set; }
        /// <summary>
        /// 商户分账/回退单号
        /// </summary>
        [JsonPropertyName("out_order_no")] public string OutOrderNo { get; set; }
        /// <summary>
        /// 成功时间
        /// </summary>
        [JsonPropertyName("success_time")] public string SuccessTime { get; set; }

        /// <summary>
        /// 分账接收方列表
        /// </summary>
        [JsonPropertyName("receivers")]
        public ProfitSharingNotifyReceiveData[] ReceiveInfo { get; set; }
    }
}
