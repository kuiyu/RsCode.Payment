/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 协议:MIT License 2.0 
 * 作者:河南软商网络科技有限公司 
 * 项目己托管于  
 * github
   https://github.com/kuiyu/RsCode.Payment.git
 */
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace RsCode.Payment.Tenpay.V2
{
    /// <summary>
    /// V2版本tenpay httpclient
    /// </summary>
    public class TenpayHttpClient
    {
        public HttpClient Client { get; private set; }

        public TenpayHttpClient(HttpClient client)
        {
            Client = client;
        }

        public void LoadHandler(HttpHandler httpHandler)
        {
            Client = new HttpClient(httpHandler);
            Client.BaseAddress = new Uri("https://api.mch.weixin.qq.com");
        }





        public async Task<T> GetAsync<T>(string url)
            where T : TenpayBaseResponse
        {
            using (var response = await Client.GetAsync(url))
            {
                int statusCode = Convert.ToInt32(response.StatusCode);
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var res = await response.Content.ReadAsStringAsync();
                    TenpayBaseResponse result = new TenpayBaseResponse();
                    result.FromXml(res);
                    var json = result.ToJson();
                    return await JsonSerializer.DeserializeAsync<T>(responseStream);
                }

            }

        }
 

        public async Task<T> PostAsync<T>(string url, HttpContent httpContent)
            where T : TenpayBaseResponse
        {
            using (httpContent)
            using (var response = await Client.PostAsync(url, httpContent))
            {
                var res = await response.Content.ReadAsStringAsync();
                
                TenpayBaseResponse result = new TenpayBaseResponse();
                result.FromXml(res);
                var json = result.ToJson();
                return JsonSerializer.Deserialize<T>(json);

            }

        }
    }
}
