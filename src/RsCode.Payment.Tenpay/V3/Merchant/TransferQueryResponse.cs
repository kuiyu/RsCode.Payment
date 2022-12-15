/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Merchant
{
    public class TransferQueryResponse:TenpayBaseResponse
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
        /// 商户订单号
        /// </summary>
        [JsonPropertyName("partner_trade_no")]
        public string PartnerTradeNo { get; set; }

        /// <summary>
        /// 商户号的appid
        /// </summary>
        [JsonPropertyName("appid")]
        public string AppId { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        [JsonPropertyName("mch_id")]
        public string MchId { get; set; }

        /// <summary>
        /// 付款单号
        /// </summary>
        [JsonPropertyName("detail_id")]
        public string MchAppId { get; set; }

        /// <summary>
        /// 转账状态
        /// </summary>
        [JsonPropertyName("status")]
        public string DeviceInfo { get; set; }

        /// <summary>
        /// 失败原因
        /// </summary>
        [JsonPropertyName("reason")]
        public string Reason { get; set; }

        /// <summary>
        /// 收款用户openid
        /// </summary>
        [JsonPropertyName("openid")]
        public string OpenId { get; set; }

        /// <summary>
        /// 收款用户姓名
        /// </summary>
        [JsonPropertyName("transfer_name")]
        public string TransferName { get; set; }

        /// <summary>
        /// 付款金额
        /// </summary>
        [JsonPropertyName("payment_amount")]
        public int PaymentAmount { get; set; }

        /// <summary>
        /// 转账时间
        /// </summary>
        [JsonPropertyName("transfer_time")]
        public string TransferTime { get; set; }

        /// <summary>
        /// 付款成功时间
        /// </summary>
        [JsonPropertyName("payment_time")]
        public string PaymentTime { get; set; }

        /// <summary>
        /// 企业付款备注
        /// </summary>
        [JsonPropertyName("desc")]
        public string Desc { get; set; }

         
        
    }
}
