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
    /// 查询代金券批次
    /// https://pay.weixin.qq.com/wiki/doc/api/tools/sp_coupon.php?chapter=12_4&index=5
    /// </summary>
    public class CouponStockQuery:WxPayData
    {
        #region 参数
        /// <summary>
        /// 代金券批次id
        /// </summary>
        [JsonPropertyName("coupon_stock_id")] public string CouponStockId { get; set; }  

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
        [JsonPropertyName("type")] public string Type { get; set; } = "XML";


        #endregion


        public override void InitSDK(ClientOptions _client, HttpContext context = null)
        {
            //_client.HttpClient = new HttpClient(new WxpayHandler(_client.PayOptions));
            //base.HttpClient = _client.HttpClient;

            AppId = _client.AppOptions.AppId;
            MchId = _client.PayOptions.MchId;


            AutoSetValue(); //自动处理请求参数
            Sign = MakeSign(_client.PayOptions.APIKey);//生成签名 非V3签名
            SetValue("sign", Sign); //保存签名

        }




        public override string GetRequestUrl()
        {
            string url = "https://api.mch.weixin.qq.com/mmpaymkttransfers/query_coupon_stock";
            return url;
        }
    }
}
