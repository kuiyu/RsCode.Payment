using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// CodeResult Data Structure.
    /// </summary>
    [Serializable]
    public class CodeResult : AopObject
    {
        /// <summary>
        /// code，唯一，码值
        /// </summary>
        [XmlElement("code")]
        public string Code { get; set; }

        /// <summary>
        /// code_token，唯一，码值中的token
        /// </summary>
        [XmlElement("code_token")]
        public string CodeToken { get; set; }

        /// <summary>
        /// code_url，生成的二维码图片url。这个url可通过参数控制图片样式，pigSize：256，512，1546px；添加&d参数，直接下载，默认是302到OSS预览；trans，默认true，底色透明，false底色为白。chrome建议添加trans=false参数。
        /// </summary>
        [XmlElement("code_url")]
        public string CodeUrl { get; set; }
    }
}
