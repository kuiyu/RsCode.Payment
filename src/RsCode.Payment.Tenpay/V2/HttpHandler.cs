/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RsCode.Payment.Tenpay.V2
{
    /// <summary>
    /// V2版本httphandler
    /// </summary>
    public class HttpHandler: DelegatingHandler
    {
        string USER_AGENT = $"RsCode.Payment.Tenpay/{Environment.OSVersion} ({Environment.Version}) .netcore/";

        PayOptions payOptions; 
        public HttpHandler(PayOptions _payOptions,bool useCert=true)
        {
            payOptions = _payOptions;
            HttpClientHandler handler = new HttpClientHandler();
            if(useCert)
            {
                try
                { 
                    string certPath = Path.Combine(Environment.CurrentDirectory, payOptions.PublicKeyCertPath);

                    handler.ClientCertificates.Add(new X509Certificate2(certPath, payOptions.MchId)); 
                }
                catch (Exception e)
                {
                    throw new Exception($"ca err(证书错误) {e.Message}");
                } 
            } 
            InnerHandler = handler; 
        }

        protected async override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
           
            var content = request.Content;
                string xml = await content.ReadAsStringAsync();
                byte[] data = Encoding.UTF8.GetBytes(xml);

                request.Headers.UserAgent.Add(new ProductInfoHeaderValue(new ProductHeaderValue("Unknown")));
                request.Headers.Add("ContentLength", data.Length.ToString());
                request.Headers.Add("ContentType", "text/xml"); 
                return await base.SendAsync(request, cancellationToken);
           
        }

         
         
    }
}
