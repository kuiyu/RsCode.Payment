using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Partner
{
    /// <summary>
    /// 查询结算账户API
    /// https://pay.weixin.qq.com/wiki/doc/apiv3/wxpay/tool/applyment4sub/chapter3_4.shtml
    /// </summary>
    public class ApplymentSubSettlementRequest:TenpayBaseRequest
    {
        [JsonPropertyName("sub_mchid")]
        public string SubMchId { get; set; }
        public string GetApiUrl()
        {
            return $"https://api.mch.weixin.qq.com/v3/apply4sub/sub_merchants/{SubMchId}/settlement";
        }
        public string RequestMethod()
        {
            return "GET";
        }
    }
}
