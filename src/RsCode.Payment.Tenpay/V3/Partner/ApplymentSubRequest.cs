using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Partner
{
    /// <summary>
    /// 提交申请单API
    /// 普通服务商（银行、支付机构、电商平台不可用）使用该接口提交商家资料，帮助商家入驻成为微信支付的特约商户。
    /// 官方文档 https://pay.weixin.qq.com/wiki/doc/apiv3/wxpay/tool/applyment4sub/chapter3_1.shtml
    /// </summary>
    public class ApplymentSubRequest:TenpayBaseRequest
    {
        /// <summary>
        /// 业务申请编号
        /// </summary>
        [JsonPropertyName("business_code")]
        public string BusinessCode { get; set; }

        /// <summary>
        /// 超级管理员信息
        /// </summary>
        [JsonPropertyName("contact_info")]
        public ContactInfo ContactInfo { get; set; }
        /// <summary>
        /// 主体资料
        /// </summary>
        [JsonPropertyName("subject_info")]
        public SubjectInfo SubjectInfo { get; set; }
        /// <summary>
        /// 经营资料
        /// </summary>
        [JsonPropertyName("business_info")]
        public BusinessInfo BusinessInfo { get; set; }
        /// <summary>
        /// 结算规则
        /// </summary>
        [JsonPropertyName("settlement_info")]
        public SettlementInfo SettlementInfo { get; set; }

        /// <summary>
        /// 结算银行账户
        /// </summary>
        [JsonPropertyName("bank_account_info")]
        public BankAccountInfo BankAccountInfo { get; set; }
        /// <summary>
        /// 补充材料
        /// </summary>
        [JsonPropertyName("addition_info")]
        public AdditionInfo AdditionInfo { get; set; }

        private bool IsEncrypt { get; set; } = false;
        /// <summary>
        /// 对必要的业务参数进行加密
        /// </summary>
        /// <param name="publicKey">微信平台证书公钥</param>
        public void Encrypt(byte[]publicKey)
        {
            if(!IsEncrypt)
            {
                ////加密必要的字段
                ContactInfo.ContactName = TenpayTool.RSAEncrypt(ContactInfo.ContactName, publicKey);
                if (!string.IsNullOrWhiteSpace(ContactInfo.ContactIdCardNumber))
                    ContactInfo.ContactIdCardNumber = TenpayTool.RSAEncrypt(ContactInfo.ContactIdCardNumber, publicKey);

                if (!string.IsNullOrWhiteSpace(ContactInfo.OpenId))
                {
                    ContactInfo.OpenId = TenpayTool.RSAEncrypt(ContactInfo.OpenId, publicKey);
                }
                ContactInfo.MobilePhone = TenpayTool.RSAEncrypt(ContactInfo.MobilePhone, publicKey);
                ContactInfo.Email = TenpayTool.RSAEncrypt(ContactInfo.Email, publicKey);

                if (BankAccountInfo != null)
                {
                    BankAccountInfo.AccountName = TenpayTool.RSAEncrypt(BankAccountInfo.AccountName, publicKey);
                    BankAccountInfo.AccountNumber = TenpayTool.RSAEncrypt(BankAccountInfo.AccountNumber, publicKey);
                }

                if (SubjectInfo.IdentityInfo.CardInfo != null)
                {
                    SubjectInfo.IdentityInfo.CardInfo.IdCardName = TenpayTool.RSAEncrypt(SubjectInfo.IdentityInfo.CardInfo.IdCardName, publicKey);
                    SubjectInfo.IdentityInfo.CardInfo.IdCardNumber = TenpayTool.RSAEncrypt(SubjectInfo.IdentityInfo.CardInfo.IdCardNumber, publicKey);
                }
                if (SubjectInfo.IdentityInfo.IdDocInfo != null)
                {
                    SubjectInfo.IdentityInfo.IdDocInfo.IdDocName = TenpayTool.RSAEncrypt(SubjectInfo.IdentityInfo.IdDocInfo.IdDocName, publicKey);
                    SubjectInfo.IdentityInfo.IdDocInfo.IdDocNumber = TenpayTool.RSAEncrypt(SubjectInfo.IdentityInfo.IdDocInfo.IdDocNumber, publicKey);
                }

                if (SubjectInfo.UboInfo != null)
                {
                    SubjectInfo.UboInfo.Name = TenpayTool.RSAEncrypt(SubjectInfo.UboInfo.Name, publicKey);
                    SubjectInfo.UboInfo.IdNumber = TenpayTool.RSAEncrypt(SubjectInfo.UboInfo.IdNumber, publicKey);
                }
                IsEncrypt = true;
            }
           
        }
        public string GetApiUrl()
        {
            return "https://api.mch.weixin.qq.com/v3/applyment4sub/applyment/";
        }
        public string RequestMethod()
        {
            return "POST";
        }
    }
}
