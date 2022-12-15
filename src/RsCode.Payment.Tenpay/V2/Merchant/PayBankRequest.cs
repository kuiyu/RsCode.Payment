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
    /// 企业付款到银行卡API
    ///<see cref="https://pay.weixin.qq.com/wiki/doc/api/tools/mch_pay.php?chapter=24_2"/> 
    /// </summary>
    public class PayBankRequest: WxPayData, TenpayBaseRequest
    {
        #region 参数
        /// <summary>
        /// 商户号
        /// </summary>
        [Required] [JsonPropertyName("mch_id")] public string MchId { get; set; }
        /// <summary>
        /// 商户订单号
        /// </summary>
        [Required] [JsonPropertyName("partner_trade_no")] public string PartnerTradeNo { get; set; }
        [Required]
        [JsonPropertyName("nonce_str")]
        public string NonceStr { get; set; } = TenpayTool.GetNonceStr();
        /// <summary>
        /// 签名
        /// </summary>
        [Required]
        [JsonPropertyName("sign")]
        public string Sign { get; set; }
        /// <summary>
        /// 收款方银行卡号
        /// </summary>
        [Required] [JsonPropertyName("enc_bank_no")] public string EncBankNo { get; set; }

        /// <summary>
        /// 收款方用户名
        /// </summary>
        [JsonPropertyName("enc_true_name")] public string EncTrueName { get; set; }

        /// <summary> 
        ///银行卡所在开户行编号
        /// </summary>
        [Required] [JsonPropertyName("bank_code")] public string BankCode { get; set; }

 
        /// <summary>
        /// 企业付款金额，单位为分
        /// </summary>
        [Required] [JsonPropertyName("amount")] public int Amount { get; set; }
        /// <summary>
        /// 企业付款备注
        /// </summary>
       [JsonPropertyName("desc")] public string Desc { get; set; }

       



        #endregion
 public string GetApiUrl()
        {
            string url = "https://api.mch.weixin.qq.com/mmpaysptrans/pay_bank";
            return url;
        }
        
         

        public string RequestMethod()
        {
            return "POST";
        }
    }
}
