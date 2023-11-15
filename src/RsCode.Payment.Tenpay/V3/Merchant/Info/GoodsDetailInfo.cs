/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Merchant
{
    /// <summary>
    /// 单品列表
    /// </summary>
    public class GoodsDetailInfo
    {
        /// <summary>
        ///  商户侧商品编码
        /// </summary>
        [JsonPropertyName("merchant_goods_id")]
        public string MerchantGoodsId { get; set; } = "0";
        /// <summary>
        /// 微信侧商品编码
        /// </summary>
        [JsonPropertyName("wechatpay_goods_id")]
        public string WechatPayGoodsId { get; set; } = "";

        /// <summary>
        ///  商品名称
        /// </summary>
        [JsonPropertyName("goods_name")]
        public string GoodsName { get; set; } = "";


        /// <summary>
        ///  商品数量
        /// </summary>
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; } = 1;

        /// <summary>
        ///  商品单价,单位为分
        /// </summary>
        [JsonPropertyName("unit_price")]
        public int UnitPrice { get; set; }
         
        
        
    }
}
