using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayBossFncInvoiceStatementbillApplyModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayBossFncInvoiceStatementbillApplyModel : AopObject
    {
        /// <summary>
        /// 调用方身份识别标记(应用名称) 与业务单据号联合唯一
        /// </summary>
        [XmlElement("biz_id")]
        public string BizId { get; set; }

        /// <summary>
        /// 业务单据号，业务流水号
        /// </summary>
        [XmlElement("biz_no")]
        public string BizNo { get; set; }

        /// <summary>
        /// 开票总金额，开票金额不能为空，开票金额不能小于等于0
        /// </summary>
        [XmlElement("invoice_amt")]
        public MultiCurrencyMoneyOpenApi InvoiceAmt { get; set; }

        /// <summary>
        /// 申请开票类型，01：专票；02：普票
        /// </summary>
        [XmlElement("invoice_type")]
        public string InvoiceType { get; set; }

        /// <summary>
        /// 申请开票原因说明
        /// </summary>
        [XmlElement("memo")]
        public string Memo { get; set; }

        /// <summary>
        /// 申请开票的操作人
        /// </summary>
        [XmlElement("operator")]
        public string Operator { get; set; }

        /// <summary>
        /// 需要开票的对账单编号
        /// </summary>
        [XmlElement("statement_bill_list")]
        public string StatementBillList { get; set; }
    }
}
