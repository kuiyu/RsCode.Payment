using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// ZhimaCreditContractBorrowReturnModel Data Structure.
    /// </summary>
    [Serializable]
    public class ZhimaCreditContractBorrowReturnModel : AopObject
    {
        /// <summary>
        /// 外部类目,样例：图书馆:BOOK
        /// </summary>
        [XmlElement("category")]
        public string Category { get; set; }

        /// <summary>
        /// 扩展字段，目前留空
        /// </summary>
        [XmlElement("ext")]
        public string Ext { get; set; }

        /// <summary>
        /// 外部订单号
        /// </summary>
        [XmlElement("out_trans_no")]
        public string OutTransNo { get; set; }

        /// <summary>
        /// 商户入驻芝麻服务后，得到的服务id，在服务入驻后台可看到
        /// </summary>
        [XmlElement("service_id")]
        public string ServiceId { get; set; }

        /// <summary>
        /// 归还的物品列表，包括每本书的唯一id，物品类型，物品名称
        /// </summary>
        [XmlElement("subjects_returned")]
        public string SubjectsReturned { get; set; }
    }
}
