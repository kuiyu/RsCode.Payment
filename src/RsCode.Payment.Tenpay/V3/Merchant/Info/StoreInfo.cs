/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Merchant
{
    /// <summary>
    /// 商户门店信息
    /// </summary>
    public class StoreInfo
    {
        /// <summary>
        ///  门店编号
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }
        /// <summary>
        ///  门店名称
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = "";
        /// <summary>
        ///  地区编码
        /// </summary>
        [JsonPropertyName("area_code")]
        public string AreaCode { get; set; } = "";
        /// <summary>
        ///  详细地址
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; } = "";
    }
}
