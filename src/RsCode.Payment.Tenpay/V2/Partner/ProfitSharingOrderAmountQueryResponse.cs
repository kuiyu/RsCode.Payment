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
    public class ProfitSharingOrderAmountQueryResponse:TenpayBaseResponse
    {
        /// <summary>
        /// SUCCESS/FAIL 此字段是通信标识，非交易标识
        /// </summary>
        [JsonPropertyName("return_code")]
        public string ReturnCode { get; set; }
        /// <summary>
        /// 如果返回状态码为FAIL，则本字段存在，且为失败的错误信息
        /// </summary>
        [JsonPropertyName("err_msg")]
        public string ReturnMsg { get; set; } = "";
        ///// <summary>
        ///// SUCCESS：分账申请接收成功，结果通过分账查询接口查询
        /////FAIL ：提交业务失败
        ///// </summary>
        //[JsonPropertyName("result_code")]
        //public string ResultCode { get; set; }
        ///// <summary>
        ///// 列表详见错误码列表
        ///// </summary>
        //[JsonPropertyName("err_code")]
        //public string ErrCode { get; set; }
        ///// <summary>
        ///// 结果信息描述
        ///// </summary>
        //[JsonPropertyName("err_code_des")]
        //public string ErrCodeDes { get; set; }
        /// <summary>
        ///  调用接口时提供的服务商户号
        /// </summary>
        [JsonPropertyName("mch_id")]
        public string MchId { get; set; }
        /// <summary>
        /// 微信订单号
        /// </summary>
        [JsonPropertyName("transaction_id")]
        public string TransactionId { get; set; }

        /// <summary>
        /// 订单剩余待分金额，整数，单位为分
        /// </summary> 
        [JsonPropertyName("unsplit_amount")]
        public int UnsplitAmount { get; set; } 
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

       
    }
}
