using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net.Http;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.Domain
{

    /// <summary>
    /// 下载资金账单
    /// https://pay.weixin.qq.com/wiki/doc/api/micropay.php?chapter=9_18&index=7
    /// https://pay.weixin.qq.com/wiki/doc/api/jsapi.php?chapter=9_18&index=7
    /// </summary>
    public class DownloadFundFlow:WxPayData
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
        /// 签名类型
        /// </summary>
        [JsonPropertyName("sign_type")]
        public string SignType { get; set; }
        /// <summary>
        /// 资金账单日期  下载对账单的日期，格式：20140603
        /// </summary>
        [JsonPropertyName("bill_date")] public string BillDate { get; set; }

        /// <summary>
        /// 账单的资金来源账户：  Basic 基本账户 Operation 运营账户 Fees 手续费账户
        /// </summary>
        [JsonPropertyName("account_type")] public string AccountType { get; set; }

        /// <summary>
        /// 压缩账单  非必传参数，固定值：GZIP，返回格式为.gzip的压缩包账单。不传则默认为数据流形式。
        /// </summary>
        [JsonPropertyName("tar_type")] public string TarType { get; set; }


        #endregion
        public override string GetRequestUrl()
        {
            string url = "https://api.mch.weixin.qq.com/pay/downloadfundflow";
            return url;
        }

        public override void InitSDK(ClientOptions _client, HttpContext context = null)
        {
           // _client.HttpClient = new HttpClient(new WxpayHandler(_client.PayOptions,true));
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
