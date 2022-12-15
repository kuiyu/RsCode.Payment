using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayUserAgreementTransferModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayUserAgreementTransferModel : AopObject
    {
        /// <summary>
        /// 支付宝系统中用以唯一标识用户签约记录的编号（用户签约成功后的协议号 ），如果传了该参数，其他参数会被忽略
        /// </summary>
        [XmlElement("agreement_no")]
        public string AgreementNo { get; set; }

        /// <summary>
        /// 周期管控规则参数period_rule_params，在签约周期扣款产品（如CYCLE_PAY_AUTH_P）时必传。 周期扣款产品，会按照这里传入的参数提示用户，并对发起扣款的时间、金额、次数等做相应限制。
        /// </summary>
        [XmlElement("period_rule_params")]
        public PeriodRuleParams PeriodRuleParams { get; set; }

        /// <summary>
        /// 协议产品码，商户和支付宝签约时确定，不同业务场景对应不同的签约产品码。这里指的是需要修改目标产品码的值
        /// </summary>
        [XmlElement("target_product_code")]
        public string TargetProductCode { get; set; }
    }
}
