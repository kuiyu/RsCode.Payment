/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3
{
    /// <summary>
    /// V3版本微信请求的参数
    /// </summary>
    public class NotifyDataV3:NotifyData
    {
        /// <summary>
        /// 通知的唯一ID 
        /// </summary>
        [JsonPropertyName("id")] public string Id { get; set; }
        /// <summary>
        /// 通知创建时间
        /// </summary>
        [JsonPropertyName("create_time")] public string CreateTime { get; set; }
        /// <summary>
        /// 通知的类型，
        ///授权成功通知的类型为 PAYSCORE.USER_OPEN_SERVICE
        ///解除授权成功通知的类型为 PAYSCORE.USER_CLOSE_SERVICE
        ///用户确认成功通知的类型为 PAYSCORE.USER_CONFIRM
        ///支付成功通知的类型为 PAYSCORE.USER_PAID
        /// </summary>
        [JsonPropertyName("event_type")] public string EventType { get; set; }

        /// <summary>
        /// 通知的资源数据类型，授权/解除授权成功通知为encryptresource 
        /// </summary>
        [JsonPropertyName("resource_type")] public string ResourceType { get; set; }

        /// <summary>
        /// 通知数据 json格式
        /// </summary>
        [JsonPropertyName("resource")] public NotifyDataV3Resource Resource { get; set; }

        /// <summary>
        /// 解密后的明文结果
        /// </summary>
        /// <param name="apiKeyV3"></param>
        /// <returns></returns>
        public string GetResult(string apiKeyV3)
        {
            return TenpayTool.AesGcmDecrypt(apiKeyV3, Resource.AssociatedData, Resource.Nonce, Resource.CipherText);
        }
        /// <summary>
        ///  //验签:应答和回调的签名验证使用的是微信支付平台证书，不是商户API证书。使用商户API证书是验证不过的。
        /// </summary>
        /// <param name="apiKeyV3"></param>
        /// <param name="tenpaySign"></param>
        /// <param name="signSourceString"></param>
        /// <returns></returns>
        public bool VerifySign(string apiKeyV3, string tenpaySign, string signSourceString)
        {
            var key = TenpayTool.AesGcmDecrypt(apiKeyV3, Resource.AssociatedData, Resource.Nonce, Resource.CipherText);
            byte[] publicKey = Encoding.UTF8.GetBytes(key);
            return TenpayTool.VerifySign(publicKey, tenpaySign, signSourceString);
        }
    }

    /// <summary>
    /// V3版通知数据
    /// </summary>
    public class NotifyDataV3Resource
    {
        /// <summary>
        /// 对分账结果数据进行加密的加密算法，目前只支持AEAD_AES_256_GCM
        /// </summary>
        [JsonPropertyName("algorithm")] public string Algorithm { get; set; }
        /// <summary>
        /// 加密前的对象类型，分账动账通知的类型为profitsharing
        /// </summary>
        [JsonPropertyName("original_type")] public string OriginalType { get; set; }
        /// <summary>
        /// Base64编码后的分账结果数据密文
        /// </summary>
        [JsonPropertyName("ciphertext")] public string CipherText { get; set; }

        /// <summary>
        /// 附加数据
        /// </summary>
        [JsonPropertyName("associated_data")] public string AssociatedData { get; set; }

        /// <summary>
        /// 加密使用的随机串
        /// </summary>
        [JsonPropertyName("nonce")] public string Nonce { get; set; }

        
    }
}
