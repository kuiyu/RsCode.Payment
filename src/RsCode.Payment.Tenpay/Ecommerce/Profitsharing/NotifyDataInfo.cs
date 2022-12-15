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
    public class NotifyDataInfo
    {
        /// <summary>
        /// 加密算法类型
        /// 对开启结果数据进行加密的加密算法，目前只支持AEAD_AES_256_GCM
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("algorithm")]
        public string Id { get; set; }


        /// <summary>
        /// 加密前的对象类型
        /// 加密前的对象类型，分账动账通知的类型为profitsharing
        /// </summary> 
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("original_type")]
        public string OriginalType { get; set; }


        /// <summary>
        /// 数据密文
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(1048576)]
        [JsonPropertyName("ciphertext")]
        public string Ciphertext { get; set; }


        /// <summary>
        /// 附加数据
        /// </summary> 
        [MinLength(1)]
        [MaxLength(16)]
        [JsonPropertyName("associated_data")]
        public string AssociatedData { get; set; }


        /// <summary>
        /// 随机串
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(16)]
        [JsonPropertyName("nonce")]
        public string Nonce { get; set; }

 
    }
}
