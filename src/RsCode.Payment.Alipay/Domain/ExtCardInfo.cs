using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// ExtCardInfo Data Structure.
    /// </summary>
    [Serializable]
    public class ExtCardInfo : AopObject
    {
        /// <summary>
        /// 托管子户外卡户名
        /// </summary>
        [XmlElement("bank_acc_name")]
        public string BankAccName { get; set; }

        /// <summary>
        /// 托管子户外卡开户行
        /// </summary>
        [XmlElement("card_bank")]
        public string CardBank { get; set; }

        /// <summary>
        /// 托管子户外卡支行
        /// </summary>
        [XmlElement("card_branch")]
        public string CardBranch { get; set; }

        /// <summary>
        /// 托管子户外卡联行号
        /// </summary>
        [XmlElement("card_deposit")]
        public string CardDeposit { get; set; }

        /// <summary>
        /// 托管子户外卡开户地址
        /// </summary>
        [XmlElement("card_location")]
        public string CardLocation { get; set; }

        /// <summary>
        /// 托管子户的外卡卡号
        /// </summary>
        [XmlElement("card_no")]
        public string CardNo { get; set; }

        /// <summary>
        /// 托管子户外卡状态
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }
    }
}
