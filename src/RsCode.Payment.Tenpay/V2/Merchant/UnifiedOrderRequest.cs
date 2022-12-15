using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V2.Merchant
{
    /// <summary>
    /// 统一下单请求
    /// </summary>
    public class UnifiedOrderRequest: WxPayData, TenpayBaseRequest
    {
        #region 参数
        /// <summary>
        ///微信支付分配的公众账号ID（企业号corpid即为此appId）
        /// </summary> 
        [JsonPropertyName("appid")]
        public string AppId { get; set; }

        /// <summary>
        /// 子商户号
        /// </summary>
        [JsonPropertyName("mch_id")] public string MchId { get; set; }

        /// <summary>
        /// 设备号
        /// </summary>
        [JsonPropertyName("device_info")] public string DeviceInfo { get; set; }

        [Required]
        [JsonPropertyName("nonce_str")]
        public string NonceStr { get { return TenpayTool.GetNonceStr(); } }
        [Required]
        [JsonPropertyName("sign")]
        public string Sign
        {
            get;
            set;
        }
        /// <summary>
        /// 答名类型
        /// </summary>
        [JsonPropertyName("sign_type")]
        public string SignType { get; set; } = "MD5";

        /// <summary>
        /// 商品描述
        /// </summary>
        [Required] [JsonPropertyName("body")] public string Body { get; set; }

        /// <summary>
        /// 商品详情
        /// </summary>
        [JsonPropertyName("detail")] public string Detail { get; set; }

        /// <summary>
        /// 附加数据
        /// </summary>
        [JsonPropertyName("attach")] public string Attach { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        [Required] [JsonPropertyName("out_trade_no")] public string OutTradeNo { get; set; }

        /// <summary>
        /// 标价币种
        /// </summary>
        [JsonPropertyName("fee_type")] public string FeeType { get; set; }

        /// <summary>
        /// 标价金额
        /// </summary>
        [Required] [JsonPropertyName("total_fee")] public int TotalFee { get; set; }

        /// <summary>
        /// 终端IP
        /// </summary>
        [Required] [JsonPropertyName("spbill_create_ip")] public string SpBillCreateIp { get; set; }

        /// <summary>
        /// 交易起始时间
        /// </summary>
        [JsonPropertyName("time_start")] public string TimeStart { get; set; }

        /// <summary>
        /// 交易结束时间
        /// </summary>
        [JsonPropertyName("time_expire")] public string TimeExpire { get; set; }

        /// <summary>
        /// 商品标记
        /// </summary>
        [JsonPropertyName("goods_tag")] public string GoodsTag { get; set; }

        /// <summary>
        /// 通知地址
        /// </summary>
        [Required] [JsonPropertyName("notify_url")] public string NotifyUrl { get; set; }

        /// <summary>
        /// 交易类型
        /// JSAPI，NATIVE，APP，MWEB
        /// </summary>
        [Required] [JsonPropertyName("trade_type")] public string TradeType { get; set; }

        ///// <summary>
        ///// 商品ID
        ///// </summary>
        //[JsonPropertyName("product_id")] public string ProductId { get; set; }

        /// <summary>
        /// 指定支付方式
        /// </summary>
        [JsonPropertyName("limit_pay")] public string LimitPay { get; set; }


        /// <summary>
        /// 电子发票入口开放标识 传入Y时，支付成功消息和支付详情页将出现开票入口。
        /// </summary>
        [JsonPropertyName("receipt")]
        public string Receipt { get; set; }

        /// <summary>
        /// trade_type=JSAPI，此参数必传，用户在商户appid下的唯一标识。
        /// </summary>
        [JsonPropertyName("openid")]
        public string OpenId { get; set; }

        public string GetApiUrl()
        {
            string url = "https://api.mch.weixin.qq.com/pay/unifiedorder";
            string url2 = "https://api2.mch.weixin.qq.com/pay/unifiedorder";
            return url;
        }

        public string RequestMethod()
        {
            return "POST";
        }

        #endregion
    }
}
