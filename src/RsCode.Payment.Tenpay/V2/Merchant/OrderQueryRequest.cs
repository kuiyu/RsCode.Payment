using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V2.Merchant
{
    /// <summary>
    /// 微信支付订单的查询
    /// https://pay.weixin.qq.com/wiki/doc/api/micropay.php?chapter=9_2
    /// https://pay.weixin.qq.com/wiki/doc/api/jsapi.php?chapter=9_2
    /// https://pay.weixin.qq.com/wiki/doc/api/native.php?chapter=9_2
    /// </summary>
    public class OrderQueryRequest: WxPayData, TenpayBaseRequest
    {
        #region 参数
        /// <summary>
        /// 公众账号ID 
        /// </summary>
        [JsonPropertyName("appid")] public string AppId { get; set; }
        /// <summary>
        /// 商户号
        /// </summary>
         [JsonPropertyName("mch_id")] public string MchId { get; set; }
        /// <summary>
        /// 微信的订单号，建议优先使用 
        /// </summary>
        [JsonPropertyName("transaction_id")] public string TransactionId { get; set; }

        /// <summary>
        /// 商户系统内部订单号，要求32个字符内
        /// </summary>
        [JsonPropertyName("out_trade_no")] public string OutTradeNo { get; set; }
        /// <summary>
        /// 随机字符串，不长于32位
        /// </summary>
         [JsonPropertyName("nonce_str")] public string NonceStr { get; set; }

         [JsonPropertyName("sign")] public string Sign { get; set; }
        /// <summary>
        /// 签名类型，目前支持HMAC-SHA256和MD5，默认为MD5
        /// </summary>
        [JsonPropertyName("sign_type")]
        public string SignType { get; set; }

        #endregion
        public   string GetApiUrl()
        {
            string url = "https://api.mch.weixin.qq.com/pay/orderquery";

            string url2 = "https://api2.mch.weixin.qq.com/pay/orderquery";

            return url;
        }

        

        public string RequestMethod()
        {
            return "GET";
        }
    }
}
