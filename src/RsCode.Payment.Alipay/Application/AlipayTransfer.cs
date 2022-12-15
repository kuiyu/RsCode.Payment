using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rswl.Payment.Alipay.Application
{
    public class AlipayTransfer
    {
        [Required]
        [Display(Name = "out_biz_no")]
        public string OutBizNo { get; set; }

        [Required]
        [Display(Name = "trans_amount")]
        public string TransAmount { get; set; }

        [Required]
        [Display(Name = "product_code")]
        public string ProductCode { get; set; }

        [Required]
        [Display(Name = "biz_scene")]
        public string BizScene { get; set; }

        [Required]
        [Display(Name = "payee_info_identity")]
        public string PayeeIdentity { get; set; }

        [Required]
        [Display(Name = "payee_info_identity_type")]
        public string PayeeIdentityType { get; set; }

        [Required]
        [Display(Name = "payee_info_name")]
        public string PayeeName { get; set; }

        [Display(Name = "remark")]
        public string Remark { get; set; }
    }
}
