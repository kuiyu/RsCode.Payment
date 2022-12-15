using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.ECommerce.ECombine
{
   public  class QueryResponse
    {
        /// <summary>
        /// 合单发起方的appid
        /// </summary>
        [JsonPropertyName("combine_appid")]
        public string CombineAppId { get; set; }

        /// <summary>
        /// 合单发起方商户号
        /// </summary>
        [JsonPropertyName("combine_mchid")]
        public string CombineMchId { get; set; }

        /// <summary>
        /// 合单商户订单号
        /// </summary>
        [JsonPropertyName("combine_out_trade_no")]
        public string CombineOutTradeNo { get; set; }

        /// <summary>
        /// 支付场景信息描述
        /// </summary>
        [JsonPropertyName("scene_info")]
        public SceneInfo SceneInfo { get; set; }

        /// <summary>
        /// 子单信息
        /// </summary>
        [JsonPropertyName("sub_orders")]
        public SubOrderInfo[] SubOrders { get; set; }

        /// <summary>
        /// 支付者
        /// </summary>
        [JsonPropertyName("combine_payer_info")]
        public CombinePayerInfo CombinePayerInfo { get; set; }
    }
}
