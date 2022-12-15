using System;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Partner
{
    /// <summary>
    /// 通过业务申请编号查询申请状态
    /// https://pay.weixin.qq.com/wiki/doc/apiv3/wxpay/tool/applyment4sub/chapter3_2.shtml
    /// </summary>
    public class ApplymentQueryRequest:TenpayBaseRequest
    {
        /// <summary>
        /// 业务申请编号
        /// </summary>
        [JsonPropertyName("business_code")]
        public string BusinessCode { get; set; }
        /// <summary>
        /// 微信支付分的申请单号
        /// </summary>
        [JsonPropertyName("applyment_id")]
        public long ApplymentId { get; set; }
        public string GetApiUrl()
        {
            if(!string.IsNullOrWhiteSpace(BusinessCode))
            {
                return $"https://api.mch.weixin.qq.com/v3/applyment4sub/applyment/business_code/{BusinessCode}";
            }
            if (ApplymentId>0)
            {
                return $"https://api.mch.weixin.qq.com/v3/applyment4sub/applyment/applyment_id/{ApplymentId}";
            }
            throw new Exception("缺少必要的参数");
            
        }
        public string RequestMethod()
        {
            return "GET";
        }
    }
}
