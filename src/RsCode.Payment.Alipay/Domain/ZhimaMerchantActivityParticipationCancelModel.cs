using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// ZhimaMerchantActivityParticipationCancelModel Data Structure.
    /// </summary>
    [Serializable]
    public class ZhimaMerchantActivityParticipationCancelModel : AopObject
    {
        /// <summary>
        /// 承诺消费合约号
        /// </summary>
        [XmlElement("contract_no")]
        public string ContractNo { get; set; }
    }
}
