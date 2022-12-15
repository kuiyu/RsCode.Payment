using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rswl.Payment.Alipay.Application
{
    public class AlipayTradeRefundQuery
    {
        [Display(Name = "out_trade_no")]
        public string OutTradeNo { get; set; }

        [Display(Name = "trade_no")]
        public string TradeNo { get; set; }

        [Display(Name = "out_request_no")]
        public string OutRequestNo { get; set; }
    }
}
