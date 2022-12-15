using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Aop.Api.Domain;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipayOpenMiniDataVisitQueryResponse.
    /// </summary>
    public class AlipayOpenMiniDataVisitQueryResponse : AopResponse
    {
        /// <summary>
        /// 小程序当日pv
        /// </summary>
        [XmlElement("app_pv")]
        public long AppPv { get; set; }

        /// <summary>
        /// 小程序当日uv
        /// </summary>
        [XmlElement("app_uv")]
        public long AppUv { get; set; }

        /// <summary>
        /// 小程序的区域pv、uv等数据列表
        /// </summary>
        [XmlArray("area_detail_list")]
        [XmlArrayItem("area_detail")]
        public List<AreaDetail> AreaDetailList { get; set; }
    }
}
