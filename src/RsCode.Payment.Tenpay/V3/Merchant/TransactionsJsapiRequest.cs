﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Merchant
{
    /// <summary>
    /// JSAPI/小程序下单API
    /// <see cref="https://pay.weixin.qq.com/wiki/doc/apiv3/wxpay/pages/transactions.shtml"/>
    /// </summary>
    public class TransactionsJsapiRequest : TenpayBaseRequest
    {
        public string GetApiUrl()
        {
            return "https://api.mch.weixin.qq.com/v3/pay/transactions/jsapi";
        }

        public string RequestMethod()
        {
            return "POST";
        }
        #region 参数
        /// <summary>
        ///直连商户申请的公众号或移动应用appid。
        /// </summary>
        [Required]
        [JsonPropertyName("appid")]
        public string AppId { get; set; }

        /// <summary>
        /// 直连商户的商户号
        /// </summary>
        [Required] [JsonPropertyName("mchid")] public string MchId { get; set; }
         

        /// <summary>
        /// 商品描述
        /// </summary>
        [Required] [JsonPropertyName("description")] public string Description { get; set; }
        /// <summary>
        /// 商户订单号
        /// </summary>
        [JsonPropertyName("out_trade_no")]
        public string OutTradeNo { get; set; }
        /// <summary>
        /// 交易结束时间
        /// </summary>
        [JsonPropertyName("time_expire")] public string TimeExpire { get; set; } =  TenpayTool.ConvertDateTime(DateTime.Now.AddMinutes(30));
        /// <summary>
        /// 附加数据
        /// </summary>
        [JsonPropertyName("attach")] public string Attach { get; set; } = "";
        /// <summary>
        /// 通知地址
        /// </summary>
        [Required] [JsonPropertyName("notify_url")] public string NotifyUrl { get; set; }
        /// <summary>
        /// 商品标记
        /// </summary>
        [JsonPropertyName("goods_tag")] public string GoodsTag { get; set; } = "";
       
        /// <summary>
        ///  订单金额信息
        /// </summary>
        [JsonPropertyName("amount")]
        public PrepaidAmountInfo PrepaidAmountInfo { get; set; }
        /// <summary>
        ///  支付者信息
        /// </summary>
        [JsonPropertyName("payer")]
        public PayerInfo PayerInfo { get; set; }
        /// <summary>
        ///  优惠功能
        /// </summary>
        [JsonPropertyName("detail")]
        public OrderDiscountInfo OrderDiscountInfo { get; set; }

        /// <summary>
        /// 支付场景描述
        /// </summary>
        [JsonPropertyName("scene_info")]
        public JsapiSceneInfo SceneInfo { get; set; }
        #endregion
    }
}
