using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// MiniAppPluginReference Data Structure.
    /// </summary>
    [Serializable]
    public class MiniAppPluginReference : AopObject
    {
        /// <summary>
        /// 插件id，即插件的唯一标识，形如小程序的appId
        /// </summary>
        [XmlElement("plugin_id")]
        public string PluginId { get; set; }

        /// <summary>
        /// 小程序引用的插件版本，可以指定插件版本，如：1.0.11；也可以填*，表示引用最新的插件版本，此时，当插件发布新版本后，小程序内的插件会自动更新到最新的版本。
        /// </summary>
        [XmlElement("plugin_version")]
        public string PluginVersion { get; set; }
    }
}
