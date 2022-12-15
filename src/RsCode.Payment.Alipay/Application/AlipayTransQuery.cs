using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rswl.Payment.Alipay.Application
{
    public class AlipayTransQuery
    {
        [Display(Name = "product_code")]
        public string ProductCode { get; set; }

        [Display(Name = "biz_scene")]
        public string BizScene { get; set; }

        [Display(Name = "out_biz_no")]
        public string OutBizNo { get; set; }

        [Display(Name = "order_id")]
        public string OrderId { get; set; }

        [Display(Name = "pay_fund_order_id")]
        public string PayFundOrderId { get; set; }
    }
}
