using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// GroupFundBill Data Structure.
    /// </summary>
    [Serializable]
    public class GroupFundBill : AopObject
    {
        /// <summary>
        /// 实际待收待付金额，两位小数点的整数，单位元
        /// </summary>
        [XmlElement("actual_amount")]
        public string ActualAmount { get; set; }

        /// <summary>
        /// 待收或待付金额，两位小数点的正数，单位元
        /// </summary>
        [XmlElement("amount")]
        public string Amount { get; set; }

        /// <summary>
        /// 资金单据号，唯一标识一次资金流入/流出
        /// </summary>
        [XmlElement("bill_no")]
        public string BillNo { get; set; }

        /// <summary>
        /// 单据类型, "R"为收款单，"P"为付款单
        /// </summary>
        [XmlElement("bill_type")]
        public string BillType { get; set; }

        /// <summary>
        /// 当前流水单据对应的资金明细，仅当前用户会返回全部明细
        /// </summary>
        [XmlArray("fund_details")]
        [XmlArrayItem("group_fund_detail")]
        public List<GroupFundDetail> FundDetails { get; set; }

        /// <summary>
        /// 单据状态，包括"INIT": 初始化(发起预结算尚未预付款)，"PRE_PAY": 预付款阶段，"PAY_SUC"：预付款成功，"CLOSE"：已关闭，"REFUND"：已退款
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }

        /// <summary>
        /// 关联的转账单据号，唤起收银台时使用，发起预付款请求后才会返回
        /// </summary>
        [XmlElement("transfer_no")]
        public string TransferNo { get; set; }

        /// <summary>
        /// 单据所属的支付宝账户ID，对于收款单表示待付款用户ID，对于付款单标识待收款用户ID
        /// </summary>
        [XmlElement("user_id")]
        public string UserId { get; set; }
    }
}
