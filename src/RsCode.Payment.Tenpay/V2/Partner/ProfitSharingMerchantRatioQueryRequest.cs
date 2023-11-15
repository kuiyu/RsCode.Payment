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
    /// 查询订单最大分账比例
    /// https://pay.weixin.qq.com/wiki/doc/api/allocation_sl.php?chapter=25_11&index=8
    /// </summary>
    public class ProfitSharingMerchantRatioQueryRequest:WxPayData,TenpayBaseRequest
    {
        #region 参数
        /// <summary>
        /// 微信支付分配的服务商商户号
        /// </summary>
        [JsonPropertyName("mch_id")] public string MchId { get; set; }
        /// <summary>
        /// 微信支付分配的子商户号，即分账的出资商户号。
        /// </summary>
        [JsonPropertyName("sub_mch_id")] public string SubMchId { get; set; }

        /// <summary>
        /// 当服务商开通了“连锁品牌工具”后，使用品牌供应链分账时，传入品牌主商户号，查询品牌主设置的全局分账比例，品牌主下的门店适用于此比例
        /// </summary>

        [JsonPropertyName("brand_mch_id")]
        public string BrandMchId { get; set; }


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
            return "https://api.mch.weixin.qq.com/pay/profitsharingmerchantratioquery";
        }

        public string RequestMethod()
        {
            return "POST";
        }
    }
}
