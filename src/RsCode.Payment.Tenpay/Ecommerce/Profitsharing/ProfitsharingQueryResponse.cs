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
    public class ProfitsharingQueryResponse
    {
        /// <summary>
        /// 分账出资的电商平台二级商户，填写微信支付分配的商户号
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("sub_mchid")]
        public string SubMchId { get; set; }



        /// <summary>
        /// 微信支付订单号
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("transaction_id")]
        public string TransactionId { get; set; }



        /// <summary>
        /// 商户系统内部的分账单号，在商户系统内部唯一（单次分账、多次分账、完结分账应使用不同的商户分账单号），同一分账单号多次请求等同一次。
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(64)]
        [JsonPropertyName("out_order_no")]
        public string OutOrderNo { get; set; }

        /// <summary>
        /// 微信分账单号
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(64)]
        [JsonPropertyName("order_id")]
        public string OrderId { get; set; }

        /// <summary>
        /// 分账单状态，枚举值：
        ///ACCEPTED：受理成功
        ///PROCESSING：处理中
        ///FINISHED：分账成功
        ///CLOSED：处理失败，已关单
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("status")]
        public string Status { get; set; }


        /// <summary>
        /// 分账接收方列表，支持设置出资商户作为分账接收方，单次分账最多可有5个分账接收方
        /// </summary>
        [Required]
        [JsonPropertyName("receivers")]
        public ProfitSharingReceiverInfo[] Receivers { get; set; }

        /// <summary>
        /// 关单原因描述，枚举值：  NO_AUTH：分账授权已解除
        /// </summary> 
        [Required]
        [JsonPropertyName("close_reason")]
        public string CloseReason { get; set; }

        /// <summary>
        /// 分账完结的分账金额，单位为分， 仅当查询分账完结的执行结果时，存在本字段。
        /// </summary>
        [JsonPropertyName("finish_amount")]
        public int FinishAmount { get; set; }

        /// <summary>
        /// 分账完结的原因描述，仅当查询分账完结的执行结果时，存在本字段。
        /// </summary>
        [MinLength(1)]
        [MaxLength(80)]
        [JsonPropertyName("finish_description")]
        public string FinishDescription { get; set; }

    }
}
