using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.Domain
{
    /// <summary>
    /// 请求多次分账
    /// https://pay.weixin.qq.com/wiki/doc/api/allocation.php?chapter=27_6&index=2
    /// </summary>
    public class ProfitSharingMulti:WxPayData
    {
        #region 参数
        /// <summary>
        /// 商户号
        /// </summary>
        [Required] [JsonPropertyName("mch_id")] public string MchId { get; set; }
        [Required] [JsonPropertyName("appid")] public string AppId { get; set; }

        [Required]
        [JsonPropertyName("nonce_str")]
        public string NonceStr { get { return GetNonceStr(); } }
        /// <summary>
        /// 签名
        /// </summary>
        [Required]
        [JsonPropertyName("sign")]
        public string Sign { get; set; }

        /// <summary>
        /// 签名类型，目前只支持HMAC-SHA256
        /// </summary>       
        [JsonPropertyName("sign_type")]
        public string SignType { get; set; }

        /// <summary>
        /// 微信订单号
        /// </summary>
        [Required]
        [JsonPropertyName("transaction_id")]
        public string TransactionId { get; set; }
        /// <summary>
        /// 商户分账单号
        /// </summary>
        [Required]
        [JsonPropertyName("out_order_no")]
        public string OutOrderNo { get; set; }
        /// <summary>
        /// 分账接收方列表
        /// 不超过50个json对象，不能设置分账方作为分账接受方
        /// </summary>
        [Required]
        [JsonPropertyName("receivers")]
        public string Receivers { get; set; }

        #endregion

        public override string GetRequestUrl()
        {
            string url = "https://api.mch.weixin.qq.com/secapi/pay/multiprofitsharing";
            return url;
        }

        public override void InitSDK(ClientOptions _client, HttpContext context = null)
        {
            //_client.HttpClient = new HttpClient(new WxpayHandler(_client.PayOptions,true));
            //base.HttpClient = _client.HttpClient;

            MchId = _client.PayOptions.MchId;
            AppId = _client.AppOptions.AppId;

            SignType = SIGN_TYPE_HMAC_SHA256;
            AutoSetValue(); //自动处理请求参数
            Sign = MakeSign(_client.PayOptions.APIKey);//生成签名 非V3签名
            SetValue("sign", Sign); //保存签名

        }
    }
}
