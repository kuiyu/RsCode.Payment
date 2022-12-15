using System.ComponentModel;

namespace RsCode.Payment
{
    /// <summary>
    /// 支付渠道
    /// </summary>
    public enum PaymentChannel
    {
        /// <summary>
        /// 微信支付
        /// </summary>
       [Description("微信支付")] Tenpay=1,
            /// <summary>
            /// 支付宝
            /// </summary>
        [Description("支付宝")]Alipay=2
    }
}
