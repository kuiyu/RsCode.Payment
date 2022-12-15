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
    public class DownWithdrawExceptionFileRequest
    {
        /// <summary>
        /// 账单类型 NO_SUCC：提现异常账单，包括提现失败和提现退票账单。
        /// </summary>
        [MinLength(1)] 
        [MaxLength(8)]
        [JsonPropertyName("bill_type")]
        public string BillType { get; set; }

        /// <summary>
        /// 账单日期
        /// </summary>
        [MinLength(1)]
        [MaxLength(10)]
        [JsonPropertyName("bill_date")]
        public string BillDate { get; set; }

        /// <summary>
        /// 压缩格式
        /// </summary>
        [MinLength(1)]
        [MaxLength(10)]
        [JsonPropertyName("tar_type")]
        public string TarType { get; set; } = "GZIP";
    }
}
