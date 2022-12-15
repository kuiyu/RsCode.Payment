/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 协议:MIT License 2.0 
 * 作者:河南软商网络科技有限公司 
 * 项目己托管于  
 * github
   https://github.com/kuiyu/RsCode.Payment.git
 */
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RsCode.Payment.Tenpay.V3
{

    public class TenpayClientV3:ITenpayClient
    {
        PayOptions payOptions;
        List<PayOptions> PayOptions;
        ILogger log;
        readonly TenpayHttpClientV3 httpClient;

        IHttpContextAccessor httpContextAccessor;
        public string Ver => "3";
        IMemoryCache cache;
        public TenpayClientV3(
            TenpayHttpClientV3 _httpClient,
               ILogger<TenpayClientV3> _logger,
               IOptionsSnapshot<List<PayOptions>> _payOptions,
               IHttpContextAccessor _httpContextAccessor,
               IMemoryCache _cache
             
               )
        {
            log = _logger; 
            httpClient = _httpClient; 
            PayOptions = _payOptions.Value;
            httpContextAccessor = _httpContextAccessor;
            cache = _cache;
        }
        public string GetIp()
        {
            var httpContext = httpContextAccessor;
            var ip= httpContext.HttpContext?.Request.Headers["X-Real-IP"].FirstOrDefault() ?? httpContext.HttpContext?.Request.HttpContext.Connection.RemoteIpAddress.ToString();
            return string.IsNullOrWhiteSpace(ip) ? "0.0.0.0" : ip;
        }
        public PayOptions UseMchId(string mchId)
        {
            payOptions = PayOptions.FirstOrDefault(o => o.MchId == mchId);
            if (payOptions == null)
                throw new Exception($"支付参数配置有误:未找到指定商号{mchId}配置");

            var httpHandler = new HttpHandler(payOptions);
            httpClient.LoadHandler(httpHandler);
            return payOptions;
        }

        public async Task<T> SendAsync<T>(TenpayBaseRequest t,string certSerialNo="") where T : TenpayBaseResponse
        { 
            var url = t.GetApiUrl();
            var method = t.RequestMethod().ToUpper();
            if(method=="GET")
            {                
                var res=await httpClient.GetAsync<T>(url);
                return res;
            }
            
            if(method=="POST")
            {
                string s = JsonSerializer.Serialize(t,t.GetType());
                HttpContent httpContent =  new StringContent(s, Encoding.UTF8, "application/json");
                
                if(!string.IsNullOrWhiteSpace(certSerialNo))
                httpContent.Headers.Add("Wechatpay-Serial", certSerialNo);

                var res=await httpClient.PostAsync<T>(url, httpContent);
                return res;
            }
            return default(T);
        }

        public async Task<T> GetNotifyDataAsync<T>(HttpRequest request) where T : NotifyData
        {
            try
            { 
                //https://wechatpay-api.gitbook.io/wechatpay-api-v3/qian-ming-zhi-nan-1/qian-ming-yan-zheng
                //1.获取平台证书
                var publicKey = await GetPublicKeyAsync();

                //2.构造验签名串 
                StringValues timestamp = "";
                StringValues nonce = ""; 
                request.Headers.TryGetValue("Wechatpay-Timestamp", out timestamp);
                request.Headers.TryGetValue("Wechatpay-Nonce", out nonce);
                //接收从微信后台POST过来的数据
                var body = await new StreamReader(request.Body, Encoding.UTF8).ReadToEndAsync();
                var signSourceString = $"{timestamp.ToString()}\n{nonce.ToString()}\n{body}\n";

                //3.获取应答签名
                StringValues wxpaySign = "";
                request.Headers.TryGetValue("Wechatpay-Signature", out wxpaySign);

                //4.验证签名
                var checkSign =TenpayTool.VerifySign(publicKey, wxpaySign.ToString(), signSourceString);
                if (checkSign)
                {
                    var notifyData = JsonSerializer.Deserialize<NotifyDataV3>(body);
                    //解密数据 
                    var res = notifyData.GetResult(payOptions.APIKeyV3);
                    return JsonSerializer.Deserialize<T>(res); 
                }
                else
                {
                    throw new Exception("验签失败");
                }
            }
            catch (Exception ex)
            {
                log.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

       
        /// <summary>
        /// 微信平台证书公钥
        /// </summary>
        /// <returns></returns>
        public async Task<byte[]> GetPublicKeyAsync()
        {
            string cacheKey = "TenpayCertPublicKey";
            byte[] publicKey = null;
            cache.TryGetValue<byte[]>(cacheKey,out publicKey);
            if(publicKey==null)
            {
                //微信平台证书
                var wxCerts = await SendAsync<CertificatiesDownloadResponse>(new CertificatiesDownloadRequest());
                var wxCert = wxCerts.Data.FirstOrDefault().CertificateInfo;

                var text = wxCert.Decrypt(payOptions.APIKeyV3);
                publicKey = Encoding.UTF8.GetBytes(text);
                cache.Set<byte[]>(cacheKey, publicKey, DateTimeOffset.Now.AddHours(11));
            } 
            return publicKey;
        }
    }
}
