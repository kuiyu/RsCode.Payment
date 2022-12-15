/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.ECommerce.ERefunds
{
   public class RefundsQueryResponse
    {
        /// <summary>
        /// 微信退款单号
        /// </summary> 
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("refund_id")]
        public string RefundId { get; set; }

        /// <summary>
        /// 商户退款单号
        /// 商户系统内部的退款单号，商户系统内部唯一
        /// </summary> 
        [MinLength(1)]
        [MaxLength(64)]
        [JsonPropertyName("out_refund_no")]
        public string OutRefundNo { get; set; }


        /// <summary>
        ///  微信支付交易订单号
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("transaction_id")]
        public string TransactionId { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary> 
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("out_order_no")]
        public string OutOrderNo { get; set; }

        /// <summary>
        /// 退款渠道
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(16)]
        [JsonPropertyName("channel")]
        public string Channel { get; set; }

        /// <summary>
        /// 退款入账账户
        /// 取当前退款单的退款入账方。
        ///退回银行卡：{银行名称}{卡类型}{卡尾号}
///退回支付用户零钱：支付用户零钱
///退还商户：商户基本账户、商户结算银行账户
///退回支付用户零钱通：支付用户零钱通
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(64)]
        [JsonPropertyName("user_received_account")]
        public string UserReceivedAccount { get; set; }
         
        /// <summary>
        /// 退款成功时间
        /// </summary> 
        [MinLength(1)]
        [MaxLength(64)]
        [JsonPropertyName("success_time")]
        public string SuccessTime { get; set; }

        /// <summary>
        /// 退款创建时间
        /// </summary>
        [JsonPropertyName("create_time")]
        public string CreateTime { get; set; }

        /// <summary>
        /// 退款状态
        /// 枚举值：
        ///SUCCESS：退款成功
        ///REFUNDCLOSE：退款关闭
        ///PROCESSING：退款处理中
        ///ABNORMAL：退款异常，退款到银行发现用户的卡作废或者冻结了，导致原路退款银行卡失败，可前往【服务商平台—>交易中心】，手动处理此笔退款
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// 订单退款金额信息
        /// </summary>
        [JsonPropertyName("amount")]
        public OrderRefundAmountInfo Amount { get; set; }

        /// <summary>
        /// 优惠退款信息
        /// </summary>
        [JsonPropertyName("promotion_detail")]
        public PromotionDetailInfo promotionDetailInfo { get; set; }
    }
}
