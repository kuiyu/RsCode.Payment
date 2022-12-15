/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.ECommerce.ERefunds
{
    public class PromotionDetailInfo
    {
        /// <summary>
        /// 券或者立减优惠id
        /// </summary>
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("promotion_id")]
        public string PromotionId { get; set; }

        /// <summary>
        /// 优惠范围
        /// GLOBAL：全场代金券
        /// SINGLE：单品优惠
        /// </summary>
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("scope")]
        public string Scope { get; set; }

        /// <summary>
        /// 优惠类型
        /// 枚举值：
        /// COUPON：充值型代金券，商户需要预先充值营销经费
        /// DISCOUNT：免充值型优惠券，商户不需要预先充值营销经费
        /// </summary>
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("type")]
        public int PromotionType { get; set; }

        /// <summary>
        /// 优惠券面额
        /// </summary> 
        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// 优惠退款金额
        /// 代金券退款金额<=退款金额，退款金额-代金券或立减优惠退款金额为现金，说明详见《代金券或立减优惠》 。
        /// </summary> 
        [JsonPropertyName("refund_amount")]
        public int RefundAmount { get; set; }
 
    }
}
