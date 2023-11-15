/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RsCode.Payment.Tenpay;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Wxpay.Domain
{
    /// <summary>
    /// 授权码查询openid
    /// https://pay.weixin.qq.com/wiki/doc/api/micropay.php?chapter=9_13&index=9
    /// </summary>
    public class AuthCodeToOpenId:WxPayData
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
        /// 授权码  扫码支付授权码，设备读取用户微信中的条码或者二维码信息
        /// </summary>
        [JsonPropertyName("auth_code")]
        public string AuthCode { get; set; }
        /// <summary>
        /// 随机字符串，不长于32位
        /// </summary>
        [Required] [JsonPropertyName("nonce_str")] public string NonceStr { get; set; }
        [Required] [JsonPropertyName("sign")] public string Sign { get; set; }
         

        #endregion
        public override string GetRequestUrl()
        {
            string url = "https://api.mch.weixin.qq.com/tools/authcodetoopenid";
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

            Sign = MakeSign(_client.PayOptions.APIKey);//生成签名 非V3签名
            SetValue("sign", Sign); //保存签名 
        }
    }
}
