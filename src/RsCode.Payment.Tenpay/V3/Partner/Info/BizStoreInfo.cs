using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Partner
{
    /// <summary>
    /// 线下门店场景
    /// </summary>
    public class BizStoreInfo
    {
        /// <summary>
        /// 门店名称
        /// </summary>
        [JsonPropertyName("biz_store_name")]
        public string BizStoreName { get; set; }
        /// <summary>
        /// 门店省市编码
        /// </summary>
        [JsonPropertyName("biz_address_code")]
        public string BizAddressCode { get; set; }
        /// <summary>
        /// 门店地址
        /// </summary>
        [JsonPropertyName("biz_store_address")]
        public string BizStoreAddress { get; set; }
        /// <summary>
        /// 门店门头照片
        /// </summary>
        [JsonPropertyName("store_entrance_pic")]
        public string StoreEntrancePic { get; set; }
        /// <summary>
        /// 店内环境照片
        /// </summary>
        [JsonPropertyName("indoor_pic")]
        public string[] IndoorPic { get; set; }
        /// <summary>
        /// 线下场所对应的商家APPID
        /// </summary>
        [JsonPropertyName("biz_sub_appid")]
        public string BizSubAppId { get; set; }
    }
}
