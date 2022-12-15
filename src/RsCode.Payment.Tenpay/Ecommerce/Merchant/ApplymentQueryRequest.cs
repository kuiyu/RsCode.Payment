using System;
using System.Collections.Generic;
using System.Text;

namespace RsCode.Payment.Tenpay.ECommerce.Merchant
{
    /// <summary>
    /// 查询申请状态
    /// </summary>
    public class ApplymentQueryRequest
    {
        /// <summary>
        /// 微信支付申请单号
        /// </summary>
        public long ApplymentId { get; set; }

        /// <summary>
        /// 业务申请编号
        /// </summary>
        public string OutRequestNo { get; set; }
    }
}
