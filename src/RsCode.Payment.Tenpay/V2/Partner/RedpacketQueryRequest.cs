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
    /// 服务商查询红包
    /// https://pay.weixin.qq.com/wiki/doc/api/tools/cash_coupon_sl.php?chapter=13_6&index=5
    /// </summary>
    public class RedpacketQueryRequest : TenpayBaseRequest
    {
        #region 参数
        /// <summary>
        /// 随机字符串
        /// </summary>
        
        [JsonPropertyName("nonce_str")]
        public string NonceStr { get { return TenpayTool.GetNonceStr(); } }
        /// <summary>
        /// 签名
        /// </summary>
        
        [JsonPropertyName("sign")]
        public string Sign { get; set; }
        /// <summary>
        /// 商户订单号
        /// </summary>
         [JsonPropertyName("mch_billno")] public string MchBillNo { get; set; }
        /// <summary>
        /// 商户号
        /// </summary>
         [JsonPropertyName("mch_id")] public string MchId { get; set; }
        /// <summary>
        /// 微信分配的公众账号ID（企业号corpid即为此appId），接口传入的所有appid应该为公众号的appid（在mp.weixin.qq.com申请的），不能为APP的appid（在open.weixin.qq.com申请的）。
        /// 在微信开放平台（open.weixin.qq.com）申请的移动应用appid无法使用该接口。
        /// </summary>
         [JsonPropertyName("appid")] public string AppId { get; set; }
        /// <summary>
        /// 订单类型
        /// MCHT:通过商户订单号获取红包信息。
        /// </summary>
         [JsonPropertyName("bill_type")] public string BillType { get; set; } = "MCHT";

        #endregion

        public string GetApiUrl()
        {
            string url = "https://api.mch.weixin.qq.com/mmpaymkttransfers/gethbinfo";
            return url;
        }

        public string RequestMethod()
        {
            return "POST";
        }
    }
}