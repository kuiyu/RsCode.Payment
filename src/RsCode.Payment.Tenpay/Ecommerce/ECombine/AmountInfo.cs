/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace RsCode.Payment.Tenpay.ECommerce.ECombine
{
    public class AmountInfo
    {
        /// <summary>
        /// 标价金额
        /// 子单金额，单位为分
        /// </summary>
        public int TotalAmount { get; set; }

        /// <summary>
        /// 标价币种
        /// 符合ISO 4217标准的三位字母代码，人民币：CNY 
        /// </summary>
        public string Currency { get; set; }
    }
}
