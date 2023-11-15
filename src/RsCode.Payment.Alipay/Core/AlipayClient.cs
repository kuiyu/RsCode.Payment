/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 协议:MIT License 2.0 
 * 作者:河南软商网络科技有限公司 
 * 项目己托管于  
 * github
   https://github.com/kuiyu/RsCode.Payment.git
 */
using Aop.Api;
using Aop.Api.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RsCode.Payment.Alipay
{
    public  class AlipayClient: IAlipayClient
    {
        ILogger log;
        List<PayOptions> payOptions;
        PayOptions currentConfig;
        IAopClient Client;
        IHttpContextAccessor httpContextAccessor;
        public AlipayClient(IOptionsSnapshot<List<PayOptions>> _payOptions, IHttpContextAccessor _httpContextAccessor, ILogger<AlipayClient> _log)
        {
            payOptions = _payOptions.Value;
            httpContextAccessor = _httpContextAccessor;
            log = _log;
        }
        
      public PayOptions UseAppId(string appId="")
        {
            if(string.IsNullOrWhiteSpace(appId)) 
            {
                currentConfig = payOptions.FirstOrDefault(o=> o.PaymentChannel == PaymentChannel.Alipay);
            }else
            {
                 currentConfig = payOptions.FirstOrDefault(o => o.MchId == appId&&o.PaymentChannel== PaymentChannel.Alipay);
            }
            
            if (currentConfig == null)
                throw new Exception($"支付宝参数配置有误:未找到指定AppId{appId}配置");
            return currentConfig;
        }

        public IAopClient InitClient()
        {
            //如果配置了PlatformRootCertPath，则证书优先模式
            IAopClient client = null;
            if(currentConfig==null)
            {
                throw new Exception("please first call UseAppId()");
            }

            if(currentConfig.PlatformRootCert.StartsWith("cert"))
            {
                //设置证书相关参数
                CertParams certParams = new CertParams
                {
                    RootCertPath = Path.Combine(Environment.CurrentDirectory, currentConfig.PlatformRootCert),// "支付宝根证书路径"
                AlipayPublicCertPath = Path.Combine(Environment.CurrentDirectory, currentConfig.PlatformPublicKey),// "支付宝公钥证书路径",
                    AppCertPath =Path.Combine(Environment.CurrentDirectory, currentConfig.PublicKey), // "商户应用证书路径",
            };
                string APPID = currentConfig.MchId;
                string APP_PRIVATE_KEY = GetPrivateKey(currentConfig.PrivateKey);
              
                 client = new DefaultAopClient("https://openapi.alipay.com/gateway.do", APPID, APP_PRIVATE_KEY, "json", "1.0", "RSA2", "UTF-8", false, certParams);
            }
            else
            {
                string APPID = currentConfig.MchId;
                string APP_PRIVATE_KEY = GetPrivateKey( currentConfig.PrivateKey);
                string CHARSET = "utf-8";
                string ALIPAY_PUBLIC_KEY = currentConfig.PlatformPublicKey;
                client = new DefaultAopClient("https://openapi.alipay.com/gateway.do", APPID, APP_PRIVATE_KEY, "json", "1.0", "RSA2", ALIPAY_PUBLIC_KEY, CHARSET, false);
            }
            Client= client;
            return client;
                }

        string GetPrivateKey(string privateKey)
        {
            if(privateKey.StartsWith("cert"))
            {
                string certPath = Path.Combine(Environment.CurrentDirectory, privateKey);
                return File.ReadAllText(certPath);
            }
            else
            {
                return privateKey;
            }
        }
 
        

        public Dictionary<string,string> NotifyData(HttpRequest request)
        {
            try
            {
                var data = GetParameters(request); 
                 
                bool check = false;
                if(currentConfig.PlatformPublicKey.StartsWith("cert"))
                {
                    var certPath=Path.Combine(Environment.CurrentDirectory,currentConfig.PlatformPublicKey);
                     check = AlipaySignature.RSACertCheckV1(data, certPath, "UTF-8", "RSA2");
                }
                else
                {
                     check = AlipaySignature.RSACheckV1(data, currentConfig.PlatformPublicKey, "UTF-8", "RSA2", false);
                }
                
                if (check)
                {
                    return data;
                }else
                {
                    log.LogError("签名校验失败");
                }
                return null;
            }
            catch (Exception e)
            {
                log.LogError(e.Message);
                return null;
            }
            
        }
     

        private Dictionary<string, string> GetParameters(HttpRequest request)
        {
            var parameters = new Dictionary<string, string>();
            if (request.Method == "POST")
            {
                foreach (var iter in request.Form)
                {
                    var s = System.Text.RegularExpressions.Regex.Unescape(iter.Value);
                    parameters.Add(iter.Key, s);
                }
            }
            else
            {
                foreach (var iter in request.Query)
                {
                    var s = System.Text.RegularExpressions.Regex.Unescape(iter.Value);
                    parameters.Add(iter.Key, s);
                }
            }
            return parameters;
        }

        public string GetIp()
        {
            var httpContext = httpContextAccessor;
            var ip = httpContext.HttpContext?.Request.Headers["X-Real-IP"].FirstOrDefault() ?? httpContext.HttpContext?.Request.HttpContext.Connection.RemoteIpAddress.ToString();
            return string.IsNullOrWhiteSpace(ip) ? "0.0.0.0" : ip;
        }
    }
}
