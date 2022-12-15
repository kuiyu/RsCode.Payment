using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V2.Partner
{
   public class RedpacketSendResponse : TenpayBaseResponse
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
        #region 参数
        /// <summary>
        /// 商户订单号 
        /// </summary>
        [JsonPropertyName("mch_billno")] public string MchBillNo { get; set; }
        /// <summary>
        /// 微信支付分配的商户号
        /// </summary>
        [JsonPropertyName("mch_id")] public string MchId { get; set; }
        /// <summary>
        /// 公众账号appid
        /// </summary>
        [JsonPropertyName("wxappid")] public string WxAppId { get; set; }


        /// <summary>
        /// 用户openid
        /// 接受收红包的用户用户在wxappid下的openid
        /// </summary>
        [JsonPropertyName("re_openid")] public string OpenId { get; set; }


        /// <summary>
        /// 付款金额，单位分 
        /// </summary>
        [JsonPropertyName("total_amount")] public int TotalAmount { get; set; }

        /// <summary>
        /// 红包订单的微信单号
        /// </summary>
        [JsonPropertyName("send_listid")] public string SendListId { get; set; }



        #endregion


    }
}