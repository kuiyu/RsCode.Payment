/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */

using System;
using System.Security.Cryptography;
using System.Text;

namespace RsCode.Payment.Util
{
    public class SHA1WithRSA
    {
        public static string Sign(string data, RSAParameters privateKey)
        {
            if (string.IsNullOrEmpty(data))
            {
                throw new ArgumentNullException(nameof(data));
            }

            using (var rsa = RSA.Create())
            {
                rsa.ImportParameters(privateKey);
                return Convert.ToBase64String(rsa.SignData(Encoding.UTF8.GetBytes(data), HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1));
            }
        }

        public static bool Verify(string data, string sign, RSAParameters publicKey)
        {
            if (string.IsNullOrEmpty(data))
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (string.IsNullOrEmpty(sign))
            {
                throw new ArgumentNullException(nameof(sign));
            }

            using (var rsa = RSA.Create())
            {
                rsa.ImportParameters(publicKey);
                return rsa.VerifyData(Encoding.UTF8.GetBytes(data), Convert.FromBase64String(sign), HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);
            }
        }
    }
}
