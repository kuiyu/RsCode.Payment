/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.Domain
{
    /// <summary>
    /// 确认订单通知参数
    /// https://pay.weixin.qq.com/wiki/doc/apiv3/wxpay/payscore/chapter5_2.shtml
    /// </summary>
    public class OrderConfirmNotify
    {
        #region 参数
        /// <summary>
        /// 公众账号ID
        /// </summary>
        [Required] [JsonPropertyName("appid")] public string AppId { get; set; }

        /// <summary>
        /// 调用接口提交的商户号
        /// </summary>
        [Required] [JsonPropertyName("mchid")] public string MchId { get; set; }

        /// <summary>
        ///商户服务订单号
        /// </summary>
        [Required]
        [JsonPropertyName("out_order_no")]
        public string OutOrderNo { get; set; }

        /// <summary>
        /// 服务ID
        /// </summary>
        [JsonPropertyName("service_id")] public string ServiceId { get; set; }
        /// <summary>
        /// 微信用户在商户对应appid下的唯一标识
        /// </summary>
        [JsonPropertyName("openid")] public string OpenId { get; set; }
        /// <summary>
        /// 服务订单状态
        /// </summary>
        [Required]
        [JsonPropertyName("state")]
        public string State { get; set; }

        /// <summary>
        /// 订单状态说明
        /// </summary>
        [JsonPropertyName("state_description")]
        public string StateDescription { get; set; }

        /// <summary>
        /// 商户收款总金额
        /// </summary>
        [JsonPropertyName("total_amount")]
        public int TotalAmount { get; set; }

        /// <summary>
        /// 服务信息
        /// </summary>
        [JsonPropertyName("service_introduction")]
        public string ServiceIntroduction { get; set; }



























        /// <summary>
        /// 商户数据包
        /// </summary>
        [JsonPropertyName("attach")]
        public string Attach { get; set; }

        /// <summary>
        /// 微信支付服务订单号
        /// </summary>
        [Required]
        [JsonPropertyName("order_id")]
        public string OrderId { get; set; } 

        /// <summary>
        /// 是否需要收款
        /// </summary>       
        [JsonPropertyName("need_collection")]
        public bool NeedCollection { get; set; }
         
        #endregion
    }

    /// <summary>
    /// 后付费项目列表
    /// </summary>
    public class PostPayments
    {
        /// <summary>
        /// 付费项目名称
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        [JsonPropertyName("amount")]
        public int Amount { get; set; }
        /// <summary>
        /// 计费说明
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }
        /// <summary>
        /// 付费数量
        /// </summary>
        [JsonPropertyName("count")]
        public string Count { get; set; }
         
    }

    /// <summary>
    /// 商户优惠 
    /// </summary>
    public class PostDiscounts
    {
        /// <summary>
        /// 优惠名称
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
        /// <summary>
        /// 优惠说明
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }
        /// <summary>
        /// 优惠金额
        /// </summary>
        [JsonPropertyName("amount")]
        public int Amount { get; set; }
    }
    /// <summary>
    /// 订单风险金信息
    /// </summary>
    public class RiskFund
    {
        /// <summary>
        /// 风险名称
        /// </summary>
        [JsonPropertyName("name")]
        public string Name  { get; set; }
        /// <summary>
        /// 风险金额
        /// </summary>
        [JsonPropertyName("amount")]
        public int Amount { get; set; }
        /// <summary>
        /// 风险说明
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
    /// <summary>
    /// 服务使用时间范围
    /// </summary>
    public class TimeRange
    {
        /// <summary>
        /// 服务开始时间
        /// </summary>
        [JsonPropertyName("start_time")]
        public string StartTime { get; set; }
        /// <summary>
        /// 服务开始时间备注
        /// </summary>
        [JsonPropertyName("start_time_remark")]
        public string StartTimeRemark { get; set; }
       
        
        /// <summary>
        /// 服务结束时间
        /// </summary>
        [JsonPropertyName("end_time")]
        public string EndTime { get; set; }
        /// <summary>
        /// 服务结束时间备注
        /// </summary>
        [JsonPropertyName("end_time_remark")]
        public string EndTimeRemark { get; set; }
    }
    /// <summary>
    /// 服务位置
    /// </summary>
    public class Location
    {
        /// <summary>
        /// 服务开始地点
        /// 开始使用服务的地点，当参数长度超出20个字符时，报错处理。 
        /// </summary>
        [JsonPropertyName("start_location")]
        public string StartLocation { get; set; }
        /// <summary>
        /// 服务结束位置
        /// 预计服务结束的地点，用户下单时未确认服务结束地点时，可不填写
        /// </summary>
        [JsonPropertyName("end_location")]
        public string EndLocation { get; set; }


    }
}
