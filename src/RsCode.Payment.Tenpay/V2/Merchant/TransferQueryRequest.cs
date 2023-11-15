/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V2.Merchant
{
    /// <summary>
    /// 查询企业付款
    /// https://pay.weixin.qq.com/wiki/doc/api/tools/mch_pay.php?chapter=14_3
    /// </summary>
    public class TransferQueryRequest: WxPayData, TenpayBaseRequest
    {
        #region 参数
        /// <summary>
        /// 随机字符串
        /// </summary>
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
        /// 商户订单号
        /// </summary>
        [Required] [JsonPropertyName("partner_trade_no")] public string PartnerTradeNo { get; set; }
        /// <summary>
        /// 商户号
        /// </summary>
        [Required] [JsonPropertyName("mch_id")] public string MchId { get; set; }
        /// <summary>
        /// Appid
        /// </summary>
        [JsonPropertyName("appid")] public string AppId { get; set; } 
         

        #endregion

        public  string GetApiUrl()
        {
            string url = "https://api.mch.weixin.qq.com/mmpaymkttransfers/gettransferinfo";
            return url;
        }

        public string RequestMethod()
        {
            return "POST";
        }
    }
}
