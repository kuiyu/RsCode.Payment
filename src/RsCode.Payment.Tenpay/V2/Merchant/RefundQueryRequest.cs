/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V2.Merchant
{
    /// <summary>
    /// 查询退款
    /// https://pay.weixin.qq.com/wiki/doc/api/micropay.php?chapter=9_5
    /// https://pay.weixin.qq.com/wiki/doc/api/jsapi.php?chapter=9_5
    /// https://pay.weixin.qq.com/wiki/doc/api/native.php?chapter=9_5
    /// </summary>
    public class RefundQueryRequest: WxPayData, TenpayBaseRequest
    {
        #region 参数
        /// <summary>
        /// 公众账号ID 
        /// </summary>
         [JsonPropertyName("appid")] public string AppId { get; set; }
        /// <summary>
        /// 商户号
        /// </summary>
         [JsonPropertyName("mch_id")] public string MchId { get; set; }
        /// <summary>
        /// 随机字符串，不长于32位
        /// </summary>
         [JsonPropertyName("nonce_str")] public string NonceStr { get; set; }
         [JsonPropertyName("sign")] public string Sign { get; set; }
        /// <summary>
        /// 签名类型，目前支持HMAC-SHA256和MD5，默认为MD5
        /// </summary>
        [JsonPropertyName("sign_type")]
        public string SignType { get; set; }
        /// <summary>
        /// 微信的订单号，建议优先使用 
        /// </summary>
        [JsonPropertyName("transaction_id")] public string TransactionId { get; set; }

        /// <summary>
        /// 商户系统内部订单号，要求32个字符内
        /// </summary>
        [JsonPropertyName("out_trade_no")] public string OutTradeNo { get; set; }


        /// <summary>
        /// 商户系统内部的退款单号
        /// </summary>
         [JsonPropertyName("out_refund_no")] public string OutRefundNo { get; set; }
        /// <summary>
        /// 微信退款单号  微信生成的退款单号，在申请退款接口有返回
        /// </summary>
         [JsonPropertyName("refund_id")] public string RefundId { get; set; }
        /// <summary>
        /// 退款总金额，订单总金额，单位为分
        /// </summary>
         [JsonPropertyName("offset")] public int Offset { get; set; }

        public string GetApiUrl()
        {
            string url = "https://api.mch.weixin.qq.com/pay/refundquery";
            return url;
        }




        #endregion
       
      
        public string RequestMethod()
        {
            return "POST";
        }
    }
}
