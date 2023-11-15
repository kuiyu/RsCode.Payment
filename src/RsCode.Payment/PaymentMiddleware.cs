/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RsCode.Payment
{
    /// <summary>
    /// 支付业务中间件
    /// </summary>
    public class PaymentMiddleware
    {
        IEnumerable<IPayment> payments;
        RequestDelegate next;
        public PaymentMiddleware(RequestDelegate _next, IEnumerable<IPayment> _payments)
        {
            next = _next;
            payments = _payments;
        }

        

        public async Task Invoke(HttpContext context)
        {
            var method = context.Request.Method;
            var path = context.Request.Path.Value;
            //if (method=="POST"&&path.StartsWith("/payment/"))
            string[] s = path.Split('/');


            if (IsRsPay(s))
            {
                //支付方式 
                var payment = GetPayment(s);
                //请求的业务api
                var apiTypeName = GetApiType(s);

                var pay = GetPaymentInstance(apiTypeName);
                var result = await pay.InvokeAsync(context);
              
                //await context.Response.WriteAsync( result,Encoding.GetEncoding("utf-8"));
                await context.Response.WriteAsync(result);
            }
            else
            {
                await next(context);
            }
        }

        bool IsRsPay(string[] path)
        { 
            return path[1].ToLower() == "rspay" ? true : false;
        }
         
        string GetPayment(string[] path)
        {
            string payment = "";
            if (path.Length >= 3)
            {
               payment = path[2];   
            }
            if(string.IsNullOrWhiteSpace(payment))
            {
                throw new Exception("指定的支付方式无效,请检查支付地址");
            }
            return payment;
        }

        string GetApiType(string[] path)
        {
            string apiTypeName = "";
            if (path.Length > 3)
            { 
                    apiTypeName = path[3]; 
            }
            if (string.IsNullOrWhiteSpace(apiTypeName))
            {
                throw new Exception("指定的支付业务无效,请检查支付地址");
            }
            return apiTypeName;
        }

        IPayment GetPaymentInstance(string apiTypeName)
        {
             var pay = payments.FirstOrDefault(p => p.ApiTypeName == apiTypeName);
            //var pay = payments;
            if (pay == null)
            {
                throw new Exception("指定的支付请求无效,请检查支付地址");
            }
            return pay;
        }
    }
}
