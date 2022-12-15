/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 协议:MIT License 2.0 
 * 作者:河南软商网络科技有限公司 
 * 项目己托管于  
 * github
   https://github.com/kuiyu/RsCode.Payment.git
 */
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V2.Partner
{
    /// <summary>
    /// 查询分账结果
    /// 发起分账请求后，可调用此接口查询分账结果；发起分账完结请求后，可调用此接口查询分账完结的执行结果。
    /// https://pay.weixin.qq.com/wiki/doc/api/allocation_sl.php?chapter=25_2&index=3
    /// </summary>
    public class ProfitSharingQueryRequest : WxPayData, TenpayBaseRequest
    {
        #region 参数
        /// <summary>
        /// 微信支付分配的服务商商户号
        /// </summary>
        [Required] [JsonPropertyName("mch_id")] public string MchId { get; set; }
        /// <summary>
        /// 微信支付分配的子商户号，即分账的出资商户号
        /// </summary>
        [JsonPropertyName("sub_mch_id")] public string SubMchId { get; set; }
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
        public string SignType { get; set; } = "HMAC-SHA256";

        #endregion

        public void CreateSign(PayOptions payOptions)
        {
            MchId = payOptions.MchId;
            
        }
        public string GetApiUrl()
        {
            return "https://api.mch.weixin.qq.com/pay/profitsharingquery";
        }

        public string RequestMethod()
        {
            return "POST";
        }
    }
}
