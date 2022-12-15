/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 协议:MIT License 2.0 
 * 作者:河南软商网络科技有限公司 
 * 项目己托管于  
 * github
   https://github.com/kuiyu/RsCode.Payment.git
 */
using Aop.Api;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace RsCode.Payment.Alipay
{
    public interface IAlipayClient
    {
        PayOptions UseAppId(string appId="");

        IAopClient InitClient();
        /// <summary>
        /// 接受回调的数据，并验签名
        /// </summary>
        /// <param name="request"></param>
        /// <returns>验签成功，返回回调数据，否则返回空</returns>
        Dictionary<string, string> NotifyData(HttpRequest request);

        string GetIp();
    }
}
