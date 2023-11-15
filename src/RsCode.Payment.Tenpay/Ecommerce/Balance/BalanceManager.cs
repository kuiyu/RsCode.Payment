/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using RsCode.Payment.Tenpay.ECommerce.Balance;
using RsCode.Payment.Tenpay.V3;
using System.Threading.Tasks;

namespace RsCode.Payment.Tenpay.ECommerce
{
    /// <summary>
    /// 余额查询API 
    /// </summary>
    public class BalanceManager
    {
        ITenpayClient tenpayClient;
         public BalanceManager(ITenpayClient _tenpayClient)
        {
            tenpayClient = _tenpayClient;
        }
        ///// <summary>
        ///// 查询二级商户账户实时余额
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //public async Task<EcommerceBalanceResponse> FundBalance(EcommerceBalanceRequest request)
        //{
        //    string url = $"https://api.mch.weixin.qq.com/v3/ecommerce/fund/balance/{request.SubMchId}";
        //    return await tenpayClient.GetAsync<EcommerceBalanceResponse>(url);
        //}

        ///// <summary>
        ///// 查询二级商户账户日终余额(可查询90天内的日终余额)
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //public async Task<EcommerceEndDayBalanceResponse> FundEndDayBalance(EcommerceEndDayBalanceRequest request)
        //{
        //    string url = $"https://api.mch.weixin.qq.com/v3/ecommerce/fund/enddaybalance/{request.SubMchId}";
        //    return await tenpayClient.GetAsync<EcommerceEndDayBalanceResponse>(url);
        //}

        ///// <summary>
        ///// 查询电商平台账户实时余额
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //public async Task<MerchantBalanceResponse> MerChantBalance(MerchantBalanceRequest request)
        //{
        //    string url = $"https://api.mch.weixin.qq.com/v3/merchant/fund/balance/{request.AccountType}";
        //    return await tenpayClient.GetAsync<MerchantBalanceResponse>(url);
        //}

        ///// <summary>
        ///// 查询电商平台账户日终余额(可查询90天内的日终余额)
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //public async Task<MerchantEndDayBalanceResponse> FundEndDayBalance(MerchantEndDayBalanceRequest request)
        //{
        //    string url = $"https://api.mch.weixin.qq.com/v3/merchant/fund/dayendbalance/{request.AccountType}";
        //    return await tenpayClient.GetAsync<MerchantEndDayBalanceResponse>(url);
        //}
    }
}
