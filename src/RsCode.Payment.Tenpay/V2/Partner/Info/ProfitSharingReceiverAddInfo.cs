﻿/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace RsCode.Payment.Tenpay.V2.Partner
{
    public class ProfitSharingReceiverAddInfo : TenpayDataInfo
    {
        /// <summary>
        /// 分账接收方类型
        /// MERCHANT_ID：商户号（mch_id或者sub_mch_id）
        ///PERSONAL_OPENID：个人openid（由父商户APPID转换得到）PERSONAL_SUB_OPENID: 个人sub_openid（由子商户APPID转换得到）        
        /// </summary>
        [JsonPropertyName("type")]
        [XmlElement("type")]
        public string Type { get; set; }
        /// <summary>
        /// 分账接收方帐号
        /// 类型是MERCHANT_ID时，是商户号（mch_id或者sub_mch_id）
        ///类型是PERSONAL_OPENID时，是个人openid
        ///类型是PERSONAL_SUB_OPENID时，是个人sub_openid
        /// </summary>
        [JsonPropertyName("account")]
        [XmlElement("account")]
        public string Account { get; set; }

        /// <summary>
        /// 可选项，在接收方类型为个人的时可选填，若有值，会检查与 name 是否实名匹配，不匹配会拒绝分账请求
        ///1、分账接收方类型是PERSONAL_OPENID时，是个人姓名（选传，传则校验）
        /// </summary>
        [JsonPropertyName("name")]
        [XmlElement("name")]
        public string Name { get; set; }
        /// <summary>
        /// 与分账方的关系类型
        /// 子商户与接收方的关系。
        ///本字段值为枚举：
///SERVICE_PROVIDER：服务商
///STORE：门店
///STAFF：员工
///STORE_OWNER：店主
///PARTNER：合作伙伴
///HEADQUARTER：总部
///BRAND：品牌方
///DISTRIBUTOR：分销商
///USER：用户
///SUPPLIER：供应商
///CUSTOM：自定义
        /// </summary>
        [JsonPropertyName("relation_type")]
        [XmlElement("relation_type")]
        public string RelationType { get; set; }
        /// <summary>
        /// 自定义的分账关系
        /// 子商户与接收方具体的关系，本字段最多10个字。
        ///当字段relation_type的值为CUSTOM时，本字段必填
        ///当字段relation_type的值不为CUSTOM时，本字段无需填写
        /// </summary>
        [JsonPropertyName("custom_relation")]
        [XmlElement("custom_relation")]
        public string CustomRelation { get; set; }
       
    }
}
