using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// KoubeiCateringPosPracticeQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiCateringPosPracticeQueryModel : AopObject
    {
        /// <summary>
        /// 门店id
        /// </summary>
        [XmlElement("shop_id")]
        public string ShopId { get; set; }
    }
}
