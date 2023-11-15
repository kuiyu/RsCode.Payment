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
    /// app类型
    /// </summary>
    public enum AppType
    {
        /// <summary>
        /// PC网站
        /// </summary>
        [Description("PC网站")]PC=1,
        /// <summary>
        /// 公众号
        /// </summary>
        [Description("公众号")] Public = 2,
        /// <summary>
        /// APP
        /// </summary>
        [Description("APP")]App=3, 
        /// <summary>
        /// 微信小程序
        /// </summary>
        [Description("小程序")] MiniProgram =4


    }
}
