using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V2.Partner
{
    /// <summary>
    /// 服务商分账接收方
    /// </summary>
    public class ProfitSharingReceiverInfo : TenpayDataInfo
    {
        /// <summary>
        /// 分账接收方类型
        /// MERCHANT_ID：商户号（mch_id或者sub_mch_id）
        ///PERSONAL_OPENID：个人openid（由父商户APPID转换得到）PERSONAL_SUB_OPENID: 个人sub_openid（由子商户APPID转换得到）        
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
        /// <summary>
        /// 分账接收方帐号
        /// 类型是MERCHANT_ID时，是商户号（mch_id或者sub_mch_id）
        ///类型是PERSONAL_OPENID时，是个人openid
        ///类型是PERSONAL_SUB_OPENID时，是个人sub_openid
        /// </summary>
        [JsonPropertyName("account")]
        public string Account { get; set; }
        /// <summary>
        /// 分账金额，单位为分，只能为整数，不能超过原订单支付金额及最大分账比例金额
        /// </summary>
        [JsonPropertyName("amount")]
        public int Amount { get; set; }
        /// <summary>
        /// 分账的原因描述，分账账单中需要体现
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }
        /// <summary>
        /// 可选项，在接收方类型为个人的时可选填，若有值，会检查与 name 是否实名匹配，不匹配会拒绝分账请求
        ///1、分账接收方类型是PERSONAL_OPENID时，是个人姓名（选传，传则校验）
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
