using RsCode;
using RsCode.Payment.Tenpay;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RsCode.Payment.Wxpay.Core
{
    public  class WxPayRequest:IWxPayRequest
    {

        IHttpClientFactory clientFactory;

        HttpClient client;
        public WxPayRequest(IHttpClientFactory _clientFactory)
        {
            clientFactory = _clientFactory;
            client = clientFactory.CreateClient(); 
            client.Timeout = TimeSpan.FromMinutes(6);
        }

        public async Task<string> RequestAsync(WxPayData data, string url,string paramFormat="xml")
        {
            try
            {
                HttpContent httpContent;
                string result = "";
                string xml = data.ToXml();  
                httpContent = new StringContent(xml, Encoding.UTF8, "text/xml");
              
                if (paramFormat == "json")
                {
                    xml = data.ToJson();
                    httpContent = new StringContent(xml, Encoding.UTF8, "application/json");
                }

                using (var resp = await client.PostAsync(url, httpContent))
                using (var content = resp.Content)
                {
                    result = await content.ReadAsStringAsync();
                }
                return result;
            }
            catch (Exception e)
            {
               // Log.Error(e.Message);
                throw new Exception(e.Message);
            }
        
        }

        /// <summary>
        /// 使用证书请求
        /// </summary>
        /// <param name="data"></param>
        /// <param name="url"></param>
        /// <param name="certPath"></param>
        /// <param name="certPwd"></param>
        /// <param name="paramType"></param>
        /// <returns></returns>
        public  async Task<string> RequestAsync(WxPayData data, string url,string certPath, string certPwd, string paramFormat="xml")
        {
            string result = "";//返回结果 
            try
            {
                //证书
                var root = AppContext.BaseDirectory;
                certPath = Path.Combine(root, certPath);
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    certPath = certPath.Replace("/", "\\");
                }
                X509Certificate2 cert = new X509Certificate2(certPath, certPwd);

                var handler = new HttpClientHandler
                {
                    ClientCertificateOptions = ClientCertificateOption.Manual,
                    SslProtocols = SslProtocols.Tls12,
                    ServerCertificateCustomValidationCallback = (x, y, z, m) => true,
                }; 
                handler.ClientCertificates.Add(cert); 
                var httpClient = new HttpClient(handler);

                string xml = data.ToXml();
                byte[] d = System.Text.Encoding.UTF8.GetBytes(xml);
                httpClient.DefaultRequestHeaders.Add("ContentType", "text/xml");
                httpClient.DefaultRequestHeaders.Add("ContentLength", d.Length.ToString());
                HttpContent httpContent = new StringContent(xml, Encoding.UTF8, "text/xml");
                
                if(paramFormat == "json")
                {
                    xml = data.ToJson();
                     d = System.Text.Encoding.UTF8.GetBytes(xml);
                    httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
                    httpClient.DefaultRequestHeaders.Add("ContentLength", d.Length.ToString());
                     httpContent = new StringContent(xml, Encoding.UTF8, "application/json");
                }
                 

                using (var resp = await httpClient.PostAsync(url, httpContent))
                using (var content = resp.Content)
                {
                    result = await content.ReadAsStringAsync();
                }
            }
            catch (System.Threading.ThreadAbortException e)
            {
                //Log.Error(string.Format("Exception message: {0}", e.Message));
                System.Threading.Thread.ResetAbort();
            }
            catch (WebException e)
            {
               // Log.Error(e.ToString());
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    //Log.Error("HttpService", "StatusCode : " + ((HttpWebResponse)e.Response).StatusCode);
                    //Log.Error("HttpService", "StatusDescription : " + ((HttpWebResponse)e.Response).StatusDescription);
                }
                throw new Exception(e.ToString());
            }
            catch (Exception e)
            {
                //Log.Error("HttpService", e.ToString());
                throw new Exception(e.ToString());
            }

            return result;

        }

    }
}
