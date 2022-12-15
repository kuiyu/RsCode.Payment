using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rswl.Payment.Alipay.Application
{
    public class AlipayTradePay
    {
        [Required]
        [Display(Name = "out_trade_no")]
        public string OutTradeNo { get; set; }

        [Required]
        [Display(Name = "subject")]
        public string Subject { get; set; }

        [Required]
        [Display(Name = "scene")]
        public string Scene { get; set; }

        [Required]
        [Display(Name = "auth_code")]
        public string AuthCode { get; set; }

        [Display(Name = "body")]
        public string Body { get; set; }

        [Required]
        [Display(Name = "total_amount")]
        public string TotalAmount { get; set; }
    }
}
