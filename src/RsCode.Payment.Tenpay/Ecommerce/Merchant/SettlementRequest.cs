using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RsCode.Payment.Tenpay.ECommerce.Merchant
{
    public class SettlementRequest
    {
        /// <summary>
        /// 请输入本服务商进件、已签约的特约商户号
        /// </summary>
        [Required]
        [MinLength(8)]
        [MaxLength(10)]
        public string SubMchId { get; set; }
    }
}
