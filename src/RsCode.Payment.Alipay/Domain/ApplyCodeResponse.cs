using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// ApplyCodeResponse Data Structure.
    /// </summary>
    [Serializable]
    public class ApplyCodeResponse : AopObject
    {
        /// <summary>
        /// apply_code_results，申请S码的结果中的批量发码结果
        /// </summary>
        [XmlArray("apply_code_result")]
        [XmlArrayItem("apply_code_result")]
        public List<ApplyCodeResult> ApplyCodeResult { get; set; }
    }
}
