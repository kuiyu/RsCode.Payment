using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
namespace RsCode.Payment.Tenpay.Media
{

    public class HttpHandler : DelegatingHandler
    { 
        private readonly string json;
       
        PayOptions payOptions;
 
        public HttpHandler(PayOptions  _payOptions, string json = "")
        {
            payOptions = _payOptions;
            HttpClientHandler handler = new HttpClientHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.SslProtocols = SslProtocols.Tls12;
            try
            {
                string certPath = Path.Combine(Environment.CurrentDirectory, payOptions.PublicKeyCertPath);
                handler.ClientCertificates.Add(new X509Certificate2(certPath,payOptions.MchId,
                    X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.MachineKeySet));
              
            }
            catch (Exception e)
            {
                throw new Exception("ca err(证书错误)");
            }
            handler.SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls;
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            InnerHandler = handler;
            this.json = json;
        }

        protected async override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var auth = await BuildAuthAsync(request);
            string value = $"WECHATPAY2-SHA256-RSA2048 {auth}";
            request.Headers.Add("Authorization", value);
            request.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.143 Safari/537.36");
            MediaTypeWithQualityHeaderValue mediaTypeWithQualityHeader = new MediaTypeWithQualityHeaderValue("application/json");
            request.Headers.Accept.Add(mediaTypeWithQualityHeader);
            request.Headers.AcceptCharset.Add(new StringWithQualityHeaderValue("utf-8"));
            return await base.SendAsync(request, cancellationToken);
        }

        protected async Task<string> BuildAuthAsync(HttpRequestMessage request)
        {
            string method = request.Method.ToString();
            string body = "";
            if (method == "POST" || method == "PUT" || method == "PATCH")
            {
                if (!string.IsNullOrEmpty(json))
                    body = json;
                else
                {
                    var content = request.Content;
                    body = await content.ReadAsStringAsync();
                }
            }
            string uri = request.RequestUri.PathAndQuery;
            var timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
            string nonce = Guid.NewGuid().ToString("n");
            string message = $"{method}\n{uri}\n{timestamp}\n{nonce}\n{body}\n";
            string signature = TenpayTool.Sign(message, payOptions); 
            var certSerialNo = payOptions.GetPrivateKeyCert().GetSerialNumberString();
            return $"mchid=\"{payOptions.MchId}\",nonce_str=\"{nonce}\",timestamp=\"{timestamp}\",serial_no=\"{certSerialNo}\",signature=\"{signature}\"";
        }


         
    
    }

}
