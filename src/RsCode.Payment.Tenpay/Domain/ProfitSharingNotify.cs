using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.Domain
{
    /// <summary>
    /// 分账动账通知
    /// 本接口使用微信支付V3版接口规则
    /// https://pay.weixin.qq.com/wiki/doc/apiv3/wxpay/ecommerce/profitsharing/chapter3_6.shtml
    /// </summary>
    public class ProfitSharingNotify:INotifyData
    {
        #region 参数
        /// <summary>
        /// 直连模式分账发起和出资商户
        /// </summary>
        [Required] [JsonPropertyName("mchid")] public string MchId { get; set; }
        /// <summary>
        /// 服务商模式分账发起商户
        /// </summary>
        [JsonPropertyName("sp_mchid")] public string SpMchId { get; set; }
        /// <summary>
        /// 服务商模式分账出资商户
        /// </summary>
        [JsonPropertyName("sub_mchid")] public string SubMchId { get; set; }
        /// <summary>
        /// 微信订单号
        /// </summary>
        [Required]
        [JsonPropertyName("transaction_id")]
        public string TransactionId { get; set; }

        /// <summary>
        /// 微信分账/回退单号
        /// </summary>
        [Required]
        [JsonPropertyName("order_id")]
        public string OrderId { get; set; }

        /// <summary>
        ///分账方系统内部的分账/回退单号
        /// </summary>
        [Required]
        [JsonPropertyName("out_order_no")]
        public string OutOrderNo { get; set; }



        /// <summary>
        /// 分账接收方
        /// </summary>       
        [JsonPropertyName("receivers")]
        public Receiver[]  Receivers { get; set; }




        /// <summary>
        /// 成功时间 
        /// </summary>
        [Required]
        [JsonPropertyName("success_time")]
        public string SuccessTime { get; set; }


        #endregion
    }

    /// <summary>
    /// 分账接收方
    /// </summary>
    public class Receiver
    {
        /// <summary>
        /// 分账接收方类型
        /// </summary>
        [JsonPropertyName("type")] public string Type { get; set; }
        /// <summary>
        /// 分账接收方帐号
        /// </summary>
        [JsonPropertyName("account")] public string Account { get; set; }
        /// <summary>
        /// 分账动账金额
        /// </summary>
        [JsonPropertyName("amount")] public int Amount { get; set; }
        /// <summary>
        /// 分账/回退描述
        /// </summary>
        [JsonPropertyName("description")] public string Description { get; set; }
        /// <summary>
        /// 成功时间
        /// </summary>
        [JsonPropertyName("success_time")] public string SuccessTime { get; set; }
    }
}
