using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AntfortuneEquityInstpointSendModel Data Structure.
    /// </summary>
    [Serializable]
    public class AntfortuneEquityInstpointSendModel : AopObject
    {
        /// <summary>
        /// 积分发放备注
        /// </summary>
        [XmlElement("memo")]
        public string Memo { get; set; }

        /// <summary>
        /// 比如某种业务标准外部订单号,比如交易外部订单号，代表商户端自己订单号
        /// </summary>
        [XmlElement("out_biz_no")]
        public string OutBizNo { get; set; }

        /// <summary>
        /// 本次发放的积分值，商户必须设置值指定本次发放给用户的具体积分值，取值范围[1,10000]
        /// </summary>
        [XmlElement("point")]
        public long Point { get; set; }

        /// <summary>
        /// 积分预算模板号，商户在财富开放后台创建积分模板后获得
        /// </summary>
        [XmlElement("template_no")]
        public string TemplateNo { get; set; }

        /// <summary>
        /// 蚂蚁统一会员ID
        /// </summary>
        [XmlElement("user_id")]
        public string UserId { get; set; }
    }
}
