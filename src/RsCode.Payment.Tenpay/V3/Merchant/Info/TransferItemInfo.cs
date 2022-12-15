using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Merchant.Info
{
    /// <summary>
    /// 商家转帐信息
    /// <see cref="https://pay.weixin.qq.com/wiki/doc/apiv3/apis/chapter4_3_1.shtml"/>
    /// </summary>
    public class TransferItemInfo
    {
        public TransferItemInfo()
        {

        }
        public TransferItemInfo(string outDetailNo,decimal transferAmount,string remark,string openId,string userName)
        {
            OutDetailNo = outDetailNo;
            TransferAmount = TenpayTool.Price(transferAmount);
            TransferRemark = remark;
            OpenId = openId;
            UserName = userName;
            
        }
        /// <summary> 
        ///商家明细单号
        ///商户系统内部区分转账批次单下不同转账明细单的唯一标识，要求此参数只能由数字、大小写字母组成
        /// </summary>
        [JsonPropertyName("out_detail_no")] public string OutDetailNo { get; set; }

        /// <summary> 
        ///转账金额
        /// </summary>
        [JsonPropertyName("transfer_amount")] public int TransferAmount { get; set; }

        /// <summary> 
        ///转账备注
        ///单条转账备注（微信用户会收到该备注），UTF8编码，最多允许32个字符
        /// </summary>
        [JsonPropertyName("transfer_remark")] public string TransferRemark { get; set; }

        /// <summary> 
        ///用户在直连商户应用下的用户标示
        ///openid是微信用户在公众号appid下的唯一用户标识（appid不同，则获取到的openid就不同），可用于永久标记一个用户
        /// </summary>
        [JsonPropertyName("openid")] public string OpenId { get; set; }


        /// <summary>
        /// 收款用户姓名	
        /// </summary>
        [JsonPropertyName("user_name")] public string UserName { get; set; }


        public void Encrypt(byte[]publicKey)
        {
            if(string.IsNullOrEmpty(UserName))
            {
                UserName = null;
            }else
            {
                UserName = TenpayTool.RSAEncrypt(UserName, publicKey);
            }
        }
    }
}
