/*
 * 交易宝
 * 作者：河南软商网络科技有限公司
 */
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net.Http;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.Domain
{
    /// <summary>
    /// 交易保障
    /// https://pay.weixin.qq.com/wiki/doc/api/micropay.php?chapter=9_14&index=8
    /// https://pay.weixin.qq.com/wiki/doc/api/jsapi.php?chapter=9_8&index=9
    /// </summary>
    public class Report:WxPayData
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
        /// 设备号
        /// </summary>
        [JsonPropertyName("device_info")]
        public string DeviceInfo { get; set; }
        /// <summary>
        /// 随机字符串，不长于32位
        /// </summary>
        [Required] [JsonPropertyName("nonce_str")] public string NonceStr { get; set; }
        [Required] [JsonPropertyName("sign")] public string Sign { get; set; }


        [Required] [JsonPropertyName("sign_type")] public string SignType { get; set; }

        /// <summary>
        /// 接口URL
        /// 刷卡支付终端上报统一填：https://api.mch.weixin.qq.com/pay/batchreport/micropay/total
        /// </summary>
        [Required] [JsonPropertyName("interface_url")] public string InterfaceUrl { get; set; }



        /// <summary>
        /// 接口耗时	
        /// </summary>
        [JsonPropertyName("execute_time")] public string ExecuteTime { get; set; }
        /// <summary>
        /// 返回状态码
        /// </summary>
        [JsonPropertyName("return_code")] public string ReturnCode { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>
        [JsonPropertyName("return_msg")] public string ReturnMsg { get; set; }
        /// <summary>
        /// 业务结果
        /// </summary>
        [JsonPropertyName("result_code")] public string ResultCode { get; set; }
        [JsonPropertyName("err_code")] public string ErrorCode { get; set; }
        /// <summary>
        /// 错误代码描述	
        /// </summary>
        [JsonPropertyName("err_code_des")] public string ErrCodeDes { get; set; }
        /// <summary>
        /// 商户订单号
        /// </summary>
        [JsonPropertyName("out_trade_no")] public string OutTradeNo { get; set; }



        /// <summary>
        /// 商户上报时间	 
        /// 系统时间，格式为yyyyMMddHHmmss
        /// </summary>
        [JsonPropertyName("time")] public string Time { get; set; }




        /// <summary>
        /// 发起接口调用时的机器IP 
        /// </summary>
        [Required] [JsonPropertyName("user_ip")] public string UserIp { get; set; }

        /// <summary>
        /// 上报数据包
        /// </summary>
         [JsonPropertyName("trades")] public string Trades { get; set; }
        #endregion
        public override string GetRequestUrl()
        {
            string url = "https://api.mch.weixin.qq.com/payitil/report";
            return url;
        }

        public override void InitSDK(ClientOptions _client, HttpContext context = null)
        {
           // _client.HttpClient = new HttpClient(new WxpayHandler(_client.PayOptions));
            //base.HttpClient = _client.HttpClient;

            AppId = _client.AppOptions.AppId;
            MchId = _client.PayOptions.MchId;
            NonceStr = Path.GetRandomFileName();
            UserIp = base.GetIp(context);
            AutoSetValue(); //自动处理请求参数

            Sign = MakeSign(_client.PayOptions.APIKey);//生成签名 非V3签名
            SetValue("sign", Sign); //保存签名 
        }
    }
}
