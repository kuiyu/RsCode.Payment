using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// CreditPayBillAssetVO Data Structure.
    /// </summary>
    [Serializable]
    public class CreditPayBillAssetVO : AopObject
    {
        /// <summary>
        /// 是否允许部分提前还款
        /// </summary>
        [XmlElement("allow_part_prepayment")]
        public bool AllowPartPrepayment { get; set; }

        /// <summary>
        /// 是否允许提前还款
        /// </summary>
        [XmlElement("allow_prepayment")]
        public bool AllowPrepayment { get; set; }

        /// <summary>
        /// 资产基础信息
        /// </summary>
        [XmlElement("base_info")]
        public CreditPayAssetBaseVO BaseInfo { get; set; }

        /// <summary>
        /// 账单出账日期
        /// </summary>
        [XmlElement("bill_account_day")]
        public string BillAccountDay { get; set; }

        /// <summary>
        /// 出账日单位，周/月（W/M）
        /// </summary>
        [XmlElement("bill_account_day_unit")]
        public string BillAccountDayUnit { get; set; }

        /// <summary>
        /// 账单产品码
        /// </summary>
        [XmlElement("bill_pd_code")]
        public string BillPdCode { get; set; }

        /// <summary>
        /// 费用定价列表，账单可能不收费，所以有可能为空
        /// </summary>
        [XmlArray("charge_pricing_list")]
        [XmlArrayItem("credit_pay_charge_pricing_v_o")]
        public List<CreditPayChargePricingVO> ChargePricingList { get; set; }

        /// <summary>
        /// 条款信息，有些场景无需透出条款，所以可能为空
        /// </summary>
        [XmlArray("clauses")]
        [XmlArrayItem("credit_pay_clause_v_o")]
        public List<CreditPayClauseVO> Clauses { get; set; }

        /// <summary>
        /// 营销信息，如果不存在营销和一些营销性质的文案，可能为空
        /// </summary>
        [XmlElement("discount_info")]
        public CreditPayDiscountVO DiscountInfo { get; set; }

        /// <summary>
        /// 利息定价视图，账单可能不收利息，所以有可能为空
        /// </summary>
        [XmlElement("int_pricing")]
        public CreditPayIntPricingVO IntPricing { get; set; }

        /// <summary>
        /// 还款信息，账单可能不存在还款信息
        /// </summary>
        [XmlElement("repay_info")]
        public CreditPayRepayVO RepayInfo { get; set; }

        /// <summary>
        /// 期限信息，账单产品可能不存在期限信息
        /// </summary>
        [XmlElement("term_info")]
        public CreditPayTermVO TermInfo { get; set; }
    }
}
