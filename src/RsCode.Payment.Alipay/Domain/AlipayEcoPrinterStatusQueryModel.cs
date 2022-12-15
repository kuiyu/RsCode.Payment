using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayEcoPrinterStatusQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayEcoPrinterStatusQueryModel : AopObject
    {
        /// <summary>
        /// 应用ID
        /// </summary>
        [XmlElement("client_id")]
        public string ClientId { get; set; }

        /// <summary>
        /// 应用Secret
        /// </summary>
        [XmlElement("client_secret")]
        public string ClientSecret { get; set; }

        /// <summary>
        /// 应用访问凭证
        /// </summary>
        [XmlElement("eprint_token")]
        public string EprintToken { get; set; }

        /// <summary>
        /// 终端号
        /// </summary>
        [XmlElement("machine_code")]
        public string MachineCode { get; set; }
    }
}
