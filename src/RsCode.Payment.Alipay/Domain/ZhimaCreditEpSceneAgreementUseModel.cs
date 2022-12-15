using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// ZhimaCreditEpSceneAgreementUseModel Data Structure.
    /// </summary>
    [Serializable]
    public class ZhimaCreditEpSceneAgreementUseModel : AopObject
    {
        /// <summary>
        /// 特定业务场景传输的扩展参数，以JSON形式传输。具体业务场景需要传入参数请参考<a href="https://docs.open.alipay.com/11270#s3">业务场景传输的扩展参数</a>
        /// </summary>
        [XmlElement("biz_ext_param")]
        public string BizExtParam { get; set; }

        /// <summary>
        /// 业务时间，日期格式为 yyyy-MM-dd HH:mm:ss
        /// </summary>
        [XmlElement("biz_time")]
        public string BizTime { get; set; }

        /// <summary>
        /// 商户请求订单号，必须唯一。用于唯一标识商户的一笔业务请求。
        /// </summary>
        [XmlElement("out_order_no")]
        public string OutOrderNo { get; set; }

        /// <summary>
        /// 条款编码。请参考<a href="https://docs.open.alipay.com/11270#s1">条款编码</a>
        /// </summary>
        [XmlElement("provision_code")]
        public string ProvisionCode { get; set; }

        /// <summary>
        /// 评估订单号。在用户完成信用评估后可以获取。信用评估流程关联接口见：zhima.credit.ep.scene.rating.initialize；zhima.credit.ep.scene.rating.apply。
        /// </summary>
        [XmlElement("rating_order_no")]
        public string RatingOrderNo { get; set; }
    }
}
