/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */

using System.Collections.Generic;
using System.Net.Http;

namespace RsCode.Payment
{
    public  class ClientOptions
    {
        public AppOptions AppOptions { get; set; }

        public PayOptions PayOptions { get; set; }

        public List<AuthKeyOptions> AuthKeyOptions { get; set; }
        /// <summary>
        /// 当前http客户端 
        /// </summary>
        public HttpClient HttpClient { get; set; }


    }
}
