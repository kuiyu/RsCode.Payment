using System;
using System.Collections.Generic;
using System.Text;

namespace RsCode.Payment.Alipay
{
    public class AlipayTradeData
    {
        public AlipayTradeData(string description,decimal totalFee,string orderNo,string attach)
        {
            Description = description;
            TotalFee = totalFee;
            OrderNo = orderNo;
            Attach = attach;
        }
        /// <summary>
        /// 商品或支付订单简要描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 支付总额
        /// </summary>
        public decimal TotalFee { get; set; }
        /// <summary>
        /// 商户内部订单号
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 附加数据
        /// </summary>
        public string Attach { get; set; }

        //public string NotifyUrl { get; set; } = "/alipay/notify/";
    }
}
