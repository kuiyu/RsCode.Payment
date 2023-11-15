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
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.Domain
{
    /// <summary>
    /// 统一下单API
    /// https://pay.weixin.qq.com/wiki/doc/api/jsapi.php?chapter=9_1
    /// https://pay.weixin.qq.com/wiki/doc/api/native.php?chapter=9_1
    /// </summary> 
    public class Order : WxPayData
    { 

        #region 参数
        /// <summary>
        ///微信支付分配的公众账号ID（企业号corpid即为此appId）
        /// </summary>
        [Required]
        [JsonPropertyName("appid")]
        public string AppId { get; set; }

        /// <summary>
        /// 子商户号
        /// </summary>
        [Required] [JsonPropertyName("mch_id")] public string MchId { get; set; }

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
        /// 答名类型
        /// </summary>
        [JsonPropertyName("sign_type")]
        public string SignType { get; set; } = SIGN_TYPE_HMAC_SHA256;

        /// <summary>
        /// 商品描述
        /// </summary>
        [Required] [JsonPropertyName("body")] public string Body { get; set; }

        /// <summary>
        /// 商品详情
        /// </summary>
        [JsonPropertyName("detail")] public string Detail { get; set; }

        /// <summary>
        /// 附加数据
        /// </summary>
        [JsonPropertyName("attach")] public string Attach { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        [Required] [JsonPropertyName("out_trade_no")] public string OutTradeNo { get; set; }

        /// <summary>
        /// 标价币种
        /// </summary>
        [JsonPropertyName("fee_type")] public string FeeType { get; set; }

        /// <summary>
        /// 标价金额
        /// </summary>
        [Required] [JsonPropertyName("total_fee")] public int TotalFee { get; set; }

        /// <summary>
        /// 终端IP
        /// </summary>
        [Required] [JsonPropertyName("spbill_create_ip")] public string SpBillCreateIp { get; set; }

        /// <summary>
        /// 交易起始时间
        /// </summary>
        [JsonPropertyName("time_start")] public string TimeStart { get; set; }

        /// <summary>
        /// 交易结束时间
        /// </summary>
        [JsonPropertyName("time_expire")] public string TimeExpire { get; set; }

        /// <summary>
        /// 商品标记
        /// </summary>
        [JsonPropertyName("goods_tag")] public string GoodsTag { get; set; }

        /// <summary>
        /// 通知地址
        /// </summary>
        [Required] [JsonPropertyName("notify_url")] public string NotifyUrl { get; set; } 

        /// <summary>
        /// 交易类型
        /// JSAPI，NATIVE，APP，MWEB
        /// </summary>
        [Required] [JsonPropertyName("trade_type")] public string TradeType { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        [JsonPropertyName("product_id")] public string ProductId { get; set; }

        /// <summary>
        /// 指定支付方式
        /// </summary>
        [JsonPropertyName("limit_pay")] public string LimitPay { get; set; }

        /// <summary>
        /// 用户标识
        /// trade_type=JSAPI时（即JSAPI支付），此参数必传，此参数为微信用户在商户对应appid下的唯一标识。 
        /// 企业号请使用【企业号OAuth2.0接口】获取企业号内成员userid，再调用【企业号userid转openid接口】进行转换
        /// </summary>
        [JsonPropertyName("openid")] public string OpenId { get; set; }

        /// <summary>
        /// 电子发票入口开放标识 传入Y时，支付成功消息和支付详情页将出现开票入口。
        /// </summary>
        [JsonPropertyName("receipt")]
        public string Receipt { get; set; }

        /// <summary>
        /// 场景信息
        /// </summary>
        [JsonPropertyName("scene_info")] public string SceneInfo { get; set; }
        #endregion

         
        public override void InitSDK(ClientOptions _client, HttpContext context = null)
        {
           // _client.HttpClient = new HttpClient(new WxpayHandler(_client.PayOptions));
           // base.HttpClient = _client.HttpClient; 
            AppId = _client.AppOptions.AppId;
            MchId = _client.PayOptions.MchId;

            string notifyUrl = _client.PayOptions.NotifyUrl + "/unifiedorder/" + MchId;
            NotifyUrl = notifyUrl;
            SpBillCreateIp = GetIp(context); 
            TradeType=TradeType??SetTradeType(_client.AppOptions);
            AutoSetValue(); //自动处理请求参数
            Sign = MakeSign(_client.PayOptions.APIKey);//生成签名 非V3签名
            SetValue("sign", Sign); //保存签名
            
        }

        public virtual void SetNofityUrl(string url)
        {
            NotifyUrl = url;
        }


        public override string GetRequestUrl()
        {
            string url = "https://api.mch.weixin.qq.com/pay/unifiedorder";
            string url2 = "https://api2.mch.weixin.qq.com/pay/unifiedorder";
            return url;
        }

        ////public virtual async Task<WxPayData> test()
        ////{
        ////    WxPayData result = new WxPayData();
        ////    string response = "";
        ////    string xml = ToXml();
        ////    StringContent content = new StringContent(xml, Encoding.UTF8, "text/xml");
        ////    var url = GetRequestUrl();
        ////    using (var resp=await client.HttpClient.PostAsync(GetRequestUrl(), content)) 
        ////    using (var c = resp.Content)
        ////    {
        ////        response= await c.ReadAsStringAsync();
        ////    }
        ////    result.FromXml(response);
        ////    return result;

        ////}
        //public virtual async Task<WxPayData> SendAsync()
        //{
        //    if (client == null)
        //        throw new Exception("未配置支付参数");

        //    int timeOut = 10;
        //    WxPayData result = new WxPayData();
            
        //    var start = DateTime.Now;//请求开始时间
        //    string xml = ToXml();
        //    Log.Info("request=" + xml);
        //    var url = GetRequestUrl(); 
        //    string response = await client.HttpClient.PostAsync(xml, url, false, timeOut);//调用HTTP通信接口以提交数据到API 
        //    Log.Info("Response=" + response);
        //    //var end = DateTime.Now;
        //    //int timeCost = (int)((end - start).TotalMilliseconds);//获得接口耗时 
        //    //ReportCostTime(url, timeCost, result);//测速上报  
        //    result.FromXml(response);

        //    return result;
        //}
         

        
    }
}
