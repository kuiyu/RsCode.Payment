using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// ZhimaCreditPeIndustryTradePayModel Data Structure.
    /// </summary>
    [Serializable]
    public class ZhimaCreditPeIndustryTradePayModel : AopObject
    {
        /// <summary>
        /// 支付金额,单位元,支持两位小数
        /// </summary>
        [XmlElement("amount")]
        public string Amount { get; set; }

        /// <summary>
        /// 扩展信息字段，格式:json，注意，如果字符串对应的json对象包含中文字符，需要对包含中文的字段进行编码
        /// </summary>
        [XmlElement("ext_info")]
        public string ExtInfo { get; set; }

        /// <summary>
        /// 扣款描述,扣款成后将在用户支付宝账单显示
        /// </summary>
        [XmlElement("memo")]
        public string Memo { get; set; }

        /// <summary>
        /// 商户扣款资金单号，需要保证唯一,扣款失败继续使用该订单号进行扣款
        /// </summary>
        [XmlElement("out_fund_no")]
        public string OutFundNo { get; set; }

        /// <summary>
        /// 扣款时对应的资金类型,具体业务对应的资金类型请联系业务确认
        /// </summary>
        [XmlElement("pay_amount_type")]
        public string PayAmountType { get; set; }

        /// <summary>
        /// 签约产品码
        /// </summary>
        [XmlElement("product_code")]
        public string ProductCode { get; set; }

        /// <summary>
        /// 平台订单号
        /// </summary>
        [XmlElement("zm_order_id")]
        public string ZmOrderId { get; set; }
    }
}
