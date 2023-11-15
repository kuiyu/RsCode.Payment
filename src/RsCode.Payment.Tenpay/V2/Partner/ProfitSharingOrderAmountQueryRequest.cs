/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V2.Partner
{
    /// <summary>
    /// 服务商可通过调用此接口查询订单剩余待分金额。
    /// https://pay.weixin.qq.com/wiki/doc/api/allocation_sl.php?chapter=25_10&index=7
    /// </summary>
    public class ProfitSharingOrderAmountQueryRequest:WxPayData,TenpayBaseRequest
    {
        #region 参数
        /// <summary>
        /// 微信支付分配的服务商商户号
        /// </summary>
         [JsonPropertyName("mch_id")] public string MchId { get; set; }
       
        /// <summary>
        /// 微信订单号
        /// </summary>
        
        [JsonPropertyName("transaction_id")]
        public string TransactionId { get; set; }
       
        
        [JsonPropertyName("nonce_str")]
        public string NonceStr { get { return TenpayTool.GetNonceStr(); } }
        /// <summary>
        /// 签名
        /// </summary>
        
        [JsonPropertyName("sign")]
        public string Sign { get; set; }

        /// <summary>
        /// 签名类型，目前只支持HMAC-SHA256
        /// </summary>
        
        [JsonPropertyName("sign_type")]
        public string SignType { get; set; } = "HMAC-SHA256";

        #endregion

        public void CreateSign(PayOptions payOptions)
        {
            MchId = payOptions.MchId;

        }
        public string GetApiUrl()
        {
            return "https://api.mch.weixin.qq.com/pay/profitsharingorderamountquery";
        }

        public string RequestMethod()
        {
            return "POST";
        }
    }
}
