using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// PointTransInfo Data Structure.
    /// </summary>
    [Serializable]
    public class PointTransInfo : AopObject
    {
        /// <summary>
        /// 流水发生业务时间。发放流水为发放时间，兑换流水为兑换扣减流水的时间
        /// </summary>
        [XmlElement("op_time")]
        public string OpTime { get; set; }

        /// <summary>
        /// 积分变更值
        /// </summary>
        [XmlElement("point")]
        public long Point { get; set; }

        /// <summary>
        /// 流水产生业务标准，说明流水产生原因
        /// </summary>
        [XmlElement("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 积分流水编号
        /// </summary>
        [XmlElement("trans_no")]
        public string TransNo { get; set; }

        /// <summary>
        /// 流水类型，参考入参trans_type
        /// </summary>
        [XmlElement("trans_type")]
        public string TransType { get; set; }
    }
}
