/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Merchant
{
    /// <summary>
    /// Native下单API
    /// 除付款码支付场景以外，商户系统先调用该接口在微信支付服务后台生成预支付交易单，返回正确的预支付交易会话标识后再按Native、JSAPI、APP等不同场景生成交易串调起支付。
    /// <see cref="https://pay.weixin.qq.com/wiki/doc/apiv3/apis/chapter3_4_1.shtml"/>
    /// </summary>
    public class TransactionsNativeRequest : TenpayBaseRequest
    {
        public string GetApiUrl()
        {
            return "https://api.mch.weixin.qq.com/v3/pay/transactions/native";
        }

        public string RequestMethod()
        {
            return "POST";
        }

        #region 参数
        /// <summary>
        ///直连商户申请的公众号或移动应用appid。
        /// </summary>
    
        [JsonPropertyName("appid")]
        public string AppId { get; set; }

        /// <summary>
        /// 直连商户的商户号
        /// </summary>
       [JsonPropertyName("mchid")] public string MchId { get; set; }


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
        [JsonPropertyName("time_expire")] public string TimeExpire { get; set; } = TenpayTool.ConvertDateTime(DateTime.Now.AddMinutes(30));
        /// <summary>
        /// 附加数据
        /// </summary>
        [JsonPropertyName("attach")] public string Attach { get; set; } = "";
        /// <summary>
        /// 通知地址
        /// </summary>
        [JsonPropertyName("notify_url")] public string NotifyUrl { get; set; }
        /// <summary>
        /// 商品标记
        /// </summary>
        [JsonPropertyName("goods_tag")] public string GoodsTag { get; set; } = "";

        /// <summary>
        ///  订单金额信息
        /// </summary>
        [JsonPropertyName("amount")]
        public PrepaidAmountInfo OrderAmountInfo { get; set; }
       
        /// <summary>
        ///  优惠功能
        /// </summary>
        [JsonPropertyName("detail")]
        public OrderDiscountInfo OrderDetail { get; set; }

        /// <summary>
        /// 支付场景描述
        /// </summary>
        [JsonPropertyName("scene_info")]
        public NativateSceneInfo SceneInfo { get; set; }
        #endregion
    }
}
