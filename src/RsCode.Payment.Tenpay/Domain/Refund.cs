/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.Domain
{
    /// <summary>
    /// 申请退款
    /// https://pay.weixin.qq.com/wiki/doc/api/micropay.php?chapter=9_4
    /// https://pay.weixin.qq.com/wiki/doc/api/jsapi.php?chapter=9_4
    /// </summary>
    public class Refund:WxPayData
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
        /// 签名类型，目前支持HMAC-SHA256和MD5，默认为MD5
        /// </summary>
        [JsonPropertyName("sign_type")]
        public string SignType { get; set; }
        /// <summary>
        /// 微信的订单号，建议优先使用 
        /// </summary>
        [JsonPropertyName("transaction_id")] public string TransactionId { get; set; }

        /// <summary>
        /// 商户系统内部订单号，要求32个字符内
        /// </summary>
        [JsonPropertyName("out_trade_no")] public string OutTradeNo { get; set; }


        /// <summary>
        /// 商户系统内部的退款单号
        /// </summary>
        [Required] [JsonPropertyName("out_refund_no")] public string OutRefundNo { get; set; }
        /// <summary>
        /// 订单总金额，单位为分
        /// </summary>
        [Required] [JsonPropertyName("total_fee")] public int TotalFee { get; set; }
        /// <summary>
        /// 退款总金额，订单总金额，单位为分
        /// </summary>
        [Required][JsonPropertyName("refund_fee")] public int RefundFee { get; set; }
        /// <summary>
        /// 退款货币类型，需与支付一致，或者不填
        /// </summary>
        [JsonPropertyName("refund_fee_type")] public string RefundFeeType { get; set; }
        /// <summary>
        /// 退款原因 
        /// 若商户传入，会在下发给用户的退款消息中体现退款原因
        /// 注意：若订单退款金额≤1元，且属于部分退款，则不会在退款消息中体现退款原因 
        /// </summary>
        [JsonPropertyName("refund_desc")] public string RefundDesc { get; set; }
        /// <summary>
        /// 退款资金来源
        /// 仅针对老资金流商户使用
        /// REFUND_SOURCE_UNSETTLED_FUNDS---未结算资金退款（默认使用未结算资金退款）
        ///REFUND_SOURCE_RECHARGE_FUNDS---可用余额退款
        /// </summary>
        [JsonPropertyName("refund_account")] public string RefundAccount { get; set; }
        /// <summary>
        /// 异步接收微信支付退款结果通知的回调地址，通知URL必须为外网可访问的url
        /// </summary>
        [JsonPropertyName("notify_url")]public string NotifyUrl { get; set; }



        #endregion
        public override string GetRequestUrl()
        {
            string url = "https://api.mch.weixin.qq.com/secapi/pay/refund";
           
            return url;
        }

        public virtual void SetNofityUrl(string url)
        {
            NotifyUrl = url;
        }

        public override void InitSDK(ClientOptions _client, HttpContext context = null)
        {
            //_client.HttpClient = new HttpClient(new WxpayHandler(_client.PayOptions,true));
            //base.HttpClient = _client.HttpClient;

            AppId = _client.AppOptions.AppId;
            MchId = _client.PayOptions.MchId;
            NonceStr = Path.GetRandomFileName();

            string url= _client.PayOptions.NotifyUrl;
            NotifyUrl = url + "/refund/" + MchId+"/";
          
            AutoSetValue(); //自动处理请求参数

            SignType =SIGN_TYPE_MD5;
            Sign = MakeSign(SIGN_TYPE_MD5, _client.PayOptions.APIKey);//生成签名 非V3签名
            SetValue("sign", Sign); //保存签名 
        }
    }
}
