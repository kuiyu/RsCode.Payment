/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using Microsoft.AspNetCore.Http;
using RsCode.Payment.Tenpay.V3;
using System.Threading.Tasks;

namespace RsCode.Payment.Tenpay
{
    public interface ITenpayClient
    {
        string Ver { get; }
        /// <summary>
        /// 使用商户号
        /// </summary>
        /// <param name="mchId"></param>
        /// <returns></returns>
        PayOptions UseMchId(string mchId);
        /// <summary>
        /// 发送API请求
        /// </summary>
        /// <typeparam name="T">API响应对象TenpayBaseResponse</typeparam>
        /// <param name="request"></param>
        /// <param name="certSerialNo">本次请求使用的证书序列号</param>
        /// <returns></returns>
        Task<T> SendAsync<T>(TenpayBaseRequest request, string certSerialNo = "") where T: TenpayBaseResponse;

        /// <summary>
        /// 获取回调数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="notifyData">微信回调通知数据</param>
        /// <returns>返回对应业务明文结果</returns>
        Task<T> GetNotifyDataAsync<T>(NotifyDataV3 notifyData) where T : NotifyData;
        /// <summary>
        /// 返回回调数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<NotifyDataV3> GetNotifyDataAsync(HttpRequest request);

        string GetIp();
        /// <summary>
        /// 微信平台公钥证书
        /// </summary>
        /// <returns></returns>
        Task<byte[]> GetPublicKeyAsync();
    }
}
