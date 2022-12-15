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
    /*
     * 1、此功能仅针对分账接收方。
2、分账动账金额变动后，微信会把相关变动结果发送给需要实时关注的分账接收方。

注意：
对后台通知交互时，如果微信收到应答不是成功或超时，微信认为通知失败，微信会通过一定的策略定期重新发起通知，尽可能提高通知的成功率，但微信不保证通知最终能成功


• 同样的通知可能会多次发送给商户系统。商户系统必须能够正确处理重复的通知。 推荐的做法是，当商户系统收到通知进行处理时，先检查对应业务数据的状态，并判断该通知是否已经处理。如果未处理，则再进行处理；如果已处理，则直接返回结果成功。在对业务数据进行状态检查和处理之前，要采用数据锁进行并发控制，以避免函数重入造成的数据混乱。

• 如果在所有通知频率(4小时)后没有收到微信侧回调，商户应调用查询订单接口确认订单状态。


特别提醒：商户系统对于开启结果通知的内容一定要做签名验证，并校验通知的信息是否与商户侧的信息一致，防止数据泄漏导致出现“假通知”，造成资金损失。
     */
    public class ProfitSharingNotify
    {

        /// <summary>
        /// 接收方类型
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("id")]
        public string Id { get; set; }


        /// <summary>
        /// 通知创建时间
        /// </summary> 
        [MinLength(1)]
        [MaxLength(16)]
        [JsonPropertyName("create_time")]
        public string CreateTime { get; set; }


        /// <summary>
        /// 通知类型
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("event_type")]
        public string EventType { get; set; }


        /// <summary>
        /// 通知简要说明
        /// </summary> 
        [MinLength(1)]
        [MaxLength(16)]
        [JsonPropertyName("summary")]
        public string Summary { get; set; }


        /// <summary>
        /// 通知数据类型
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("resource_type")]
        public string ResourceType { get; set; }


        /// <summary>
        /// 通知数据
        /// </summary>  
        [JsonPropertyName("resource")]
        public NotifyDataInfo   Resource { get; set; }
    } 
}
