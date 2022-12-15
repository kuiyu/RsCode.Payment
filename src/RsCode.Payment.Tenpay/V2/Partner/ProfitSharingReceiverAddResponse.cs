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
    public class ProfitSharingReceiverAddResponse:TenpayBaseResponse
    {
        /// <summary>
        /// SUCCESS/FAIL 此字段是通信标识，非交易标识
        /// </summary>
        [JsonPropertyName("return_code")]
        public string ReturnCode { get; set; }
        /// <summary>
        /// 返回信息，如非空，为错误原因
        /// </summary>
        [JsonPropertyName("return_msg")]
        public string ReturnMsg { get; set; } = "";
        /// <summary>
        /// SUCCESS：分账申请接收成功，结果通过分账查询接口查询
        ///FAIL ：提交业务失败
        /// </summary>
        [JsonPropertyName("result_code")]
        public string ResultCode { get; set; }
        /// <summary>
        /// 列表详见错误码列表
        /// </summary>
        [JsonPropertyName("err_code")]
        public string ErrCode { get; set; }
        /// <summary>
        /// 结果信息描述
        /// </summary>
        [JsonPropertyName("err_code_des")]
        public string ErrCodeDes { get; set; }
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
        /// 微信分配的子商户公众账号ID
        /// </summary>
        [JsonPropertyName("sub_appid")]
        public string SubAppId { get; set; }

        /// <summary>
        /// 分账接收方对象（不包含分账接收方全称），json格式。
        /// </summary>
        [JsonPropertyName("receiver")]
        public string Receiver { get; set; }
         

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
