using AspectCore.DependencyInjection;
using AspectCore.Extensions.DataValidation;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RsCode;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace RsCode.Payment.Tenpay.Domain
{


    /// <summary>
    /// 扫码支付API
    /// </summary>
    public  class Micropay:WxPayData
    {
        public IDataState DataState { get; set; }
        [FromServiceContext]
        HttpClient httpClient { get; set; }
        ClientOptions client; 
        
        public Micropay()
        {

        }

        public override void InitSDK(ClientOptions _client,HttpContext context=null)
        {
            client = _client;
            base.GetIp(context); 
            AppId = client.AppOptions.AppId;
            MchId = client.PayOptions.MchId;
        }

        string apiUrl = "https://api.mch.weixin.qq.com/pay/micropay";
        string apiUrl2 = "https://api2.mch.weixin.qq.com/pay/micropay";

        #region 参数
        /// <summary>
        /// 公众账号ID
        /// </summary>
        [Required(ErrorMessage = "未配置微信分配的公众账号ID")] 
        [JsonPropertyName("appid")]
        public string AppId { get; set; }
        /// <summary>
        /// 商户号
        /// </summary>
        [Required(ErrorMessage = "未配置微信商户号")] 
        [JsonPropertyName("mch_id")] public string MchId { get; set; }

        /// <summary>
        /// 设备号
        /// </summary>
        [JsonPropertyName( "device_info")] public string DeviceInfo { get; set; }
       

        [Required]
        [JsonPropertyName( "sign")]
        string Sign  { get {
               return MakeSign(client.PayOptions.APIKey);
            } }
        [JsonPropertyName( "sign_type")]
        public string SignType { get; set; } = SIGN_TYPE_HMAC_SHA256;
        [Required(ErrorMessage = "缺少商品描述")] 
        [JsonPropertyName( "body")] 
        public string Body { get; set; }

        [JsonPropertyName( "detail")] public string Detail { get; set; }

        [JsonPropertyName( "attach")] public string Attach { get; set; }

        [Required(ErrorMessage = "缺少商户系统内部订单号")] 
        [JsonPropertyName( "out_trade_no")] 
        public string OutTradeNo { get; set; }

        [Required(ErrorMessage = "缺少订单金额")] [JsonPropertyName( "total_fee")] 
        public int TotalFee { get; set; }

        [JsonPropertyName( "fee_type")] public string FeeType { get; set; }

        [Required(ErrorMessage = "缺少终端IP")] 
        [JsonPropertyName( "spbill_create_ip")] 
        public string SpbillCreateIp { get; set; }

        [JsonPropertyName( "goods_tag")] 
        public string GoodsTag { get; set; }

        [JsonPropertyName( "limit_pay")] 
        public string LimitPay { get; set; }

        [JsonPropertyName( "time_start")] 
        public string TimeStart { get; set; }

        [JsonPropertyName( "time_expire")] 
        public string TimeExpire { get; set; }

        [JsonPropertyName( "receipt")] 
        public string Receipt { get; set; }

        /// <summary>
        /// 扫码支付授权码，设备读取用户微信中的条码或者二维码信息
        /// </summary>
        [Required(ErrorMessage ="扫码支付授权码未配置")] 
        [JsonPropertyName("auth_code")]
        public string AuthCode { get; set; }

        /// <summary>
        /// 场景信息
        /// </summary>
        [JsonPropertyName( "scene_info")] 
        public string SceneInfo { get; set; }
        #endregion
        public virtual async Task< WxPayData> SendAsync()
        {
            if (client == null)
                throw new Exception("未配置支付参数");
            int timeOut = 10;
            WxPayData result = null; 
            if (DataState.IsValid)
            {
                AutoSetValue();

                var start = DateTime.Now;//请求开始时间
                  string xml = ToXml();
                //Log.Debug("WxPayApi", "MicroPay request : " + xml);
                 string response = await httpClient.PostAsync(xml, apiUrl, false, timeOut);//调用HTTP通信接口以提交数据到API 
                //Log.Info("Response=" + response);
                //var end = DateTime.Now;
                //int timeCost = (int)((end - start).TotalMilliseconds);//获得接口耗时 
                //ReportCostTime(url, timeCost, result);//测速上报  
                result.FromXml(response);
            }
            return result;
        }
         
    }
  
}
