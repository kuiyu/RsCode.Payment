/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 协议:MIT License 2.0 
 * 作者:河南软商网络科技有限公司 
 * 项目己托管于  
 * github
   https://github.com/kuiyu/RsCode.Payment.git
 */
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Http;
using RsCode.Payment;
using RsCode.Payment.Alipay;

namespace RsCode.Payment
{
    public  static class ServicesExtensions
    {
        public static void AddAlipay(this IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpClient("alipay");


            services.AddHttpClient<AlipayClient>();
            services.AddScoped<AlipayClient>();

            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("pay.json", true, true);
            var config = configBuilder.Build();
            services.Configure<List<PayOptions>>(options => config.GetSection("Payment").Bind(options));
            services.Configure<List<AppOptions>>(options => config.GetSection("App").Bind(options));
            services.Configure<List<AuthKeyOptions>>(options => config.GetSection("AuthKey").Bind(options));

services.TryAddSingleton<List<PayOptions>>();
            services.TryAddSingleton<List<AppOptions>>();
            services.TryAddSingleton<List<AuthKeyOptions>>();
            services.TryAddScoped<IPayConfig, PayConfig>();
            services.TryAddScoped<IAlipayClient, AlipayClient>();
        }

    }
}
