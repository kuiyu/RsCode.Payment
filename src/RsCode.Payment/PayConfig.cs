/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using AspectCore.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RsCode.Payment
{
    public class PayConfig : IPayConfig
    {
         
        public PayConfig(
            IOptionsSnapshot<List<PayOptions>> _payOptions, 
            IOptionsSnapshot<List<AppOptions>> _appOptions, 
            IOptionsSnapshot<List<AuthKeyOptions>> _authkeyOptions)
        {
            payOptions = _payOptions?.Value;
            appOptions = _appOptions?.Value;
            authkeyOptions = _authkeyOptions?.Value;
        }
        
        List<PayOptions> payOptions;
        List<AppOptions> appOptions;
        List<AuthKeyOptions> authkeyOptions;

        [FromServiceContext]
        IHttpClientFactory httpClientFactory { get; set; }

        /// <summary>
        /// 获取所有支付参数
        /// </summary>
        /// <returns></returns>
        public virtual List<PayOptions> GetPaymentInfo()
        {
            return payOptions;
        }

      
        /// <summary>
        /// 获取指定应用的配置信息
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public virtual List<AppOptions>GetAppInfos(string clientId)
        {
            return appOptions?.FindAll(c=>c.ClientId==clientId);
        }
        /// <summary>
        /// 获取authkey
        /// </summary>
        /// <returns></returns>
        public virtual List<AuthKeyOptions>GetAuthKeyInfo()
        {
            return authkeyOptions;
        }


        public virtual async Task SaveAuthKeyAsync(AuthKeyOptions option)
        {
            try
            {
                if (string.IsNullOrEmpty(option.id))
                {
                    option.id = Guid.NewGuid().ToString();
                }
                option.create_date = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");

                var authkeys = await GetAuthKeyAsync();
                if (authkeys != null)
                {
                    var authkey = authkeys.FirstOrDefault<AuthKeyOptions>(a => a.id == option.id);
                    if (authkey != null)
                        authkeys.Remove(authkey);

                }
                else
                {
                    authkeys = new List<AuthKeyOptions>();
                }
                authkeys.Add(option);

                dynamic obj = GetJObject("pay.json");
                obj.AuthKey = JArray.FromObject(authkeys);
                //AppSettings.Save(obj);

                await SaveJsonAsync(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public virtual void SavePayment(PayOptions options,string oldMchId)
        {
            try
            {
                //pay.json Payment 所有内容 
                
                var clients = payOptions ;
                if (clients == null)
                {
                    clients = new List<PayOptions>();
                }
                if(string.IsNullOrWhiteSpace(oldMchId))
                {
                    clients.Add(options);
                }else
                {
                    var payClient = clients?.FirstOrDefault(c => c.MchId == oldMchId);
                    if (payClient != null)
                    {
                        int index = clients.IndexOf(payClient);
                        clients[index] = options;
                    }
                    else
                    {
                        clients.Add(options);
                    }
                }
                

                dynamic obj = GetJObject("pay.json");
                obj.Payment = JArray.FromObject(clients);
                //AppSettings.Save(obj);
                SaveJson(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void RemovePaymentInfo(string mchId)
        {
            var option = GetPaymentInfo(mchId);
            if(option!=null)
            {
                payOptions.Remove(option);

                dynamic obj = GetJObject("pay.json");
                obj.Payment = JArray.FromObject(payOptions);
                SaveJson(obj);
            }
        }
        public virtual void SaveAppClient(AppOptions options)
        {
            try
            {
               
                var apps = appOptions;
                if (apps == null)
                {
                    apps = new List<AppOptions>();
                }

                var app = apps.FirstOrDefault(a => a.AppId == options.AppId);
                if (app != null)
                {
                    int index = apps.IndexOf(app);
                    apps[index] = options;
                }
                else
                {
                    apps.Add(options);
                }


                dynamic obj = GetJObject("pay.json");
                obj.App = JArray.FromObject(apps);
                SaveJson(obj);
            }
            catch (Exception ex)
            { 
                throw new Exception(ex.Message);
            }

        }

        public virtual ClientOptions GetClient(string appId)
        {
            ClientOptions clientOptions = null;
            //查询指定APPID的支付配置
            if (appOptions != null)
            {
                clientOptions = new ClientOptions();
                clientOptions.AuthKeyOptions = authkeyOptions;
                clientOptions.AppOptions = appOptions?.FirstOrDefault(app => app.AppId == appId);
                string mchId = clientOptions.AppOptions.MchId;
                if (clientOptions.AppOptions != null)
                {
                    clientOptions.PayOptions = payOptions?.FirstOrDefault<PayOptions>(o => o.MchId == mchId);
                    if (clientOptions.PayOptions != null)
                    {
                        string payment = "wxpay";
                        if (clientOptions.PayOptions.PaymentChannel == PaymentChannel.Alipay)
                            payment = "alipay";
                        clientOptions.HttpClient = httpClientFactory.CreateClient(payment);


                    }
                }
            }
            return clientOptions;
        }

        /// <summary>
        /// 查询所有支付信息
        /// </summary>
        /// <returns></returns>
        public virtual List<ClientOptions> GetClient()
        {
            List<ClientOptions> target = null;
            //获取支付客户端
            var payClients = payOptions;
            if (payClients != null)
            {
                target = new List<ClientOptions>();

                foreach (var payClient in payClients)
                {
                    ClientOptions clientOptions = new ClientOptions();
                    clientOptions.PayOptions = payClient;
                    clientOptions.AuthKeyOptions = authkeyOptions;
                    var appClients = appOptions;
                    if (appClients != null)
                    {
                        var appClient = appClients.FirstOrDefault(app => app.MchId == payClient.MchId);
                        if (appClient != null)
                        {
                            clientOptions.AppOptions = appClient;
                        }
                    }
                    target.Add(clientOptions);
                }
            }

            //获取支付宝客户端
            return target;
        }

      

        public PayOptions GetPaymentInfo(string mchId)
        {
            var clients = GetClient();
            var client= clients?.FirstOrDefault(c => c.PayOptions.MchId == mchId);
            return  client?.PayOptions;
        }

        public virtual void RemoveAppInfo(string appId)
        {
            if (appOptions != null)
            {
                var option = appOptions.FirstOrDefault(x => x.AppId == appId);
                appOptions.Remove(option);
               
                dynamic obj = GetJObject("pay.json");
                obj.App = JArray.FromObject(appOptions);
                SaveJson(obj);
            } 
        }

        public virtual void RemoveAppClient(string clientId,PaymentScene paymentScene,string mchId)
        {
            var appClients = appOptions;
            if (appClients != null)
            {
                appClients.ToList().RemoveAll(x => x.ClientId == clientId&&x.PaymentScene== paymentScene&&x.MchId==mchId);
                dynamic obj = GetJObject("pay.json");
                obj.App = JArray.FromObject(appClients);
                //AppSettings.Save(obj);
                SaveJson(obj);
            }
        }

        public virtual void ChangeAdminPassword(string newPassword)
        {
            dynamic obj = GetJObject("pay.json");
            obj.Admin.Password = newPassword;
            SaveJson(obj);
        }

      
      
        public virtual async Task RemoveAuthKey(string authkeyId)
        {
            try
            {
                var authkeys = authkeyOptions;
                if (authkeys != null)
                {
                    var authkey = authkeys.FirstOrDefault<AuthKeyOptions>(a => a.id == authkeyId);
                    if (authkey != null)
                        authkeys.Remove(authkey);
                    if (authkeys.Count == 0)
                        authkeys = new List<AuthKeyOptions>();
                }

                dynamic obj = GetJObject("pay.json");
                obj.AuthKey = JArray.FromObject(authkeys);
                //AppSettings.Save(obj);

                await SaveJsonAsync(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        async Task SaveJsonAsync(dynamic obj)
        {
            await Task.Run(() =>
            {
                var jsonConents = JsonConvert.SerializeObject(obj, Formatting.Indented);
                var root = AppContext.BaseDirectory;
                string jsonFileFullPath = Path.Combine(root, "pay.json");
                WriteJsonFile(jsonFileFullPath, jsonConents);
            });
        }
        void SaveJson(dynamic obj)
        {
            var jsonConents = JsonConvert.SerializeObject(obj, Formatting.Indented);
            var root = AppContext.BaseDirectory;
            string jsonFileFullPath = Path.Combine(root, "pay.json");
            WriteJsonFile(jsonFileFullPath, jsonConents);
        }
        public  JObject GetJObject(string jsonFilePath = "appsettings.json")
        {
            using (StreamReader reader = new StreamReader(jsonFilePath))
            {
                using JsonTextReader reader2 = new JsonTextReader(reader);
                return JToken.ReadFrom(reader2) as JObject;
            } 
        }
        void WriteJsonFile(string path, string jsonConents)
        {            

            using (FileStream fs = new FileStream(path, FileMode.Create, System.IO.FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    sw.WriteLine(jsonConents);
                }
            }
        }

        public Task<List<AuthKeyOptions>> GetAuthKeyAsync()
        {
            throw new NotImplementedException();
        }
    }
}
