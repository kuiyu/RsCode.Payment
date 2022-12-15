using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// ZhimaCreditEpSceneAgreementCancelModel Data Structure.
    /// </summary>
    [Serializable]
    public class ZhimaCreditEpSceneAgreementCancelModel : AopObject
    {
        /// <summary>
        /// 业务取消时间，日期格式为 yyyy-MM-dd HH:mm:ss
        /// </summary>
        [XmlElement("biz_time")]
        public string BizTime { get; set; }

        /// <summary>
        /// 信用订单号
        /// </summary>
        [XmlElement("credit_order_no")]
        public string CreditOrderNo { get; set; }

        /// <summary>
        /// 商户的信用订单号，64位长度的字母数字下划线组合。该标识作为对账的关键信息，商户要保证其唯一性且必须和加入信用服务时的外部订单号保持一致
        /// </summary>
        [XmlElement("out_order_no")]
        public string OutOrderNo { get; set; }
    }
}
