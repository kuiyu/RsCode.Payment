using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Runtime.InteropServices;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using X509Certificate = Org.BouncyCastle.X509.X509Certificate;

namespace RsCode.Payment.Tenpay
{
    public static class HttpClientExtensions
    {
       // private static string USER_AGENT = string.Format("WXPaySDK/{3} ({0}) .net/{1} {2}", Environment.OSVersion, Environment.Version, WxPayConfig.GetConfig().GetMchID(), typeof(HttpService).Assembly.GetName().Version);

        //public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        //{
        //    //直接确认，否则打不开    
        //    return true;
        //}
        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            //直接确认，否则打不开    
            return true;
        }



        /// <summary>
        /// 执行HTTP POST请求。
        /// </summary>
        /// <param name="client">HttpClient</param>
        /// <param name="url">请求地址</param>
        /// <param name="textParams">请求参数</param>
        /// <returns>HTTP响应内容</returns>
        public static async Task<string> PostAsync(this HttpClient client, string xml, string url, bool isUseCert, int timeout)
        {
            //using (var reqContent = new StringContent(WeChatPayUtility.BuildContent(textParams), Encoding.UTF8, "application/xml"))
            //using (var resp = await client.PostAsync(url, reqContent))
            //using (var respContent = resp.Content)
            //{
            //    return await respContent.ReadAsStringAsync();
            //}

            string result = "";//返回结果

            Stream reqStream = null;

            try
            {
                //设置最大连接数

                //设置https验证方式
                //if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                //{
                //    ServicePointManager.ServerCertificateValidationCallback =
                //            new RemoteCertificateValidationCallback(CheckValidationResult);
                //} 

                //设置代理服务器
                //WebProxy proxy = new WebProxy();                          //定义一个网关对象
                //proxy.Address = new Uri(WxPayConfig.PROXY_URL);              //网关服务器端口:端口
                //request.Proxy = proxy;

                //client.DefaultRequestHeaders.Add("UserAgent", USER_AGENT);
                client.DefaultRequestHeaders.Add("ContentType", "text/xml");

                //设置POST的数据类型和长度 
                byte[] data = System.Text.Encoding.UTF8.GetBytes(xml);
                client.DefaultRequestHeaders.Add("ContentLength", data.Length.ToString());

                //是否使用证书
                if (isUseCert)
                {
                    //win.与linux路径获取
                   //  string path =HttpContext.Current.Request.PhysicalApplicationPath;
                  //    X509Certificate2 cert = new X509Certificate2(path + WxPayConfig.GetConfig().GetSSlCertPath(), WxPayConfig.GetConfig().GetSSlCertPassword());
                  //    request.ClientCertificates.Add(cert);
                  //    Log.Debug("WxPayApi", "PostXml used cert");
                }

                //往服务器写入数据
                HttpContent httpContent = new StringContent(xml, Encoding.UTF8, "text/xml");
                using (var resp = await client.PostAsync(url, httpContent))
                using (var content = resp.Content)
                {
                    return await content.ReadAsStringAsync();
                }



            }
            catch (System.Threading.ThreadAbortException e)
            {
                //Log.Error("HttpService", "Thread - caught ThreadAbortException - resetting.");
                //Log.Error("Exception message: {0}", e.Message);
                System.Threading.Thread.ResetAbort();
            }
            catch (WebException e)
            {
                //Log.Error("HttpService", e.ToString());
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

        // <summary>
        /// 执行带证书的HTTP POST请求。
        /// </summary>
        /// <param name="client">HttpClient</param>
        /// <param name="url">请求地址</param>
        /// <param name="textParams">请求参数</param>
        /// <returns>HTTP响应内容</returns>
        public static async Task<string> PostAsync(this HttpClient client, string certPath,string certPwd, string xml, string url, int timeout)
        { 
            string result = "";//返回结果 
            try
            {
                //使用证书访问
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
                //设置最大连接数

                //设置https验证方式
                //if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                //{
                //    ServicePointManager.ServerCertificateValidationCallback =
                //            new RemoteCertificateValidationCallback(CheckValidationResult);
                //} 

                //设置代理服务器
                //WebProxy proxy = new WebProxy();                          //定义一个网关对象
                //proxy.Address = new Uri(WxPayConfig.PROXY_URL);              //网关服务器端口:端口
                //request.Proxy = proxy;

                //client.DefaultRequestHeaders.Add("UserAgent", USER_AGENT);
                httpClient.DefaultRequestHeaders.Add("ContentType", "text/xml");

                //设置POST的数据类型和长度 
                byte[] data = System.Text.Encoding.UTF8.GetBytes(xml);
                httpClient.DefaultRequestHeaders.Add("ContentLength", data.Length.ToString());                

                //往服务器写入数据
                HttpContent httpContent = new StringContent(xml, Encoding.UTF8, "text/xml");
                using (var resp = await httpClient.PostAsync(url, httpContent))
                using (var content = resp.Content)
                {
                    result= await content.ReadAsStringAsync();
                }  
            }
            catch (System.Threading.ThreadAbortException e)
            {               
               // Log.Error(string.Format("Exception message: {0}", e.Message));
                System.Threading.Thread.ResetAbort();
            }
            catch (WebException e)
            {
               // Log.Error( e.ToString());
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
