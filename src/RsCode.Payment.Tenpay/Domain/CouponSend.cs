using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.Domain
{
    /// <summary>
    /// 发放代金券
    /// 用于商户主动调用接口给用户发放代金券的场景，已做防小号处理，给小号发放代金券将返回错误码。
    ///注意：通过接口发放的代金券不会进入微信卡包
    /// https://pay.weixin.qq.com/wiki/doc/api/tools/sp_coupon.php?chapter=12_3&index=4
    /// </summary>
    public class CouponSend:WxPayData
    {
        #region 参数
        /// <summary>
        /// 代金券批次id
        /// </summary>
        [JsonPropertyName("coupon_stock_id")] public string CouponStockId { get; set; }

        /// <summary>
        /// openid记录数
        /// </summary>
        [JsonPropertyName("openid_count")] public int OpenIdCount { get; set; } = 1;

        /// <summary>
        /// 商户单据号
        /// 商户此次发放凭据号（格式：商户id+日期+流水号），商户侧需保持唯一性
        /// </summary>
        [Required] [JsonPropertyName("partner_trade_no")] public string PartnerTradeNo { get; set; }

        /// <summary>
        /// 用户标识
        /// trade_type=JSAPI时（即JSAPI支付），此参数必传，此参数为微信用户在商户对应appid下的唯一标识。 
        /// 企业号请使用【企业号OAuth2.0接口】获取企业号内成员userid，再调用【企业号userid转openid接口】进行转换
        /// </summary>
        [JsonPropertyName("openid")] public string OpenId { get; set; } 

        /// <summary>
        ///微信支付分配的公众账号ID（企业号corpid即为此appId）
        /// </summary>
        [Required]
        [JsonPropertyName("appid")]
        public string AppId { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        [Required] [JsonPropertyName("mch_id")] public string MchId { get; set; }

        /// <summary>
        /// 操作员
        /// </summary>
        [JsonPropertyName("op_user_id")]
        public string OpUserId { get; set; } 

        /// <summary>
        /// 设备号
        /// </summary>
        [JsonPropertyName("device_info")] public string DeviceInfo { get; set; }

        [Required]
        [JsonPropertyName("nonce_str")]
        public string NonceStr { get { return GetNonceStr(); } }
        [Required]
        [JsonPropertyName("sign")]
        public string Sign
        {
            get;
            set;
        }

        /// <summary>
        /// 协议版本
        /// </summary>
         [JsonPropertyName("version")] public string Version { get; set; } = "1.0";

        /// <summary>
        /// 协议类型
        /// </summary>
        [JsonPropertyName("type")] public string Type { get; set; }

        
        #endregion


        public override void InitSDK(ClientOptions _client, HttpContext context = null)
        {
            //_client.HttpClient = new HttpClient(new WxpayHandler(_client.PayOptions));
           // base.HttpClient = _client.HttpClient;

            AppId = _client.AppOptions.AppId;
            MchId = _client.PayOptions.MchId;
             
            
            AutoSetValue(); //自动处理请求参数
            Sign = MakeSign(_client.PayOptions.APIKey);//生成签名 非V3签名
            SetValue("sign", Sign); //保存签名

        }

         


        public override string GetRequestUrl()
        {
            string url = "https://api.mch.weixin.qq.com/mmpaymkttransfers/send_coupon"; 
            return url;
        }
    }
}
