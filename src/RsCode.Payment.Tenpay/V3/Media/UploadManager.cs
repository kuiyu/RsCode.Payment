/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RsCode.Payment.Tenpay.Media
{
    public class UploadManager : IUploadManager
    {
        public UploadManager(ILogger<UploadManager> _logger,
           IOptionsSnapshot<List<PayOptions>> _payOptions)
        {
            logger = _logger;
            payOptions = _payOptions.Value;
        }
        PayOptions currentPayOptions;
        
        List<PayOptions> payOptions;
        ILogger logger;

        public void UseMchId(string mchId)
        {
            currentPayOptions = payOptions.FirstOrDefault(x => x.MchId == mchId); 
        }
         
        
        public async Task<string> UploadFileAsync(string filePath)
        {  

            string boundary = string.Format("--{0}", DateTime.Now.Ticks.ToString("x"));
            var sha256 = TenpayTool.SHA256File(filePath);
            MetaInfo meta = new MetaInfo()
            {
                Sha256 = sha256,
                FileName = Path.GetFileName(filePath)
            };
            var json = JsonSerializer.Serialize(meta);
            
            var httpHandler = new HttpHandler(currentPayOptions, json);
            HttpClient client = new HttpClient(httpHandler);
            using (var requestContent = new MultipartFormDataContent(boundary))
            {
                requestContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data"); //这里必须添加
                requestContent.Add(new StringContent(json, Encoding.UTF8, "application/json"), "\"meta\""); //这里主要必须要双引号
                var fileInfo = new FileInfo(filePath);
                using (var fileStream = fileInfo.OpenRead())
                {
                    var content = new byte[fileStream.Length];
                    fileStream.Read(content, 0, content.Length);
                    var byteArrayContent = new ByteArrayContent(content);
                    byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
                    requestContent.Add(byteArrayContent, "\"file\"", "\"" + meta.FileName + "\"");  //这里主要必须要双引号
                    using (var response = await client.PostAsync("https://api.mch.weixin.qq.com/v3/marketing/favor/media/image-upload", requestContent)) //上传
                    using (var responseContent = response.Content)
                    {
                        string responseBody = await responseContent.ReadAsStringAsync(); //这里就可以拿到图片id了
                        return responseBody;
                    }
                }
            }
        }

        public async Task<string> GetMediaIdAsync(string filePath)
        {
            try
            {
                //var serialNo = currentPayOptions.GetCertSerialNo();

                string boundary = string.Format("--{0}", DateTime.Now.Ticks.ToString("x"));
                var sha256 = TenpayTool.SHA256File(filePath);
                MetaInfo meta = new MetaInfo()
                {
                    Sha256 = sha256,
                    FileName = Path.GetFileName(filePath)
                };
                var json = JsonSerializer.Serialize(meta); 

                var httpHandler = new HttpHandler(currentPayOptions, json); 
                HttpClient client = new HttpClient(httpHandler);
                using (var requestContent = new MultipartFormDataContent(boundary))
                {
                    requestContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data"); //这里必须添加
                    requestContent.Add(new StringContent(json, Encoding.UTF8, "application/json"), "\"meta\""); //这里主要必须要双引号
                    //logger.LogInformation("filePath=" + filePath);
                    var fileInfo = new FileInfo(filePath);
                    using (var fileStream = fileInfo.OpenRead())
                    {                     
                        var content = new byte[fileStream.Length];
                        fileStream.Read(content, 0, content.Length);
                      
                        var byteArrayContent = new ByteArrayContent(content);
                        byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
                        requestContent.Add(byteArrayContent, "\"file\"", "\"" + meta.FileName + "\"");  //这里主要必须要双引号
                       
                        
                        using (var response = await client.PostAsync("https://api.mch.weixin.qq.com/v3/merchant/media/upload", requestContent)) //上传
                        using (var responseContent = response.Content)
                        {
                            string responseBody = await responseContent.ReadAsStringAsync(); //这里就可以拿到图片id了
                            return responseBody;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if(ex.InnerException!=null)
                {
                    logger.LogError(ex.InnerException.Message);
                }
                 
                    logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
           
        }
    }
}
