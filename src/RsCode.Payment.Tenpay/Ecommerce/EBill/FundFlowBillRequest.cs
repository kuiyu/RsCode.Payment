/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.ECommerce.EBill
{
    /// <summary>
    /// 下载账单
    /// </summary>
    public class FundFlowBillRequest
    {
        /// <summary>
        /// 账单日期
        /// </summary>
        [Required]
        [MinLength(1)]
        [MaxLength(10)]
        [JsonPropertyName("bill_date")]
        public string BillDate { get; set; }



        /// <summary>
        /// 资金账户类型	
        /// </summary>
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("account_type")]
        public string AccountType { get; set; }



        /// <summary>
        /// 压缩格式
        /// </summary>
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("tar_type")]
        public string TarType { get; set; }
    }
}
