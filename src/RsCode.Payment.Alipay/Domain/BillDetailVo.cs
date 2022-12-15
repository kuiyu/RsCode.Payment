using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// BillDetailVo Data Structure.
    /// </summary>
    [Serializable]
    public class BillDetailVo : AopObject
    {
        /// <summary>
        /// 账单出账时间
        /// </summary>
        [XmlElement("bill_account_date")]
        public string BillAccountDate { get; set; }

        /// <summary>
        /// 账单余额明细
        /// </summary>
        [XmlElement("bill_balance_detail")]
        public BillAmtVo BillBalanceDetail { get; set; }

        /// <summary>
        /// 账单创建时间
        /// </summary>
        [XmlElement("bill_create_date")]
        public string BillCreateDate { get; set; }

        /// <summary>
        /// 账单编号
        /// </summary>
        [XmlElement("bill_no")]
        public string BillNo { get; set; }

        /// <summary>
        /// 账单已还明细
        /// </summary>
        [XmlElement("bill_repay_detail")]
        public BillAmtVo BillRepayDetail { get; set; }

        /// <summary>
        /// 账单状态，NOR正常，OVD逾期，CLE结清
        /// </summary>
        [XmlElement("bill_status")]
        public string BillStatus { get; set; }

        /// <summary>
        /// 账单结清时间
        /// </summary>
        [XmlElement("clear_date")]
        public string ClearDate { get; set; }

        /// <summary>
        /// 账单还款日
        /// </summary>
        [XmlElement("repay_date")]
        public string RepayDate { get; set; }

        /// <summary>
        /// 账单本金总额
        /// </summary>
        [XmlElement("total_prin_amt")]
        public MultiCurrencyMoneyVO TotalPrinAmt { get; set; }
    }
}
