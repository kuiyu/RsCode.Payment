using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// DetectServiceEntity Data Structure.
    /// </summary>
    [Serializable]
    public class DetectServiceEntity : AopObject
    {
        /// <summary>
        /// 业务唯一id
        /// </summary>
        [XmlElement("biz_uniq_id")]
        public string BizUniqId { get; set; }

        /// <summary>
        /// 待检测的文本类型
        /// </summary>
        [XmlElement("content")]
        public string Content { get; set; }

        /// <summary>
        /// 检测类型：content_diacrisis-内容检测，load_test-网页性能检测，vulnerabilities_scan-漏洞检测，res_Consumption资源流耗检测.  当content或者pic_url_list有值时，只能选择content_diacrisis;当service有值时，可以选择全部类型。
        /// </summary>
        [XmlArray("detect_type_list")]
        [XmlArrayItem("string")]
        public List<string> DetectTypeList { get; set; }

        /// <summary>
        /// 自定义扩展信息，JSON字符串。  如果detect_type_list包含res_Consumption资源流耗检测，则该字段可以填写流耗检测相关指标信息。(avgImgSize表示页面平均图片大小指标，单位KB；pageSize表示页面大小指标，单位KB；resCheckRela表示上面两个指标逻辑关系，取值or表示或，取值and表示且)
        /// </summary>
        [XmlElement("extend_info")]
        public string ExtendInfo { get; set; }

        /// <summary>
        /// 图片url列表
        /// </summary>
        [XmlArray("pic_url_list")]
        [XmlArrayItem("string")]
        public List<string> PicUrlList { get; set; }

        /// <summary>
        /// 待检测的链接，必须是有效的url
        /// </summary>
        [XmlElement("service")]
        public string Service { get; set; }

        /// <summary>
        /// 描述service,content,pic_url_list的名称信息，方便定位问题
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }
    }
}
