/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3
{
    /// <summary>
    /// 平台证书下载信息
    /// </summary>
    public class CertificatiesDownInfo
    {
        [JsonPropertyName("serial_no")]
        public string SerialNo { get; set; }
        [JsonPropertyName("effective_time")]
        public DateTime EffectiveTime { get; set; }
        [JsonPropertyName("expire_time")]
        public DateTime ExpireTime { get; set; }

        [JsonPropertyName("encrypt_certificate")]
        public CertificateInfo CertificateInfo { get; set; }

    }
    public class CertificateInfo
    {
        /// <summary>
        /// 加密算法
        /// </summary>
        [JsonPropertyName("algorithm")]
        public string Algorithm { get; set; }
        /// <summary>
        /// 加密使用的随机串初始化向量）
        /// </summary>
        [JsonPropertyName("nonce")]
        public string Nonce { get; set; }
        /// <summary>
        /// 附加数据包（可能为空）
        /// </summary>
        [JsonPropertyName("associated_data")]
        public string AssociatedData { get; set; }
        /// <summary>
        /// Base64编码后的密文
        /// </summary>
        [JsonPropertyName("ciphertext")]
        public string CipherText { get; set; }

        private  string ALGORITHM = "AES/GCM/NoPadding";
        private  int TAG_LENGTH_BIT = 128;
        private  int NONCE_LENGTH_BYTE = 12;
        private  string AES_KEY = "your api keyv3";

        /// <summary>
        /// 解密平台证书
        /// 下载到公钥后，解密到publickey后，调用该方法得到publickey
        /// </summary>
        /// <param name="apiKeyV3">商户APIKeyV3</param>
        /// <returns></returns>
        public string Decrypt(string apiKeyV3)
        {
            AES_KEY = apiKeyV3;
            string associatedData = AssociatedData;
            string nonce = Nonce;
            string ciphertext = CipherText;
            return TenpayTool.AesGcmDecrypt(AES_KEY, associatedData, nonce, ciphertext);
        }
    }
}
