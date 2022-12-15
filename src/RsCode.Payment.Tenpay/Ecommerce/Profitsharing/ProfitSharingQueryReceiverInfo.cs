/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.ECommerce.Profitsharing
{
    /// <summary>
    /// 分账查询时接收方信息
    /// </summary>
    public class ProfitSharingQueryReceiverInfo
    {
        /// <summary>
        /// 填写微信支付分配的商户号，仅支持通过添加分账接收方接口添加的接收方；
        /// 电商平台商户已默认添加到分账接收方，无需重复添加。
        /// </summary>
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("receiver_mchid")]
        public string ReceiverMchId { get; set; }

        /// <summary>
        /// 分账金额
        /// </summary> 
        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// 分账的原因描述，分账账单中需要体现
        /// </summary>
        [MinLength(1)]
        [MaxLength(80)]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// 分账结果，枚举值：
        ///PENDING：待分账
        ///SUCCESS：分账成功
        ///ADJUST：分账失败待调账
        ///RETURNED：已转回分账方
       /// CLOSED：已关闭
        /// </summary>
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("result")]
        public string Result { get; set; }

        /// <summary> 
        /// 分账完成时间 
        /// </summary> 
        [MinLength(1)]
        [MaxLength(64)]
        [JsonPropertyName("finish_time")]
        public string FinishTime { get; set; }

        /// <summary>
        /// 分账失败原因，枚举值：
        ///ACCOUNT_ABNORMAL：分账接收账户异常
        ///NO_RELATION：分账关系已解除
        ///RECEIVER_HIGH_RISK：高风险接收方
        /// </summary>
        [JsonPropertyName("fail_reason	")]
        public string FailReason { get; set; }


        /// <summary>
        /// 分账接收方类型
        /// 分账接收方类型，枚举值： MERCHANT_ID：商户 PERSONAL_OPENID：个人
        /// </summary>
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("type")]
        public string ReceiverType { get; set; }

        /// <summary>
        /// 分账接收方账号
        /// </summary>
        [MinLength(1)]
        [MaxLength(64)]
        [JsonPropertyName("receiver_account")]
        public string ReceiverAccount { get; set; }

       

       
       
    }
}
