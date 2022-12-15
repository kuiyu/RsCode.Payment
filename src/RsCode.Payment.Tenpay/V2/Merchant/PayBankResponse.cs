/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V2.Merchant
{
    public class PayBankResponse:TenpayBaseResponse
    {
        /// <summary>
        /// 返回状态码
        /// 此字段是通信标识，非付款标识
        /// </summary>
        [JsonPropertyName("return_code")]
        public string ReturnCode { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        [JsonPropertyName("return_msg")]
        public string ReturnMsg { get; set; }

        /// <summary>
        /// 业务结果
        /// </summary>
        [JsonPropertyName("result_code")]
        public string ResultCode { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        [JsonPropertyName("err_code")]
        public string ErrCode { get; set; }

        /// <summary>
        /// 错误描述	
        /// </summary>
        [JsonPropertyName("err_code_des")]
        public string ErrCodeDes { get; set; } 

        /// <summary>
        /// 商户号
        /// </summary>
        [JsonPropertyName("mch_id")]
        public string MchId { get; set; }

        /// <summary>
        /// 商户企业付款单号
        /// </summary>
        [JsonPropertyName("partner_trade_no")]
        public string PartnerTradeNo { get; set; }

        /// <summary>
        /// 代付金额
        /// </summary>
        [JsonPropertyName("amount")]
        public int SubMchId { get; set; }

        /// <summary>
        /// 随机字符串
        /// </summary>
        [JsonPropertyName("nonce_str")]
        public string NonceStr { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        [JsonPropertyName("sign")]
        public string Sign { get; set; }
        /// <summary>
        /// 微信企业付款单号
        /// </summary>
        [JsonPropertyName("payment_no")]
        public string PaymentNo { get; set; }
        /// <summary>
        /// 手续费金额 RMB：分
        /// </summary>
        [JsonPropertyName("cmms_amt")]
        public int CmmsAmt { get; set; }
    }
}
