using AspectCore.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using RsCode.Cache;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RsCode.Payment.Tenpay
{

    /// <summary>
    /// 回调处理基类
    /// 主要负责接收微信支付后台发送过来的数据，对数据进行签名验证
    /// 子类在此类基础上进行派生并重写自己的回调处理过程
    /// </summary>
    public class Notify<T>
        where T:INotifyData
    {

        PayOptions payOptions;
        HttpRequest request;

        [FromServiceContext]
        IEnumerable<ICacheProvider> caches { get; set; }

        //ICacheProvider cache;
        public Notify(HttpRequest _request,PayOptions _payOptions)
        {
            request = _request;
            payOptions = _payOptions;
           // cache = caches.FirstOrDefault(c => c.CacheName == "memory");
        }

        WxPayData ReceiveData;
        /// <summary>
        /// 接收从微信支付后台发送过来的数据并验证签名
        /// </summary>
        /// <returns>微信支付后台返回的数据</returns>
        public async Task< WxPayData> GetNotifyDataAsync()
        {
            //接收从微信后台POST过来的数据
            var body =await new StreamReader(request.Body, Encoding.UTF8).ReadToEndAsync();

           //logger.LogDebug("Receive data from WeChat : " + body);

            //转换数据格式并验证签名
            WxPayData data = new WxPayData();
            try
            {
                data.FromXml(body);
                //var obj = data.GetValue("cash_fee");
                //string t = "int";
                //t=obj.GetType() == typeof(string) ?  "string" :  "int";
                //Log.Info("t=" + t);
                //如果通信成功
                if (data.GetValue("return_code").ToString() == "SUCCESS")
                {
                    //获取支付客户端
                    var mchId = data.GetValue("mch_id").ToString();
                  
                    //验签
                    var appSign =data.MakeSign(payOptions.APIKey).ToUpper();
                    var wxSign = data.GetValue("sign").ToString();
                    if(appSign!=wxSign)
                    {
                       // Log.Error("验签失败");
                       // Log.Info("appSign" + appSign);
                       // Log.Info("wxSign" + wxSign);
                        throw new Exception("验签失败");
                    }
                }
            }
            catch (Exception ex)
            {
                //若签名错误，则立即返回结果给微信支付后台
                //Log.Error(ex.Message);
                throw new Exception(ex.Message);
            }
            //Log.Info( "Check sign success");
            ReceiveData = data;
            return data;
        }

        /// <summary>
        /// 处理业务逻辑
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func">通信成功后要执行的方法</param>
        /// <returns></returns>
        public virtual async Task<WxPayData> ProcessNotifyAsync(Func<T,Task<bool>> func)
        {
            try
            {
                if (ReceiveData == null)
                    ReceiveData = await GetNotifyDataAsync();
                //要响应的结果
                WxPayData res = new WxPayData();
                res.SetValue("return_code", "SUCCESS");
                res.SetValue("return_msg", "OK");

                //收到的参数

                var json = ReceiveData.ToJson();
               // Log.Info("收到微信的回调参数：" + json);
                //如果通信成功
                if (ReceiveData.GetValue("result_code").ToString() == "SUCCESS")
                { 
                    if (func != null)
                    {
                        T model = JsonSerializer.Deserialize<T>(json);
                        var ret =await func(model); 
                        //处理业务 
                        if (!ret)
                        {
                            res = new WxPayData();
                            res.SetValue("return_code", "FAIL");
                            res.SetValue("return_msg", "业务处理失败");
                            return res;
                        }
                    }
                }
                else
                {
                    //Log.Info(ReceiveData.GetValue("return_msg"));
                    return ReceiveData;
                }

                //响应给微信的结果,默认处理成功 
                return res;
            }
            catch (Exception ex)
            {
                //Log.Error(ex.Message);
                throw new Exception(ex.Message);
            }
           
        }
 
         
         
    }
 


}
