/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using RsCode.DI;
using RsCode.Payment.Tenpay;
using System.Threading.Tasks;

namespace RsCode.Payment.Wxpay.Core
{
    public interface  IWxPayRequest:ITransientDependency
    {
        Task<string> RequestAsync(WxPayData data, string url, string paramFormat = "xml");
        Task<string> RequestAsync(WxPayData data, string url, string certPath, string certPwd, string paramFormat = "xml");
    }
}
