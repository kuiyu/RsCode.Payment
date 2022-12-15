using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V2.Merchant
{
    /// <summary>
    /// 获取RSA加密公钥
    /// https://pay.weixin.qq.com/wiki/doc/api/tools/mch_pay.php?chapter=24_7&index=4
    /// </summary>
    public class PublicKeyQueryRequest: WxPayData, TenpayBaseRequest
    {
        #region 参数
        /// <summary>
        /// 商户号
        /// </summary>
        [Required] [JsonPropertyName("mch_id")] public string MchId { get; set; }
     
        [Required]
        [JsonPropertyName("nonce_str")]
        public string NonceStr { get { return TenpayTool.GetNonceStr(); } }
        /// <summary>
        /// 签名
        /// </summary>
        [Required]
        [JsonPropertyName("sign")]
        public string Sign { get; set; }

        [Required]
        [JsonPropertyName("sign_type")]
        public string SignType { get; set; }

       
        #endregion

      
          public string GetApiUrl()
        {
            string url = "https://fraud.mch.weixin.qq.com/risk/getpublickey";
            return url;
        }
        public string RequestMethod()
        {
            return "POST";
        }
    }
}
