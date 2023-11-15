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
    /// 支付渠道
    /// </summary>
    public enum PaymentChannel
    {
        [Description("未知")]Unknow=0,
        /// <summary>
        /// 微信支付
        /// </summary>
       [Description("微信支付")] Tenpay=1,
            /// <summary>
            /// 支付宝
            /// </summary>
        [Description("支付宝")]Alipay=2,
        /// <summary>
        /// 积分支付
        /// </summary>
        [Description("积分支付")] Integral = 3,
		/// <summary>
		/// 抖音支付
		/// </summary>
		[Description("抖音支付")] DyPay =4
	}
}
