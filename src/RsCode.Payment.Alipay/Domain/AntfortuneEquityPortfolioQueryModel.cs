using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AntfortuneEquityPortfolioQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AntfortuneEquityPortfolioQueryModel : AopObject
    {
        /// <summary>
        /// 组合ID
        /// </summary>
        [XmlElement("product_id")]
        public string ProductId { get; set; }
    }
}
