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
    public class PayBankQueryResponse:TenpayBaseResponse
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
        /// 微信企业付款单号
        /// </summary>
        [JsonPropertyName("payment_no")]
        public string PaymentNo { get; set; }

        /// <summary>
        /// 银行卡号
        /// 收款用户银行卡号(MD5加密)
        /// </summary>
        [JsonPropertyName("bank_no_md5")]
        public string BankNoMd5 { get; set; }

        /// <summary>
        /// 用户真实姓名
        /// </summary>
        [JsonPropertyName("true_name_md5")]
        public string TrueNameMd5 { get; set; }

        /// <summary>
        /// 代付订单金额RMB：分
        /// </summary>
        [JsonPropertyName("amount")]
        public int Amount { get; set; }


        /// <summary>
        /// 代付单状态
        /// 代付订单状态：
        ///PROCESSING（处理中，如有明确失败，则返回额外失败原因；否则没有错误原因）
///SUCCESS（付款成功）
///FAILED（付款失败,需要替换付款单号重新发起付款）
///BANK_FAIL（银行退票，订单状态由付款成功流转至退票,退票时付款金额和手续费会自动退还）
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// 手续费金额
        /// </summary>
        [JsonPropertyName("cmms_amt")]
        public int CmmsAmt { get; set; }

        /// <summary>
        /// 商户下单时间
        /// </summary>
        [JsonPropertyName("create_time")]
        public string CreateTime { get; set; }

        /// <summary>
        /// 成功付款时间
        /// </summary>
        [JsonPropertyName("pay_succ_time")]
        public string PaySuccessTime { get; set; }

        /// <summary>
        /// 失败原因
        /// </summary>
        [JsonPropertyName("reason")] 
        public string Reason { get; set; }
    }
}
