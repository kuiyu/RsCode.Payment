using System.ComponentModel;

namespace RsCode.Payment.Tenpay.ECommerce.Merchant
{
    public enum AccountType
    {
        /// <summary>
        /// 对公银行账户
        /// </summary>
        [Description("ACCOUNT_TYPE_BUSINESS")]
        Business,
        /// <summary>
        /// 经营者个人银行卡
        /// </summary>
        [Description("ACCOUNT_TYPE_PRIVATE")]
        Private

    }
}
