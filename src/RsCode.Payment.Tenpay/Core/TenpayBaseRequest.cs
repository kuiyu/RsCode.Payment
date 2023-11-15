/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
namespace RsCode.Payment.Tenpay
{
    public interface TenpayBaseRequest
    {
        string RequestMethod();
        string GetApiUrl(); 
     
    }
}
