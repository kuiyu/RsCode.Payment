/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 协议:MIT License 2.0 
 * 作者:河南软商网络科技有限公司 
 * 项目己托管于  
 * github
   https://github.com/kuiyu/RsCode.Payment.git
 */
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V2.Partner
{
    /// <summary>
    /// 服务商请求单次分账
    /// </summary>
    public class ProfitSharingRequest:WxPayData,TenpayBaseRequest
    {
        #region 参数
        /// <summary>
        /// 商户号
        /// </summary>
        [Required] [JsonPropertyName("mch_id")] public string MchId { get; set; }
        /// <summary>
        /// 微信支付分配的子商户号，即分账的出资商户号
        /// </summary>
        [JsonPropertyName("sub_mch_id")] public string SubMchId { get; set; }
        /// <summary>
        /// 品牌主商户号
        /// </summary>
        [JsonPropertyName("brand_mch_id")] public string BrandMchId { get; set; }
        /// <summary>
        /// 微信分配的服务商appid
        /// </summary>
        [Required] [JsonPropertyName("appid")] public string AppId { get; set; }
        /// <summary>
        /// 微信分配的子商户公众账号ID
        /// </summary>
        [JsonPropertyName("sub_appid")] public string SubAppId { get; set; }

        [Required]
        [JsonPropertyName("nonce_str")]
        public string NonceStr { get { return TenpayTool.GetNonceStr(); } }
        /// <summary>
        /// 签名
        /// </summary>
        [Required]
        [JsonPropertyName("sign")]
        public string Sign { get; set; }

        /// <summary>
        /// 签名类型，目前只支持HMAC-SHA256
        /// </summary>
        [Required]
        [JsonPropertyName("sign_type")]
        public string SignType { get; set; }

        /// <summary>
        /// 微信订单号
        /// </summary>
        [Required]
        [JsonPropertyName("transaction_id")]
        public string TransactionId { get; set; }
        /// <summary>
        /// 商户分账单号
        /// </summary>
        [Required]
        [JsonPropertyName("out_order_no")]
        public string OutOrderNo { get; set; }
        /// <summary>
        /// 分账接收方列表
        /// 不超过50个json对象，不能设置分账方作为分账接受方
        /// </summary>
        [Required]
        [JsonPropertyName("receivers")]
        public List<ProfitSharingReceiverInfo> Receivers { get; set; }


        #endregion
       

        public string GetApiUrl()
        {
            return "https://api.mch.weixin.qq.com/secapi/pay/profitsharing";
        }

        public string RequestMethod()
        {
            return "POST"; 
        }

        
    }
}
