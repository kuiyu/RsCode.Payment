/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Http;
using RsCode.Config;
using RsCode.Payment.Tenpay.ECommerce;
using RsCode.Payment.Tenpay.Media;
using RsCode.Payment.Tenpay.V3;
using RsCode.Payment.Tenpay.V2;
using RsCode.Payment.Tenpay;

namespace RsCode.Payment
{
    public static class ServicesExtersionss
    {

        public static void AddTenpay(this IServiceCollection services)
        {
            services.TryAddTransient<AppConfig>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddHttpClient<TenpayHttpClient>();
            services.AddScoped<ITenpayClient, TenpayClient>();

            services.AddHttpClient<TenpayHttpClientV3>();
            services.AddScoped<ITenpayClient, TenpayClientV3>();
            

            //Directory.GetCurrentDirectory()
            var configBuilder = new ConfigurationBuilder()
                .AddJsonFile("pay.json", optional: true, reloadOnChange: true);
            var config = configBuilder.Build();
         
            services.Configure<List<PayOptions>>(options => config.GetSection("Payment").Bind(options));
            services.Configure<List<AppOptions>>(options => config.GetSection("App").Bind(options));
            services.Configure<List<AuthKeyOptions>>(options => config.GetSection("AuthKey").Bind(options));
            

            services.TryAddScoped<IPayConfig, PayConfig>();
           
            services.TryAddScoped<IUploadManager, UploadManager>();
            #region 电商收付通
            services.TryAddScoped<BalanceManager>();
            services.TryAddScoped<BillManager>();
            services.TryAddScoped<ECombineManager>();
            services.TryAddScoped<ERefundManager>();
            services.TryAddScoped<SubsidiesManager>();
            //services.TryAddScoped<IMerchantManager, MerchantManager>();
            services.TryAddScoped<ProfitsharingManager>();
            services.TryAddScoped<WithdrawManager>();
            #endregion

            //增加内存缓存
            services.AddMemoryCache();
        }
    }

 


   
}
