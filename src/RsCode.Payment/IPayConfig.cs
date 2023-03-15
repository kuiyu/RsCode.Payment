/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RsCode.Payment
{
    /// <summary>
    /// 支付配置信息
    /// </summary>
    public interface IPayConfig
    {
        /// <summary>
        /// 获取所有支付参数
        /// </summary>
        /// <returns></returns>
        List<PayOptions> GetPaymentInfo();
        /// <summary>
        /// 移除支付参数
        /// </summary>
        /// <param name="mchId"></param>
        void RemovePaymentInfo(string mchId);
        /// <summary>
        /// 保存支付配置
        /// </summary>
        /// <param name="payOptions"></param>
        /// <param name="oldMchId">原商户号</param>
        void SavePayment(PayOptions payOptions, string oldMchId);
        /// <summary>
        /// 查询商户的支付信息
        /// </summary>
        /// <param name="mchId"></param>
        /// <returns></returns>
        PayOptions GetPaymentInfo(string mchId);
        /// <summary>
        /// 获取指定应用的配置信息
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        List<AppOptions> GetAppInfos(string clientId);
        /// <summary>
        /// 获取authkey
        /// </summary>
        /// <returns></returns>
        List<AuthKeyOptions> GetAuthKeyInfo();
        /// <summary>
        /// 获取指定APP的支付渠道客户端信息
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        ClientOptions GetClient(string appId);

        /// <summary>
        /// 获取所有支付渠道客户端信息
        /// </summary>
        /// <returns></returns>
        List<ClientOptions> GetClient();

 


       
        /// <summary>
        /// 保存APP设置
        /// </summary>
        /// <param name="appOptions"></param>
        void SaveAppClient(AppOptions appOptions);
        /// <summary>
        /// 移除指定clientId配置信息
        /// </summary>
        /// <param name="clientId"></param>
        void RemoveAppInfo(string clientId);
        /// <summary>
        /// 移除指定clientId指定商户号配置信息
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="paymentScene"></param>
        /// <param name="mchId"></param>
        void RemoveAppClient(string clientId, PaymentScene paymentScene, string mchId);
        /// <summary>
        /// 获取Authkey
        /// </summary>
        /// <returns></returns>
        Task<List<AuthKeyOptions>> GetAuthKeyAsync();

        /// <summary>
        /// 保存AuthKey
        /// </summary>
        /// <param name="option"></param>
        Task SaveAuthKeyAsync(AuthKeyOptions option);
        /// <summary>
        /// 删除Authkey
        /// </summary>
        /// <param name="authkeyId">authkey id</param>
        Task RemoveAuthKey(string authkeyId);



        /// <summary>
        /// 更换原管理员密码
        /// </summary>
        /// <param name="newPassword"></param>
        void ChangeAdminPassword(string newPassword);
    }
}
