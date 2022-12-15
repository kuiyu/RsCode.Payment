using System.ComponentModel;

namespace RsCode.Payment
{
    public interface IPayOptions
    {
        /// <summary>
        /// 分配的商户号
        /// </summary>
         string MchId { get; set; }

        /// <summary>
        /// 商户类型
        /// </summary>
        [Description("商户类型")]  MchType MchType { get; set; }
    }

    /// <summary>
    /// 第三方支付的商户类型
    /// </summary>
    public enum MchType
    {
        /// <summary>
        /// 普通商户
        /// </summary>
        [Description("普通商户")]Merchant = 0,
        /// <summary>
        /// 服务商
        /// </summary>
        [Description("服务商")] ISV = 1,
        /// <summary>
        /// 银行服务商
        /// </summary>
        [Description("银行服务商")] BankISV = 2

    }
}
