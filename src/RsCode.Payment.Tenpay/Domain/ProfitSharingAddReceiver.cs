/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.Domain
{
    /// <summary>
    /// 添加分账接收方
    /// https://pay.weixin.qq.com/wiki/doc/api/allocation.php?chapter=27_3&index=4
    /// </summary>
    public class ProfitSharingAddReceiver:WxPayData
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
        /// 分账接收方
        /// </summary>
        [Required]
        [JsonPropertyName("receiver")]
        public string Receiver { get; set; }


        #endregion

        public override string GetRequestUrl()
        {
            string url = "https://api.mch.weixin.qq.com/pay/profitsharingaddreceiver";
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
