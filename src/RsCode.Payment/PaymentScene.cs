using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

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
        Native = 3
    }
}
