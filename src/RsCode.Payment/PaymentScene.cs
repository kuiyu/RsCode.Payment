/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.ComponentModel;

namespace RsCode.Payment
{
    /// <summary>
    /// 支付场景
    /// </summary>
    public enum PaymentScene
    {
        [Description("Jsapi")]
        JSAPI = 1,
        [Description("App")]
        APP = 2,
        [Description("原生支付")]
        Native = 3,
        [Description("电脑网页支付")]
        PagePay=4,
        [Description("手机网页支付")]
        WapPay=5
    }
}
