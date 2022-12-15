/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.ECommerce.ESubsidies
{
    public class SubsidiesCreateResponse
    {
        /// <summary>
        /// 补差的电商平台二级商户
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("sub_mchid")]
        public string SubMchId { get; set; }

        /// <summary>
        /// 微信订单号
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(64)]
        [JsonPropertyName("transaction_id")]
        public string TransactionId { get; set; }

        /// <summary>
        /// 微信补差单号
        /// </summary> 
        [MinLength(1)]
        [MaxLength(64)]
        [JsonPropertyName("subsidy_id")]
        public string SubsidyId { get; set; }

        /// <summary>
        /// 取消补差描述
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(80)]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// 补差金额，单位为分，只能为整数
        /// </summary>
        [Required]
        [JsonPropertyName("amount")]
        public int Amount { get; set; }

      
        /// <summary>
        /// 补差回退结果，枚举值：  SUCCESS：成功  FAIL：失败
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(16)]
        [JsonPropertyName("result")]
        public string Result { get; set; }

        /// <summary>
        /// 补差回退完成时间
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("success_time")]
        public string SuccessTime { get; set; }

    }
}
