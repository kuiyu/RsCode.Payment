/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V2.Merchant
{
    /// <summary>
    /// 企业付款
    /// 用于企业向微信用户个人付款 目前支持向指定微信用户的openid付款。
    /// https://pay.weixin.qq.com/wiki/doc/api/tools/mch_pay.php?chapter=14_2
    /// </summary>
    public class TransfersRequest: WxPayData, TenpayBaseRequest
    {
        public TransfersRequest()
        {

        }
        public TransfersRequest(string appid,string mchId,string orderNo,string openId,decimal amount,string desc,string checkName= "NO_CHECK")
        {
            AppId = appid;
            MchId = mchId;
            PartnerTradeNo = orderNo;
            OpenId = openId;
            CheckName = checkName;
            Amount = TenpayTool.Price(amount);
            Desc = desc;
        }
        #region 参数
        /// <summary>
        /// 申请商户号的appid或商户号绑定的appid
        /// </summary>
         [JsonPropertyName("mch_appid")] public string AppId { get; set; }
        /// <summary>
        /// 商户号
        /// </summary>
         [JsonPropertyName("mchid")] public string MchId { get; set; }
        /// <summary>
        /// 微信支付分配的终端设备号
        /// </summary>
         [JsonPropertyName("device_info")] public string DeviceInfo { get; set; }
        /// <summary>
        /// 随机字符串
        /// </summary>
        
        [JsonPropertyName("nonce_str")]
        public string NonceStr { get { return TenpayTool. GetNonceStr(); } }
        /// <summary>
        /// 签名
        /// </summary>
        [JsonPropertyName("sign")]
        public string Sign { get; set; }
        /// <summary>
        /// 商户订单号
        /// </summary>
      [JsonPropertyName("partner_trade_no")] public string PartnerTradeNo { get; set; }

        /// <summary> v
        ///商户appid下，某用户的openid
        /// </summary>
        [JsonPropertyName("openid")] public string OpenId { get; set; }
        /// <summary>
        /// 校验用户姓名选项 NO_CHECK：不校验真实姓名 FORCE_CHECK：强校验真实姓名
        /// </summary>
        [JsonPropertyName("check_name")] public string CheckName { get; set; }
        /// <summary>
        /// 收款用户姓名
        /// </summary>
        [JsonPropertyName("re_user_name")] public string ReUserName { get; set; }
        /// <summary>
        /// 企业付款金额，单位为分
        /// </summary>
         [JsonPropertyName("amount")] public int Amount { get; set; }
        /// <summary>
        /// 企业付款备注
        /// </summary>
        [JsonPropertyName("desc")] public string Desc { get; set; }

        /// <summary>
        /// ip
        /// </summary>
        [JsonPropertyName("spbill_create_ip")]
        public string SpbillCreateIp { get; set; } = "127.0.0.1";
        
        #endregion

        public  string GetApiUrl()
        {
            string url = "https://api.mch.weixin.qq.com/mmpaymkttransfers/promotion/transfers";
            return url;
        }
 
        public string RequestMethod()
        {
            return "POST";
        }

        public override string GetSignType()
        {
            return "MD5";
        }
    }
}
