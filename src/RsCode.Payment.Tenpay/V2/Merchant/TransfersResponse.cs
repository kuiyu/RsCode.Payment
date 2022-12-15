﻿/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V2.Merchant
{
    public class TransfersResponse:TenpayBaseResponse
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
        /// 商户appid
        /// </summary>
        [JsonPropertyName("mch_appid")]
        public string MchAppId { get; set; }

        /// <summary>
        /// 设备号
        /// </summary>
        [JsonPropertyName("device_info")]
        public string DeviceInfo { get; set; }

        /// <summary>
        /// 随机字符串
        /// </summary>
        [JsonPropertyName("nonce_str")]
        public string NonceStr { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        [JsonPropertyName("partner_trade_no")]
        public string PartnerTradeNo { get; set; }

        /// <summary>
        /// 微信付款单号
        /// </summary>
        [JsonPropertyName("payment_no")]
        public string PaymentNo { get; set; }

        /// <summary>
        /// 付款成功时间
        /// </summary>
        [JsonPropertyName("payment_time")]
        public string PaymentTime { get; set; }
    }
}
