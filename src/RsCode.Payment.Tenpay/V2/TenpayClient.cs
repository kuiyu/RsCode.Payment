/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 协议:MIT License 2.0 
 * 作者:河南软商网络科技有限公司 
 * 项目己托管于  
 * github
   https://github.com/kuiyu/RsCode.Payment.git
 */

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RsCode.Payment.Tenpay.V2
{
    public class TenpayClient : ITenpayClient
    {
        PayOptions currentPayOptions;
        List<PayOptions> PayOptions;
        ILogger logger;
        readonly TenpayHttpClient httpClient;
        IHttpContextAccessor httpContextAccessor;
        public string Ver => "2";

        public TenpayClient(
            TenpayHttpClient _httpClient,
               ILogger<TenpayClient> _logger,
               IOptionsSnapshot <List<PayOptions>> _payOptions,
               IHttpContextAccessor _httpContextAccessor)
        {
            logger = _logger;
            httpClient = _httpClient;
            PayOptions = _payOptions.Value;
            httpContextAccessor = _httpContextAccessor;
        }

        public string GetIp()
        {
            var httpContext = httpContextAccessor;
            var ip = httpContext.HttpContext?.Request.Headers["X-Real-IP"].FirstOrDefault() ?? httpContext.HttpContext?.Request.HttpContext.Connection.RemoteIpAddress.ToString();
            return string.IsNullOrWhiteSpace(ip) ? "127.0.0.1" : ip;
        }
        public async  Task<T> SendAsync<T>(TenpayBaseRequest request, string certSerialNo = "") where T : TenpayBaseResponse
        {
            try
            {
                if (currentPayOptions == null)
                {
                    throw new Exception("未调用UseMchId()方法");
                }

                var url = request.GetApiUrl();
                var method = request.RequestMethod().ToUpper();


                if (method == "GET")
                {
                    var res = await httpClient.GetAsync<T>(url);
                    return res;
                }

                if (method == "POST")
                {
                    //处理签名:如果签名用微信验签通过，还是报签名错误，更换一下签名类型
                    var data = request as WxPayData;
                    string signType = data.GetSignType();
                    data.AutoSetValue();

                    string sign = data.MakeSign(signType, currentPayOptions.APIKey);
                    data.SetValue("sign", sign);


                    string xml = data.ToXml();
                    HttpContent httpContent = new StringContent(xml, Encoding.UTF8, "text/xml");

                    var res = await httpClient.PostAsync<T>(url, httpContent);
                    return res;
                }
                return default(T);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                throw e;
            }
            
        }

        public PayOptions UseMchId(string mchId)
        {
            currentPayOptions = PayOptions.FirstOrDefault(o => o.MchId == mchId);
            if (currentPayOptions == null)
                throw new Exception($"支付参数配置有误,未找到支付配置MchId={mchId}");

            var httpHandler = new HttpHandler(currentPayOptions);
            httpClient.LoadHandler(httpHandler);
            return currentPayOptions;
        }

        public async Task<T> GetNotifyDataAsync<T>(HttpRequest request) where T:NotifyData
        {
            var body = await new StreamReader(request.Body, Encoding.UTF8).ReadToEndAsync();
            logger.LogInformation($"notify body={body}");
            var data = new WxPayData();
            data.FromXml(body);

            if(data.GetValue("return_code").ToString()== "SUCCESS")
            { 
                var s = data.ToJson();
                var result= JsonSerializer.Deserialize<T>(s);
                if(CheckSign(result))
                {
                    return result;
                }
                throw new Exception("验签失败");
            }
            else
            {
                throw new Exception(data.GetValue("return_msg").ToString());
            }
        }

        public bool CheckSign(NotifyData data)
        {
            if (currentPayOptions == null)
            {
                throw new Exception("未调用UseMchId()方法");
            }
            //验签
            var appSign = data.MakeSign(currentPayOptions.APIKey).ToUpper();
            var wxSign = data.GetValue("sign").ToString();
            return appSign == wxSign ? true : false; 
        }

        /// <summary>
        /// 微信平台证书公钥
        /// </summary>
        /// <returns></returns>
        public async Task<byte[]> GetPublicKeyAsync()
        {
            return null;
            //TODO:
            //string cacheKey = "TenpayCertPublicKey";
            //byte[] publicKey = null;
            //cache.TryGetValue<byte[]>(cacheKey, out publicKey);
            //if (publicKey == null)
            //{
            //    //微信平台证书
            //    var wxCerts = await SendAsync<CertificatiesDownloadResponse>(new CertificatiesDownloadRequest());
            //    var wxCert = wxCerts.Data.FirstOrDefault().CertificateInfo;

            //    var text = wxCert.Decrypt(payOptions.APIKeyV3);
            //    publicKey = Encoding.UTF8.GetBytes(text);
            //    cache.Set<byte[]>(cacheKey, publicKey, DateTimeOffset.Now.AddHours(11));
            //}
            //return publicKey;
        }
    }
}
