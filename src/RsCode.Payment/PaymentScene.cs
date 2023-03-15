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
        Native = 3,
        [Description("电脑网页支付")]
        PagePay=4,
        [Description("手机网页支付")]
        WapPay=5
    }
}
