using RsCode.Payment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rswl.Payment.Alipay
{
    /// <summary>
    /// 支付宝商家信息
    /// </summary>
    public class AlipayOptions : IPayOptions
    {
        /// <summary>
        /// 合作伙伴身份Id
        /// </summary> 
        public string MchId { get; set; }
        /// <summary>
        /// 合作伙伴Md5密钥
        /// </summary>
        public string Md5Key { get; set; }
        /// <summary>
        /// RSA(SHA1)密钥
        /// </summary>
        public string RSAKey { get; set; }

        /// <summary>
        /// DSA密钥
        /// </summary>
        public string DSAKey { get; set; }
        /// <summary>
        /// 商户类型
        /// </summary>
        public MchType MchType { get; set; }
        
    }
   
}
