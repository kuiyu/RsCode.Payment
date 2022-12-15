using RsCode.DI;
using RsCode.Payment.Tenpay;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RsCode.Payment.Wxpay.Core
{
   public interface  IWxPayRequest:ITransientDependency
    {
        Task<string> RequestAsync(WxPayData data, string url, string paramFormat = "xml");
        Task<string> RequestAsync(WxPayData data, string url, string certPath, string certPwd, string paramFormat = "xml");
    }
}
