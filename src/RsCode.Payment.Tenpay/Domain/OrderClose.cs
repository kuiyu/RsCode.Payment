using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net.Http;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.Domain
{
    /// <summary>
    /// 关闭订单
    /// https://pay.weixin.qq.com/wiki/doc/api/jsapi.php?chapter=9_3
    /// https://pay.weixin.qq.com/wiki/doc/api/native.php?chapter=9_3
    /// </summary>
    public class OrderClose:WxPayData
    {
        #region 参数
        /// <summary>
        /// 公众账号ID 
        /// </summary>
       [Required] [JsonPropertyName("appid")] public string AppId { get; set; }
        /// <summary>
        /// 商户号
        /// </summary>
        [Required] [JsonPropertyName("mch_id")] public string MchId { get; set; }

        /// <summary>
        /// 商户系统内部订单号，要求32个字符内
        /// </summary>
        [Required] [JsonPropertyName("out_trade_no")] public string OutTradeNo { get; set; }
        /// <summary>
        /// 随机字符串，不长于32位
        /// </summary>
        [Required] [JsonPropertyName("nonce_str")] public string NonceStr { get; set; }

        [Required] [JsonPropertyName("sign")] public string Sign { get; set; }
        /// <summary>
        /// 签名类型，目前支持HMAC-SHA256和MD5，默认为MD5
        /// </summary>
        [JsonPropertyName("sign_type")]
        public string SignType { get; set; }

        #endregion
        public override string GetRequestUrl()
        {
            string url = "https://api.mch.weixin.qq.com/pay/closeorder"; 
            string url2 = "https://api2.mch.weixin.qq.com/pay/closeorder"; 
            return url;
        }

        public override void InitSDK(ClientOptions _client, HttpContext context = null)
        {
           // _client.HttpClient = new HttpClient(new WxpayHandler(_client.PayOptions));
           // base.HttpClient = _client.HttpClient;

            AppId = _client.AppOptions.AppId;
            MchId = _client.PayOptions.MchId;
            NonceStr = Path.GetRandomFileName();
            SignType = SIGN_TYPE_HMAC_SHA256;
            AutoSetValue(); //自动处理请求参数

            
            Sign = MakeSign(_client.PayOptions.APIKey);//生成签名 非V3签名
            SetValue("sign", Sign); //保存签名 
        }
    }
}
