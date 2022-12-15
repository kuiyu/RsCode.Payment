/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.ECommerce.Withdraw
{
    public class DownWithdrawExceptionFileResponse
    {

        /// <summary>
        /// 哈希类型
        /// 从download_url下载的文件的哈希类型，用于校验文件的完整性。
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("hash_type")]
        public string HashType { get; set; }

        /// <summary>
        /// 哈希值 
        /// 从download_url下载的文件的哈希值，用于校验文件的完整性。
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(1024)]
        [JsonPropertyName("hash_value")]
        public string HashValue { get; set; }

        /// <summary>
        /// 账单下载地址 
        /// 供下一步请求账单文件的下载地址，该地址30s内有效。
        /// </summary> 
        [MinLength(1)]
        [MaxLength(2048)]
        [JsonPropertyName("download_url")]
        public string DownloadUrl { get; set; }

         
    }
}
