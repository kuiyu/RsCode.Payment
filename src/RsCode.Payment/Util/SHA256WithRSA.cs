using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace RsCode.Payment.Util
{
    public class SHA256WithRSA 
    {


        public static string RSASignContent(string data, string privateKey, string signType="RSA2")
        {
            var key = RSAUtilities.GetRSAParametersFormRsaPrivateKey(privateKey);
            switch (signType)
            {
                case "RSA2":
                    return SHA256WithRSA.Sign(data, key);
                default:
                    return SHA1WithRSA.Sign(data, key);
            }
        }
        public static string Sign(string data, RSAParameters privateKey)
        {
            if (string.IsNullOrEmpty(data))
            {
                throw new ArgumentNullException(nameof(data));
            }

            using (var rsa = RSA.Create())
            {
                rsa.ImportParameters(privateKey);
                return Convert.ToBase64String(rsa.SignData(Encoding.UTF8.GetBytes(data), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1));
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
                return rsa.VerifyData(Encoding.UTF8.GetBytes(data), Convert.FromBase64String(sign), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            }
        }

        public static string SignData(string data, ICipherParameters key)
        {
            if (string.IsNullOrEmpty(data))
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            var signer = SignerUtilities.GetSigner("SHA256WithRSA");
            signer.Init(true, key);
            var bytes = Encoding.UTF8.GetBytes(data);
            signer.BlockUpdate(bytes, 0, bytes.Length);
            return Convert.ToBase64String(signer.GenerateSignature());
        }

        public static bool VerifyData(string data, string sign, ICipherParameters key)
        {
            if (string.IsNullOrEmpty(data))
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (string.IsNullOrEmpty(sign))
            {
                throw new ArgumentNullException(nameof(sign));
            }

            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            var verifier = SignerUtilities.GetSigner("SHA256WithRSA");
            verifier.Init(false, key);
            var bytes = Encoding.UTF8.GetBytes(data);
            verifier.BlockUpdate(bytes, 0, bytes.Length);
            return verifier.VerifySignature(Convert.FromBase64String(sign));
        }
    }
}
