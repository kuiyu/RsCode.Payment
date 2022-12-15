/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V2.Partner
{
    public class ProfitSharingReturnResponse:TenpayBaseResponse
    {
        /// <summary>
        /// SUCCESS/FAIL 此字段是通信标识，非交易标识
        /// </summary>
        [JsonPropertyName("return_code")]
        public string ReturnCode { get; set; }
        /// <summary>
        /// 返回信息，如非空，为错误原因
        /// </summary>
        [JsonPropertyName("err_msg")]
        public string ReturnMsg { get; set; } = "";
        ///// <summary>
        ///// SUCCESS：分账申请接收成功，结果通过分账查询接口查询
        /////FAIL ：提交业务失败
        ///// </summary>
        //[JsonPropertyName("result_code")]
        //public string ResultCode { get; set; }
        /// <summary>
        /// 列表详见错误码列表
        /// </summary>
        [JsonPropertyName("err_code")]
        public string ErrCode { get; set; }
        
        /// <summary>
        ///  调用接口时提供的商户号
        /// </summary>
        [JsonPropertyName("mch_id")]
        public string MchId { get; set; }

        /// <summary>
        /// 微信支付分配的子商户号，即分账的出资商户号。
        /// </summary> 
        [JsonPropertyName("sub_mch_id")]
        public string SubMchId { get; set; }
        /// <summary>
        /// 调用接口提供的公众账号ID
        /// </summary>
        [JsonPropertyName("appid")]
        public string AppId { get; set; }
     

        /// <summary>
        /// 微信返回的随机字符串
        /// </summary>
        [JsonPropertyName("nonce_str")]
        public string NonceStr { get; set; }

        /// <summary>
        /// 微信返回的签名
        /// </summary>
        [JsonPropertyName("sign")]
        public string Sign { get; set; }
        /// <summary>
        /// 微信分账单号
        /// </summary>
        [JsonPropertyName("order_id")]
        public string OrderId { get; set; }
        /// <summary>
        /// 商户分账单号
        /// </summary>
        [JsonPropertyName("out_order_no")]
        public string OutOrderNo { get; set; }
        /// <summary>
        /// 商户回退单号
        /// </summary>
        [JsonPropertyName("out_return_no")]
        public string OutReturnOrderNo { get; set; }

        /// <summary>
        /// 微信回退单号
        /// </summary>
        [JsonPropertyName("return_no")]
        public string ReturnNo { get; set; }

        /// <summary>
        /// 回退方类型
        /// </summary>
        [JsonPropertyName("return_account_type")]
        public string ReturnAccountType { get; set; }

        /// <summary>
        /// 回退方账号
        /// </summary>
        [JsonPropertyName("return_account")]
        public string ReturnAccount { get; set; }

        /// <summary>
        /// 回退金额
        /// </summary>
        [JsonPropertyName("return_amount")]
        public string ReturnAmount { get; set; }

        /// <summary>
        /// 回退描述
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// 回退结果
        /// </summary>
        [JsonPropertyName("result")]
        public string Result { get; set; }
        /// <summary>
        /// 失败原因
        /// </summary>
        [JsonPropertyName("fail_reason")]
        public string FailReason { get; set; }
        /// <summary>
        /// 完成时间
        /// </summary>
        [JsonPropertyName("finish_time")]
        public string FinishTime { get; set; }

    }
}
