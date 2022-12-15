using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rswl.Payment.Alipay.Application
{
   
    public class AlipayTradePreCreate
    {
        [Required]
        [Display(Name = "out_trade_no")]
        public string OutTradeNo { get; set; }

        [Required]
        [Display(Name = "subject")]
        public string Subject { get; set; }

        [Display(Name = "body")]
        public string Body { get; set; }

        [Required]
        [Display(Name = "total_amount")]
        public string TotalAmount { get; set; }

        [Display(Name = "notify_url")]
        public string NotifyUrl { get; set; }
    }
}
