using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Partner
{
    /// <summary>
    /// 企业微信场景
    /// </summary>
    public class WeWorkInfo
    {
        /// <summary>
        /// 商家企业微信CorpID
        /// </summary>
        [JsonPropertyName("sub_corp_id")]
        public string SubCorpId { get; set; }

        /// <summary>
        /// 企业微信页面截图
        /// 1、最多可上传5张照片。
        ///2、请填写通过《图片上传API》预先上传图片生成好的MediaID
        /// </summary>
        [JsonPropertyName("wework_pics")]
        public string[] WeWorkPics { get; set; }
    }
}
