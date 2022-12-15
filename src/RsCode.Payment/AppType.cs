using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

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
