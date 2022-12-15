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
    /// 请求单次分账
    /// 单次分账请求按照传入的分账接收方账号和资金进行分账，同时会将订单剩余的待分账金额解冻给本商户。故操作成功后，订单不能再进行分账，也不能进行分账完结。
    /// https://pay.weixin.qq.com/wiki/doc/api/allocation.php?chapter=27_1&index=1
    /// </summary>
    public class ProfitSharing:WxPayData
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
        [Required]
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
            string url = "https://api.mch.weixin.qq.com/secapi/pay/profitsharing";
            return url;
        }

        public override void InitSDK(ClientOptions _client, HttpContext context = null)
        {
           // _client.HttpClient = new HttpClient(new WxpayHandler(_client.PayOptions,true));
            //base.HttpClient = _client.HttpClient;

            MchId = _client.PayOptions.MchId;
            AppId = _client.AppOptions.AppId;

            SignType =SIGN_TYPE_HMAC_SHA256 ;
            AutoSetValue(); //自动处理请求参数
            Sign = MakeSign(_client.PayOptions.APIKey);//生成签名 非V3签名
            SetValue("sign", Sign); //保存签名

        }
    }
}
