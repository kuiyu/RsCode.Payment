using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.ECommerce.Profitsharing
{
    /// <summary>
    /// 分账通知中接收方信息
    /// </summary>
    public class ProfitSharingNotifyReceiveData
    {
        /// <summary>
        /// 分账接收方的类型，枚举值：
        ///MERCHANT_ID：商户
        ///PERSONAL_OPENID：个人
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
        /// <summary>
        /// 分账接收方的账号
        ///类型是MERCHANT_ID时，是商户号
        ///类型是PERSONAL_OPENID时，是个人openid
        /// </summary>
        [JsonPropertyName("account")]
        public string Account { get; set; }
        /// <summary>
        /// 分账动账金额，单位为分，只能为整数。
        /// </summary>
        [JsonPropertyName("amount")]
        public int Amount { get; set; }
        /// <summary>
        /// 分账/回退描述
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        
    }
}
