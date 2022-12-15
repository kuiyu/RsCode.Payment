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
    /// <summary>
    /// 【商户】现金红包发送接口
    /// 新申请商户号使用现金红包需要满足两个条件：1、入驻时间超过90天 2、连续正常交易30天。 
    /// https://pay.weixin.qq.com/wiki/doc/api/tools/cash_coupon.php?chapter=13_4&index=3
    /// </summary>
    public class RedpacketSendRequest :WxPayData, TenpayBaseRequest
    {
        public RedpacketSendRequest()
        {

        }
        /// <summary>
        /// 发送红包
        /// </summary>
        /// <param name="mchOrderNo">商户订单号</param>
        /// <param name="mchId">商户号</param>
        /// <param name="sendName">商户名称</param>
        /// <param name="wxAppId">公众账号appid</param>
        /// <param name="openId">用户openid</param>
        /// <param name="wishing">红包祝福语</param>
        /// <param name="actName">活动名称</param>
        /// <param name="remark">备注</param>
        /// <param name="totalAmount">付款金额</param>
        /// <param name="sceneId">发放红包使用场景，红包金额大于200或者小于1元时必传
        /// PRODUCT_1:商品促销 PRODUCT_2:抽奖 PRODUCT_3:虚拟物品兑奖 PRODUCT_4:企业内部福利  
        /// PRODUCT_5:渠道分润 PRODUCT_6:保险回馈  PRODUCT_7:彩票派奖  PRODUCT_8:税务刮奖
        ///</param>
        /// <param name="num">红包发放总人数</param>
        public RedpacketSendRequest(string mchOrderNo,string mchId,string sendName,string wxAppId,string openId,string wishing,string actName,string remark,decimal totalAmount,string sceneId,int num=1,string ip="0.0.0.0")
        {
            MchBillNo = mchOrderNo;
            MchId = mchId;
            AppId = wxAppId;
            SendName = sendName;
            OpenId = openId;
            TotalAmount =TenpayTool.Price( totalAmount);
            Wishing = wishing;
            ActiveName = actName;
            SceneId = sceneId;
            Remark = remark;
            ClientIp = ip;
            TotalNum = num;
        }
        #region 参数
        /// <summary>
        /// 随机字符串
        /// </summary>
        [JsonPropertyName("nonce_str")]
        public string NonceStr { get { return TenpayTool.GetNonceStr(); } }
        /// <summary>
        /// 签名
        /// </summary>
        [JsonPropertyName("sign")]
        public string Sign { get; set; }
        /// <summary>
        /// 商户订单号
        /// </summary>
        [JsonPropertyName("mch_billno")] public string MchBillNo { get; set; }
        /// <summary>
        /// 商户号
        /// </summary>
        [JsonPropertyName("mch_id")] public string MchId { get; set; }
        /// <summary>
        /// 公众账号appid
        /// 在微信开放平台（open.weixin.qq.com）申请的移动应用appid无法使用该接口。
        /// </summary>
        [JsonPropertyName("wxappid")] public string AppId { get; set; }
        /// <summary>
        /// 红包发送者名称
        /// </summary>
        [JsonPropertyName("send_name")] public string SendName { get; set; }
        /// <summary>
        /// 接受红包的用户openid
        /// </summary>
        [JsonPropertyName("re_openid")] public string OpenId { get; set; }
        /// <summary>
        /// 付款金额，单位分
        /// </summary>
        [JsonPropertyName("total_amount")] public int TotalAmount { get; set; }
        /// <summary>
        /// 红包发放总人数
        /// </summary>
        [JsonPropertyName("total_num")] public int TotalNum { get; set; }
        /// <summary>
        /// 红包祝福语
        /// </summary>
        [JsonPropertyName("wishing")] public string Wishing { get; set; }
        /// <summary>
        /// 调用接口的机器Ip地址
        /// </summary>

        [JsonPropertyName("client_ip")]
        public string ClientIp { get; set; } 
        /// <summary>
        /// 活动名称
        /// 注意：敏感词会被转义成字符*
        /// </summary>
        [JsonPropertyName("act_name")]
        public string ActiveName { get; set; }
        /// <summary>
        /// 备注信息
        /// </summary>
        [JsonPropertyName("remark")]
        public string Remark { get; set; }
        /// <summary>
        /// 发放红包使用场景，红包金额大于200或者小于1元时必传
        /// PRODUCT_1:商品促销
        ////PRODUCT_2:抽奖
        ///PRODUCT_3:虚拟物品兑奖
        ///PRODUCT_4:企业内部福利
        ///PRODUCT_5:渠道分润
        ///PRODUCT_6:保险回馈
        ///PRODUCT_7:彩票派奖
        ///PRODUCT_8:税务刮奖
        /// </summary>
        [JsonPropertyName("scene_id")] public string SceneId { get; set; }
        /// <summary>
        /// 活动信息
        /// posttime:用户操作的时间戳
        /// mobile:业务系统账号的手机号，国家代码-手机号。不需要+号
        ///deviceid :mac 地址或者设备唯一标识
        ///clientversion :用户操作的客户端版本
        ///把值为非空的信息用key = value进行拼接，再进行urlencode
        ///urlencode(posttime= xx & mobile = xx & deviceid = xx)
        /// </summary>
        [JsonPropertyName("risk_info")] public string RiskInfo { get; set; }


        #endregion



        public override string GetSignType()
        {
            return "MD5";
        }
        public string GetApiUrl()
        {
            string url = "https://api.mch.weixin.qq.com/mmpaymkttransfers/sendredpack";
            return url;
        }
        public string RequestMethod()
        {
            return "POST";
        }
    }
}
