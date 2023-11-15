/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */

using System;
using System.Text;

namespace RsCode.Payment.Util
{
    public class HMACSHA256
    {
        public static string Compute(string data, string key)
        {
            if (string.IsNullOrEmpty(data))
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            using (var hmacSha256 = new System.Security.Cryptography.HMACSHA256(Encoding.UTF8.GetBytes(key)))
            {
                var hsah = hmacSha256.ComputeHash(Encoding.UTF8.GetBytes(data));
                return BitConverter.ToString(hsah).Replace("-", "");
            }
        }

        public static byte[] Compute(byte[] data, byte[] key)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            using (var hmacSha256 = new System.Security.Cryptography.HMACSHA256(key))
            {
                return hmacSha256.ComputeHash(data);
            }
        }
    }
}
