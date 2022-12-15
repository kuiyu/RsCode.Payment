using System.ComponentModel;

namespace RsCode.Payment
{
    /// <summary>
    /// 交易类型
    /// JSAPI--JSAPI支付（或小程序支付）、NATIVE--Native支付、APP--app支付，MWEB--H5支付
    /// MICROPAY--付款码支付
    /// </summary>
    public enum TradeType
    {
        /// <summary>
        /// JSAPI  小程序支付 公众号支付
        /// </summary>
       [Description("JSAPI")] JSAPI=1,
        /// <summary>
        /// NATIVE 原生扫码支付
        /// </summary>
        [Description("NATIVE")] Native =2,
        /// <summary>
        /// APP支付
        /// </summary>
        [Description("APP")] App =3,
        /// <summary>
        /// 刷卡支付
        /// </summary>
          [Description("MICROPAY")] micropay=4
    }
}
