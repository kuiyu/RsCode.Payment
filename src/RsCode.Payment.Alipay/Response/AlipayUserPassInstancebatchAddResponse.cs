using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipayUserPassInstancebatchAddResponse.
    /// </summary>
    public class AlipayUserPassInstancebatchAddResponse : AopResponse
    {
        /// <summary>
        /// opType表示操作类型，目前固定为ADD。errorCode和errorMsg对应错误信息。passList是券实例列表，仅当发券成功才有值，其中：  serialNumber：唯一核销凭证串号（必须由动态传参指定）   passId：券唯一id   order：券在大礼包中的顺序
        /// </summary>
        [XmlArray("result")]
        [XmlArrayItem("string")]
        public List<string> Result { get; set; }

        /// <summary>
        /// 操作结果标识，true：成功，false：失败。
        /// </summary>
        [XmlElement("success")]
        public string Success { get; set; }
    }
}
