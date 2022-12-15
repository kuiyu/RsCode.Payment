using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RsCode.Payment.Tenpay;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net.Http;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Wxpay.Domain
{
    /// <summary>
    /// 拉取订单评价数据
    /// https://pay.weixin.qq.com/wiki/doc/api/micropay.php?chapter=9_17&index=11
    /// https://pay.weixin.qq.com/wiki/doc/api/jsapi.php?chapter=9_17&index=11
    /// </summary>
    public class BatchQueryComment:WxPayData
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
        /// 随机字符串，不长于32位
        /// </summary>
        [Required] [JsonPropertyName("nonce_str")] public string NonceStr { get; set; }
        [Required] [JsonPropertyName("sign")] public string Sign { get; set; }

        /// <summary>
        /// 签名类型目前仅支持HMAC-SHA256，默认就是HMAC-SHA256
        /// </summary>
        [Required] [JsonPropertyName("sign_type")] public string SignType { get; set; }
        /// <summary>
        /// 按用户评论时间批量拉取的起始时间，格式为yyyyMMddHHmmss 
        /// </summary>
        [Required] [JsonPropertyName("begin_time")] public string BeginTime { get; set; }
        /// <summary>
        /// 按用户评论时间批量拉取的结束时间，格式为yyyyMMddHHmmss
        /// </summary>
        [Required] [JsonPropertyName("end_time")] public string EndTime { get; set; }
        /// <summary>
        /// 指定从某条记录的下一条开始返回记录。接口调用成功时，会返回本次查询最后一条数据的offset。商户需要翻页时，应该把本次调用返回的offset 作为下次调用的入参。注意offset是评论数据在微信支付后台保存的索引，未必是连续的 
        /// </summary>
        [Required] [JsonPropertyName("offset")] public int Offset { get; set; }
        /// <summary>
        /// 一次拉取的条数, 最大值是200，默认是200
        /// </summary>
        [JsonPropertyName("limit")]
        public int Limit { get; set; } = 200;
        
        


        #endregion
        public override string GetRequestUrl()
        {
            string url = "https://api.mch.weixin.qq.com/billcommentsp/batchquerycomment";
            return url;
        }

        public override void InitSDK(ClientOptions _client, HttpContext context = null)
        {
            //_client.HttpClient = new HttpClient(new WxpayHandler(_client.PayOptions,true));
            //base.HttpClient = _client.HttpClient;

            AppId = _client.AppOptions.AppId;
            MchId = _client.PayOptions.MchId;
            NonceStr = Path.GetRandomFileName();
            SignType =SIGN_TYPE_HMAC_SHA256;
            AutoSetValue(); //自动处理请求参数

            Sign = MakeSign(_client.PayOptions.APIKey);//生成签名 非V3签名
            SetValue("sign", Sign); //保存签名 
        }
    }
}
