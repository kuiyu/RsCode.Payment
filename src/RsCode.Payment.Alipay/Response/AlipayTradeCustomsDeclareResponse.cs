using System;
using System.Xml.Serialization;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipayTradeCustomsDeclareResponse.
    /// </summary>
    public class AlipayTradeCustomsDeclareResponse : AopResponse
    {
        /// <summary>
        /// 支付宝报关流水号。
        /// </summary>
        [XmlElement("alipay_declare_no")]
        public string AlipayDeclareNo { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        [XmlElement("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// 订购人身份信息和支付人的身份信息验证结果。T表示商户传入的订购人姓名和身份证号和支付人的姓名和身份证号一致。F代表商户传入的订购人姓名和身份证号和支付人的姓名和身份证号不一致。对于同一笔报关单支付宝只会校验一次，如果多次重推不会返回此参数。
        /// </summary>
        [XmlElement("identity_check")]
        public string IdentityCheck { get; set; }

        /// <summary>
        /// 支付机构注册号
        /// </summary>
        [XmlElement("pay_code")]
        public string PayCode { get; set; }

        /// <summary>
        /// 清算流水号
        /// </summary>
        [XmlElement("pay_transaction_id")]
        public string PayTransactionId { get; set; }

        /// <summary>
        /// 交易总金额(单位:分)
        /// </summary>
        [XmlElement("total_amount")]
        public string TotalAmount { get; set; }

        /// <summary>
        /// 支付宝推送到海关的支付单据号。
        /// </summary>
        [XmlElement("trade_no")]
        public string TradeNo { get; set; }

        /// <summary>
        /// 清算机构标志（1-cup,2-null,3-other）
        /// </summary>
        [XmlElement("ver_dept")]
        public string VerDept { get; set; }
    }
}
