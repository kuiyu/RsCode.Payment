using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayCommerceKidsAccountModifyModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayCommerceKidsAccountModifyModel : AopObject
    {
        /// <summary>
        /// 格式为yyyy-MM-dd，需要满足18周岁以下（不包含18周岁生日当天）
        /// </summary>
        [XmlElement("birthday")]
        public string Birthday { get; set; }

        /// <summary>
        /// 手机号码, 目前仅支持13位大陆手机号
        /// </summary>
        [XmlElement("mobile")]
        public string Mobile { get; set; }

        /// <summary>
        /// 请输入真实姓名，需满足五个以内汉字
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// 第三方业务id，需保证唯一或者和业务类型组合保证唯一，用于关联上传到支付宝的数据，比如在智能设备场景通常使用硬件唯一id
        /// </summary>
        [XmlElement("out_biz_id")]
        public string OutBizId { get; set; }

        /// <summary>
        /// 外围业务类型，比如智能设备场景表示设备型号
        /// </summary>
        [XmlElement("out_biz_type")]
        public string OutBizType { get; set; }

        /// <summary>
        /// 场景码，接入前需进行申请
        /// </summary>
        [XmlElement("scene_code")]
        public string SceneCode { get; set; }
    }
}
