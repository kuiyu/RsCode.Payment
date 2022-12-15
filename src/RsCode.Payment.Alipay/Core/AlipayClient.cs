/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 协议:MIT License 2.0 
 * 作者:河南软商网络科技有限公司 
 * 项目己托管于  
 * github
   https://github.com/kuiyu/RsCode.Payment.git
 */
using Aop.Api;
using Aop.Api.Domain;
using Aop.Api.Request;
using Aop.Api.Response;
using Aop.Api.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;

namespace RsCode.Payment.Alipay
{
    public  class AlipayClient: IAlipayClient
    {
        ILogger log;
        List<PayOptions> payOptions;
        PayOptions currentConfig;
        IAopClient Client;
        IHttpContextAccessor httpContextAccessor;
        public AlipayClient(IOptionsSnapshot<List<PayOptions>> _payOptions, IHttpContextAccessor _httpContextAccessor, ILogger<AlipayClient> _log)
        {
            payOptions = _payOptions.Value;
            httpContextAccessor = _httpContextAccessor;
            log = _log;
        }
        
      public PayOptions UseAppId(string appId="")
        {
            if(string.IsNullOrWhiteSpace(appId)) 
            {
                currentConfig = payOptions.FirstOrDefault(o=> o.PaymentChannel == PaymentChannel.Alipay);
            }else
            {
                 currentConfig = payOptions.FirstOrDefault(o => o.MchId == appId&&o.PaymentChannel== PaymentChannel.Alipay);
            }
            
            if (currentConfig == null)
                throw new Exception($"支付宝参数配置有误:未找到指定AppId{appId}配置");
            return currentConfig;
        }

        public IAopClient InitClient()
        {
            //如果配置了PlatformRootCertPath，则证书优先模式
            IAopClient client = null;
            if(currentConfig==null)
            {
                throw new Exception("please first call UseAppId()");
            }
            if(!string.IsNullOrWhiteSpace(currentConfig.PlatformRootCertPath))
            {
                //设置证书相关参数
                CertParams certParams = new CertParams
                {
                    RootCertPath = currentConfig.PlatformRootCertPath, // "支付宝根证书路径"
                    AlipayPublicCertPath = currentConfig.PlatformPublicKeyCertPath, // "支付宝公钥证书路径",
                    AppCertPath = currentConfig.PublicKeyCertPath, // "商户应用证书路径",
                    
                };
                string APPID = currentConfig.MchId;
                string APP_PRIVATE_KEY =currentConfig.APIKey;
              
                 client = new DefaultAopClient("https://openapi.alipay.com/gateway.do", APPID, APP_PRIVATE_KEY, "json", "1.0", "RSA2", "UTF-8", false, certParams);
            }
            else
            {
                string APPID = currentConfig.MchId;
                string APP_PRIVATE_KEY = currentConfig.APIKey;
                string CHARSET = "utf-8";
                string ALIPAY_PUBLIC_KEY = currentConfig.PlatformPublicKey;
                client = new DefaultAopClient("https://openapi.alipay.com/gateway.do", APPID, APP_PRIVATE_KEY, "json", "1.0", "RSA2", ALIPAY_PUBLIC_KEY, CHARSET, false);
            }
            Client= client;
            return client;
                }
 
        /// <summary>
        /// 支付宝APP支付请求
        /// </summary>
        /// <param name="payInfo"></param>
        /// <returns></returns>
        public string AliPayAppPayRequest(AlipayTradeData payInfo)
        {
            //发起调用支付宝支付的请求

            AlipayTradeAppPayRequest request = new AlipayTradeAppPayRequest();
            //SDK已经封装掉了公共参数，这里只需要传入业务参数。以下方法为sdk的model入参方式(model和biz_content同时存在的情况下取biz_content)。
            AlipayTradeAppPayModel model = new AlipayTradeAppPayModel();
            model.Body = payInfo.Description;
            model.Subject = payInfo.Description;
            model.TotalAmount = payInfo.TotalFee.ToString();
            model.ProductCode = "QUICK_MSECURITY_PAY";
            model.OutTradeNo = payInfo.OrderNo;
            model.TimeoutExpress = "1440m";
            if (!string.IsNullOrWhiteSpace(payInfo.Attach))
                model.PassbackParams = payInfo.Attach;

            request.SetBizModel(model);
            request.SetNotifyUrl(currentConfig.NotifyUrl);
            //这里和普通的接口调用不同，使用的是sdkExecute
            AlipayTradeAppPayResponse response = Client.SdkExecute(request);


            log.LogInformation("AlipayTradeAppPayRequest body=" + response.Body);
            //string s = HttpUtility.HtmlEncode(response.Body); 
            return response.Body;
        }

        public Dictionary<string,string> NotifyData(HttpRequest request)
        {
            try
            {
                var data = GetParameters(request); 
                 
                bool check = false;
                if(!string.IsNullOrWhiteSpace(currentConfig.PlatformPublicKeyCertPath))
                {
                     check = AlipaySignature.RSACertCheckV1(data, currentConfig.PlatformPublicKeyCertPath, "UTF-8", "RSA2");
                }
                else
                {
                     check = AlipaySignature.RSACheckV1(data, currentConfig.PlatformPublicKey, "UTF-8", "RSA2", false);
                }
                
                if (check)
                {
                    return data;
                }else
                {
                    log.LogError("签名校验失败");
                }
                return null;
            }
            catch (Exception e)
            {
                log.LogError(e.Message);
                return null;
            }
            
        }
     
        /// <summary>
        /// 支付宝转帐
        /// </summary>
        /// <param name="alipayUserId">支付宝会员Id</param>
        /// <param name="OrderNo">商户订单号</param>
        /// <param name="Amount">转帐额度</param>
        /// <param name="tradeNo">第三方支付的订单号</param>
        /// <param name="errMsg">转帐失败时的消息</param>
        /// <param name="Remark">转帐说明</param>
        /// <returns></returns>
        public bool TranToAccountRequest(string alipayUserId, string OrderNo, decimal Amount, out string tradeNo, out string errMsg, string Remark = "土淘金网络转账")
        {
            tradeNo = "";
            errMsg = "";
            //发起单笔转帐到支付宝账户请求  

            AlipayFundTransToaccountTransferRequest request = new AlipayFundTransToaccountTransferRequest();

            request.BizContent = "{" +
            "\"out_biz_no\":\"" + OrderNo + "\"," +
            "\"payee_type\":\"ALIPAY_USERID\"," +
            "\"payee_account\":\"" + alipayUserId + "\"," +
            "\"amount\":\"" + Amount + "\"," +
            //"\"payer_show_name\":\"上海交通卡退款\"," +
            //"\"payee_real_name\":\"张三\"," +
            "\"remark\":\"" + Remark + "\"" +
            "}";
            AlipayFundTransToaccountTransferResponse response = Client.Execute<AlipayFundTransToaccountTransferResponse>(request);


            if (response.IsError)
            {
                return false;
                //WithDrawFail(model, response.Msg);
            }
            else
            {

                if (response.Code == "10000" && response.Msg.Equals("Success"))
                {
                    tradeNo = response.OrderId;
                    return true;
                }
                else
                {
                    //查询转账结果
                    AlipayFundTransOrderQueryRequest queryRequest = new AlipayFundTransOrderQueryRequest();
                    queryRequest.BizContent = "{" +
                    "\"out_biz_no\":\"" + OrderNo + "\"," +
                    //"\"order_id\":\"20160627110070001502260006780837\"" +
                    "  }";
                    AlipayFundTransOrderQueryResponse questResponse = Client.Execute(queryRequest);

                    if (questResponse.Code == "10000" && questResponse.Msg.Equals("Success"))
                    {
                        tradeNo = response.OrderId;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
        }


        private Dictionary<string, string> GetParameters(HttpRequest request)
        {
            var parameters = new Dictionary<string, string>();
            if (request.Method == "POST")
            {
                foreach (var iter in request.Form)
                {
                    var s = System.Text.RegularExpressions.Regex.Unescape(iter.Value);
                    parameters.Add(iter.Key, s);
                }
            }
            else
            {
                foreach (var iter in request.Query)
                {
                    var s = System.Text.RegularExpressions.Regex.Unescape(iter.Value);
                    parameters.Add(iter.Key, s);
                }
            }
            return parameters;
        }

        public string GetIp()
        {
            var httpContext = httpContextAccessor;
            var ip = httpContext.HttpContext?.Request.Headers["X-Real-IP"].FirstOrDefault() ?? httpContext.HttpContext?.Request.HttpContext.Connection.RemoteIpAddress.ToString();
            return string.IsNullOrWhiteSpace(ip) ? "0.0.0.0" : ip;
        }
    }
}
