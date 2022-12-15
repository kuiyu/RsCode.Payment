using Aop.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rswl.Payment.Alipay
{
    public class PaymentClient
    {
        public IAopClient GetClient()
        {
            //支付宝实例
            string APPID = "";
            string APP_PRIVATE_KEY = "";
            string ALIPAY_PUBLIC_KEY = "";
            string CHARSET = "";
            IAopClient client = new DefaultAopClient("https://openapi.alipay.com/gateway.do", APPID, APP_PRIVATE_KEY, "json", "1.0", "RSA2", ALIPAY_PUBLIC_KEY, CHARSET, false);
            return client;
        }

    }
}
