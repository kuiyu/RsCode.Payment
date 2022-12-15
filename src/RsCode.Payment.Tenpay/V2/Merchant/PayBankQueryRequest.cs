using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V2.Merchant
{
    /// <summary>
    /// 查询企业付款银行卡API
    /// 用于对商户企业付款到银行卡操作进行结果查询，返回付款操作详细结果。
    /// https://pay.weixin.qq.com/wiki/doc/api/tools/mch_pay.php?chapter=24_3
    /// </summary>
    public class PayBankQueryRequest: WxPayData, TenpayBaseRequest
    {
        #region 参数
        /// <summary>
        /// 商户号
        /// </summary>
        [Required] [JsonPropertyName("mch_id")] public string MchId { get; set; }
        /// <summary>
        /// 商户企业付款单号
        /// </summary>
        [Required] [JsonPropertyName("partner_trade_no")] public string PartnerTradeNo { get; set; }
        [Required]
        [JsonPropertyName("nonce_str")]
        public string NonceStr { get { return TenpayTool.GetNonceStr(); } }
        /// <summary>
        /// 签名
        /// </summary>
        [Required]
        [JsonPropertyName("sign")]
        public string Sign { get; set; }
        

        #endregion

        public  string GetApiUrl()
        {
            string url = "https://api.mch.weixin.qq.com/mmpaysptrans/query_bank";
            return url;
        }

        public string RequestMethod()
        {
            return "POST";
        }
    }
}
