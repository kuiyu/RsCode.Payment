using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V2.Partner
{
    public class RedpacketQueryResponse : TenpayBaseResponse
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
        /// 红包单号
        /// </summary>
        [JsonPropertyName("detail_id")] public string DetailId { get; set; }

        /// <summary>
        /// 红包状态
        /// </summary>
        [JsonPropertyName("status")] public string Status { get; set; }


        /// <summary>
        /// 发放类型
        /// </summary>
        [JsonPropertyName("send_type")] public string SendType { get; set; }

        /// <summary>
        /// 红包类型
        /// </summary>
        [JsonPropertyName("hb_type")] public string HbType { get; set; }

        /// <summary>
        /// 红包个数
        /// </summary>
        [JsonPropertyName("total_num")] public int TotalNum { get; set; }

        /// <summary>
        /// 红包金额
        /// </summary>
        [JsonPropertyName("total_amount")] public int TotalAmount { get; set; }

        /// <summary>
        /// 失败原因
        /// </summary>
        [JsonPropertyName("reason")] public string Reason { get; set; }

        /// <summary>
        /// 红包发送时间
        /// </summary>
        [JsonPropertyName("send_time")] public string SendTime { get; set; }

        /// <summary>
        /// 红包退款时间
        /// </summary>
        [JsonPropertyName("refund_time")] public string RefundTime { get; set; }

        /// <summary>
        /// 红包退款金额
        /// </summary>
        [JsonPropertyName("refund_amount")] public string RefundAmount { get; set; }

        /// <summary>
        /// 祝福语
        /// </summary>
        [JsonPropertyName("wishing")] public string Wishing { get; set; }

        /// <summary>
        /// 活动描述
        /// </summary>
        [JsonPropertyName("remark")] public string Remark { get; set; }

        /// <summary>
        /// 活动名称
        /// </summary>
        [JsonPropertyName("act_name")] public string ActName { get; set; }

        /// <summary>
        /// 裂变红包领取列表
        /// </summary>
        [JsonPropertyName("hblist")] public string HbList { get; set; }


        /// <summary>
        /// 用户openid
        ///领取红包的Openid
        /// </summary>
        [JsonPropertyName("openid")] public string OpenId { get; set; }


        /// <summary>
        /// 金额
        /// </summary>
        [JsonPropertyName("amount")] public int Amount { get; set; }

        /// <summary>
        /// 接收时间
        /// </summary>
        [JsonPropertyName("rcv_time")] public string RcvTime { get; set; }


        #endregion
    }
}
