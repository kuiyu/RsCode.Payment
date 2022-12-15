/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace RsCode.Payment.Tenpay.ECommerce.EBill
{
    /*
     * 微信支付按天提供交易账单文件，商户可以通过该接口获取账单文件的下载地址。文件内包含交易相关的金额、时间、营销等信息，供商户核对订单、退款、银行到账等情况。


注意：
• 微信侧未成功下单的交易不会出现在对账单中。支付成功后撤销的交易会出现在对账单中，跟原支付单订单号一致；

• 对账单中涉及金额的字段单位为“元”；

• 对账单接口只能下载三个月以内的账单。

• 小微商户不单独提供对账单下载，如有需要，可在调取“下载对账单”API接口时不传sub_mch_id，获取服务商下全量电商二级商户（包括小微商户和非小微商户）的对账单。
     */
   public class TradeBillRequest
    {
        /// <summary>
        /// 账单日期
        /// </summary>
         [Required][MinLength(1)]
        [MaxLength(10)]
        [JsonPropertyName("bill_date")]
        public string BillDate { get; set; }

        /// <summary>
        /// 电商平台二级商户号
        /// 1、若商户是直连商户：无需填写该字段。
///2、若商户是服务商：
///● 不填则默认返回服务商下的交易或退款数据。
///● 如需下载某个子商户下的交易或退款数据，则该字段必填。
///特殊规则：最小字符长度为8
///注意：仅适用于电商平台 服务商
        /// </summary> 
        [MinLength(1)]
        [MaxLength(12)]
        [JsonPropertyName("sub_mchid")]
        public string SubMchId { get; set; }

        /// <summary>
        /// 账单类型 NO_SUCC：提现异常账单，包括提现失败和提现退票账单。
        /// </summary>
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("bill_type")]
        public string BillType { get; set; }



        /// <summary>
        /// 压缩格式
        /// </summary>
        [MinLength(1)]
        [MaxLength(32)]
        [JsonPropertyName("tar_type")]
        public string TarType { get; set; }
    }
}
