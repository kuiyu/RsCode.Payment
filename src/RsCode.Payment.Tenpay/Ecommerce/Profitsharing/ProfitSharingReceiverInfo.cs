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
    /// 分账接收方
    /// </summary>
    public class ProfitSharingReceiverInfo
    {
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
        /// 是否完成分账
        ///1、如果为true，该笔订单剩余未分账的金额会解冻回电商平台二级商户；
        ///2、如果为false，该笔订单剩余未分账的金额不会解冻回电商平台二级商户，可以对该笔订单再次进行分账。
        /// </summary> 
        [JsonPropertyName("receiver_name")]
        public string ReceiverName { get; set; }

      
    }
}
