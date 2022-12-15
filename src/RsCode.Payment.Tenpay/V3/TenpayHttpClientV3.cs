
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace RsCode.Payment.Tenpay.V3
{
    /// <summary>
    /// V3版本tenpay httpclient
    /// </summary>
    public class TenpayHttpClientV3
    {
        ILogger log;
        public HttpClient Client { get; private set; }
         
        public TenpayHttpClientV3(HttpClient client,ILogger<TenpayHttpClientV3> logger)
        {  
            Client = client;
            log = logger;
        }

        public void LoadHandler(HttpHandler httpHandler)
        {
            Client = new HttpClient(httpHandler);
            Client.BaseAddress = new Uri("https://api.mch.weixin.qq.com");
        }

        public async Task<T> GetAsync<T>(string url)
            where T : TenpayBaseResponse
        {
            int code = 200;
            string responseContent = "";
            try
            {
                
                using (var response = await Client.GetAsync(url))
                {
                     code = Convert.ToInt32(response.StatusCode);
                    if (code == 200)
                    {
                        //string s = await response.Content.ReadAsStringAsync(); 
                        using (var responseStream = await response.Content.ReadAsStreamAsync())
                        {
                            return await JsonSerializer.DeserializeAsync<T>(responseStream);
                        }
                    }
                    else
                    {
                        var s = await response.Content.ReadAsStringAsync();
                        responseContent = s; 
                        throw new Exception(s);
                    }

                }
            }
            catch (Exception e)
            {
                log.LogError($"responseContent={responseContent} err={e.Message}"); 
                throw e;
            }
            

        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            var response = await Client.GetAsync(url);
            return response; 
        }

         

        public async Task<T> PostAsync<T>(string url, HttpContent httpContent)
            where T:TenpayBaseResponse
        {
            int code = 200;
            string responseContent = "";
            try
            {
                using (httpContent)
                using (var response = await Client.PostAsync(url, httpContent))
                {
                    int statusCode = Convert.ToInt32(response.StatusCode);
                    if (statusCode == 200)
                    {
                        using (var responseStream = await response.Content.ReadAsStreamAsync())
                        {
                            return await JsonSerializer.DeserializeAsync
                             <T>(responseStream);
                        }
                    }
                    else
                    { 
                        var s = await response.Content.ReadAsStringAsync();
                        responseContent = s;
                        throw new Exception(s);
                    }
                }
            }
            catch (Exception e)
            {
                log.LogError($"responseContent={responseContent} err={e.Message}");
                throw e;
            }
            
 
        }
    }
 
}
