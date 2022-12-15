using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// CreativeDetail Data Structure.
    /// </summary>
    [Serializable]
    public class CreativeDetail : AopObject
    {
        /// <summary>
        /// 落地页动作类型，NO_ACTION-无动作；LP-普通落地页；OPEN_TINYAPP-打开小程序；OPEN_CHANNELS-打开生活号；COLLECT_TINYAPP-收藏小程序；
        /// </summary>
        [XmlElement("action_type")]
        public string ActionType { get; set; }

        /// <summary>
        /// 创意分组标识，多个创意可按业务逻辑标识为一个分组
        /// </summary>
        [XmlElement("batch_tag")]
        public string BatchTag { get; set; }

        /// <summary>
        /// 广告投放平台生成的创意ID
        /// </summary>
        [XmlElement("creative_id")]
        public long CreativeId { get; set; }

        /// <summary>
        /// 外部平台导入广告库后，广告投放创意对应的外部资源ID
        /// </summary>
        [XmlElement("creative_outer_id")]
        public string CreativeOuterId { get; set; }

        /// <summary>
        /// 创意关联的描述列表
        /// </summary>
        [XmlArray("desc_list")]
        [XmlArrayItem("text_instance")]
        public List<TextInstance> DescList { get; set; }

        /// <summary>
        /// 创意业务扩展参数字段，根据第三方需要使用，投放端只做存储并向检索端透传
        /// </summary>
        [XmlElement("extend_info")]
        public string ExtendInfo { get; set; }

        /// <summary>
        /// 外部平台导入广告库后，广告投放单元对应的外部资源ID
        /// </summary>
        [XmlElement("group_outer_id")]
        public string GroupOuterId { get; set; }

        /// <summary>
        /// 创意关联的图片物料列表
        /// </summary>
        [XmlArray("img_list")]
        [XmlArrayItem("material_detail")]
        public List<MaterialDetail> ImgList { get; set; }

        /// <summary>
        /// 门店LBS信息，目前仅口碑使用，格式为：经度:纬度:半径(单位:KM,无半径限制直接设置为0)
        /// </summary>
        [XmlArray("lbs_list")]
        [XmlArrayItem("string")]
        public List<string> LbsList { get; set; }

        /// <summary>
        /// 创意名称，同一单元下的创意名称不能重复，默认设置为门店名称+outer_id
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// 外部平台导入广告库后，广告投放计划对应的外部资源ID
        /// </summary>
        [XmlElement("plan_outer_id")]
        public string PlanOuterId { get; set; }

        /// <summary>
        /// 广告投放平台生成委托人ID
        /// </summary>
        [XmlElement("principal_id")]
        public long PrincipalId { get; set; }

        /// <summary>
        /// 创意审核拒绝原因
        /// </summary>
        [XmlElement("refuse_reason")]
        public string RefuseReason { get; set; }

        /// <summary>
        /// 门店创意关联的城市ID列表，目前仅口碑使用
        /// </summary>
        [XmlArray("region_list")]
        [XmlArrayItem("string")]
        public List<string> RegionList { get; set; }

        /// <summary>
        /// 创意状态，ENABLE-生效；PAUSE-暂停；DELETE-删除；AUDIT-审核中；REFUSED-审核拒绝
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }

        /// <summary>
        /// 门店创意关联门店ID，目前仅口碑使用
        /// </summary>
        [XmlElement("store_id")]
        public string StoreId { get; set; }

        /// <summary>
        /// 落地页appId
        /// </summary>
        [XmlElement("target_app_id")]
        public string TargetAppId { get; set; }

        /// <summary>
        /// 创意落地页url地址
        /// </summary>
        [XmlElement("target_url")]
        public string TargetUrl { get; set; }

        /// <summary>
        /// 创意关联模板ID，由投放平台管理生成
        /// </summary>
        [XmlElement("template_id")]
        public long TemplateId { get; set; }

        /// <summary>
        /// 创意关联的标题列表
        /// </summary>
        [XmlArray("title_list")]
        [XmlArrayItem("text_instance")]
        public List<TextInstance> TitleList { get; set; }

        /// <summary>
        /// 广告投放平台生成广告主/代理商ID
        /// </summary>
        [XmlElement("user_id")]
        public long UserId { get; set; }

        /// <summary>
        /// 创意关联的视频物料列表
        /// </summary>
        [XmlArray("video_list")]
        [XmlArrayItem("material_detail")]
        public List<MaterialDetail> VideoList { get; set; }
    }
}
