namespace RsCode.Payment.Tenpay.V3
{
    /// <summary>
    /// 获取平台证书列表
    /// 官方文档<see cref="https://wechatpay-api.gitbook.io/wechatpay-api-v3/jie-kou-wen-dang/ping-tai-zheng-shu"/>
    /// </summary>
    public class CertificatiesDownloadRequest : TenpayBaseRequest
    {
        public string GetApiUrl()
        {
            return "https://api.mch.weixin.qq.com/v3/certificates";
        }

        public string RequestMethod()
        {
            return "GET";
        }
    }
}
