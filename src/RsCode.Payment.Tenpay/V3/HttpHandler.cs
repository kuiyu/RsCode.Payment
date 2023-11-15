/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace RsCode.Payment.Tenpay.V3
{
    public class HttpHandler : DelegatingHandler
    {
      
        PayOptions payOptions;
        public HttpHandler(PayOptions _payOptions)
        {
            
            payOptions = _payOptions;
            HttpClientHandler handler = new HttpClientHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.SslProtocols = SslProtocols.Tls12;
            try
            {
                string certPath = Path.Combine(Environment.CurrentDirectory, payOptions.PrivateKey);
                
                handler.ClientCertificates.Add(new X509Certificate2(certPath, payOptions.MchId,
                    X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.MachineKeySet));
                
            }
            catch (Exception e)
            {
                throw new Exception("ca err(证书错误)");
            }
            handler.SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls;
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            InnerHandler = handler;
        
        }

        protected async override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var auth = await BuildAuthAsync(request);
            string value = $"WECHATPAY2-SHA256-RSA2048 {auth}"; 
           
            request.Headers.Add("Authorization", value);
            request.Headers.Add("Accept", "application/json");
             request.Headers.UserAgent.Add(new ProductInfoHeaderValue(new ProductHeaderValue("Unknown"))); 
            
            request.Headers.AcceptCharset.Add(new StringWithQualityHeaderValue("utf-8")); 
            var certNo=TenpayTool.GetCertSerialNo(payOptions.PrivateKey, payOptions.MchId);
            if(!request.Headers.Contains("Wechatpay-Serial"))
            {
                request.Headers.Add("Wechatpay-Serial",certNo);
            }  
            return await base.SendAsync(request, cancellationToken);
        }

        protected async Task<string> BuildAuthAsync(HttpRequestMessage request)
        {
            string method = request.Method.ToString();
            string body = "";
            if (method == "POST" || method == "PUT" || method == "PATCH")
            { 
                    var content = request.Content;
                    body = await content.ReadAsStringAsync(); 
            }

            string uri = request.RequestUri.PathAndQuery;
            var timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
            string nonce = Guid.NewGuid().ToString("n");
            string message = $"{method}\n{uri}\n{timestamp}\n{nonce}\n{body}\n";
            string signature =TenpayTool.Sign(message,payOptions);

            // var certSerialNo = payOptions.GetPrivateKeyCert().GetSerialNumberString();
            var certSerialNo = TenpayTool.GetCertSerialNo(payOptions.PrivateKey, payOptions.MchId);
            return $"mchid=\"{payOptions.MchId}\",nonce_str=\"{nonce}\",timestamp=\"{timestamp}\",serial_no=\"{certSerialNo}\",signature=\"{signature}\"";
        }


       
        
    }
}