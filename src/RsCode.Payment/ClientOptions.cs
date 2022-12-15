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
