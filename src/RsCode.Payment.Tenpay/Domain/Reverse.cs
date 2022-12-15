using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.Domain
{
    /// <summary>
    /// 撤销订单
    /// https://pay.weixin.qq.com/wiki/doc/api/micropay.php?chapter=9_11&index=3
    /// </summary>
    public class Reverse: WxPayData
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
        public override string GetRequestUrl()
        {
            string url = "https://api.mch.weixin.qq.com/pay/reverse";

            string url2 = "https://api2.mch.weixin.qq.com/pay/reverse";

            return url;
        }

        public override void InitSDK(ClientOptions _client, HttpContext context = null)
        {
            //_client.HttpClient = new HttpClient(new WxpayHandler(_client.PayOptions));
            //base.HttpClient = _client.HttpClient;

            AppId = _client.AppOptions.AppId;
            MchId = _client.PayOptions.MchId;
            NonceStr = Path.GetRandomFileName();

            AutoSetValue(); //自动处理请求参数

            SignType = SIGN_TYPE_HMAC_SHA256;
            Sign = MakeSign(_client.PayOptions.APIKey);//生成签名 非V3签名
            SetValue("sign", Sign); //保存签名 
        }
    }
}
