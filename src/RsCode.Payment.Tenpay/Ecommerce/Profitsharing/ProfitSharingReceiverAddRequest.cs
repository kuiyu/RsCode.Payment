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
     * 1. 电商平台可通过此接口添加分账接收方，建立分账接收方列表。后续通过发起分账请求，将电商平台下的二级商户结算后的资金，分给分账接收方列表中具体的分账接收方。
       2. 添加的分账接收方统一都在电商平台维度进行管理，其他二级商户，均可向该分账接收方列表中的接收方进行分账，避免在二级商户维度重复维护。
     */
    /// <summary>
    /// 添加分账接收方
    /// </summary>
    public class ProfitSharingReceiverAddRequest
    {
        /// <summary>
        /// 公众账号ID
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("appid")]
        public string AppId { get; set; }

        /// <summary>
        /// 接收方类型
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("type")]
        public string ReceiverType { get; set; }


        /// <summary>
        /// 接收方账号
        /// </summary> 
        [MinLength(1)]
        [MaxLength(64)]
        [JsonPropertyName("account")]
        public string Account { get; set; }

        /// <summary>
        /// 接收方名称	
        /// </summary> 
        [MinLength(1)]
        [MaxLength(256)]
        [JsonPropertyName("name")]
        public string Name { get; set; }




        /// <summary> 
        /// 接收方名称的密文
        /// </summary> 
        [MinLength(1)]
        [MaxLength(10240)]
        [JsonPropertyName("encrypted_name")]
        public string EncryptedName { get; set; }



        /// <summary>
        /// 与分账方的关系类型
        /// 子商户与接收方的关系。
        ///枚举值：
        ///SUPPLIER：供应商
        ///DISTRIBUTOR：分销商
        ///SERVICE_PROVIDER：服务商
        ///PLATFORM：平台
        ///OTHERS：其他
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("relation_type")]
        public string RelationType { get; set; }
    }
}
