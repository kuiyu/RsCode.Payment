using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayEbppOrderItemCreateModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayEbppOrderItemCreateModel : AopObject
    {
        /// <summary>
        /// 预创单失效时间，此时间点后不允许再支付。  格式：yyyy-MM-dd HH:mm:ss
        /// </summary>
        [XmlElement("expire_at")]
        public string ExpireAt { get; set; }

        /// <summary>
        /// 需要创建的订单子项
        /// </summary>
        [XmlElement("item_to_create")]
        public EbppOrderItemToCreate ItemToCreate { get; set; }

        /// <summary>
        /// 要求创建支付宝二维码，可供用户扫码后直接支付.  默认值为false
        /// </summary>
        [XmlElement("qrcode_required")]
        public bool QrcodeRequired { get; set; }
    }
}
