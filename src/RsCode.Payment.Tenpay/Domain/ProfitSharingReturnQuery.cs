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
    /// 回退结果查询
    /// https://pay.weixin.qq.com/wiki/doc/api/allocation.php?chapter=27_8&index=8
    /// </summary>
    public class ProfitSharingReturnQuery:WxPayData
    {
        #region 参数
        /// <summary>
        /// 商户号
        /// </summary>
        [Required] [JsonPropertyName("mch_id")] public string MchId { get; set; }
        /// <summary>
        /// 公众账号ID
        /// </summary>
        [Required]
        [JsonPropertyName("appid")]
        public string AppId { get; set; }

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
        /// 微信分账单号
        /// 原发起分账请求时，微信返回的微信分账单号，与商户分账单号一一对应。
        /// 微信分账单号与商户分账单号二选一填写
        /// </summary>
        [Required]
        [JsonPropertyName("order_id")]
        public string OrderId { get; set; }

        /// <summary>
        /// 商户分账单号
        /// 原发起分账请求时使用的商户系统内部的分账单号。 
        ///微信分账单号与商户分账单号二选一填写
        /// </summary>
        [Required]
        [JsonPropertyName("out_order_no")]
        public string OutOrderNo { get; set; }

        /// <summary>
        /// 商户回退单号
        /// 调用回退接口提供的商户系统内部的回退单号
        /// </summary>
        [Required]
        [JsonPropertyName("out_return_no")]
        public string OutReturnNo { get; set; }

         
        #endregion

        public override string GetRequestUrl()
        {
            string url = "https://api.mch.weixin.qq.com/pay/profitsharingreturnquery";
            return url;
        }

        public override void InitSDK(ClientOptions _client, HttpContext context = null)
        {
            //_client.HttpClient = new HttpClient(new WxpayHandler(_client.PayOptions));
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
