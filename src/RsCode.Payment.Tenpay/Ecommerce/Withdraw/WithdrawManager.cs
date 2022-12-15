/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using RsCode.Payment.Tenpay.ECommerce.Withdraw;
using System.Net.Http;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace RsCode.Payment.Tenpay.ECommerce
{
    public class WithdrawManager
    {
        //TenpayClientV3 tenpayClient;
        //JsonSerializerOptions jsonSerializerOptions;
        //public WithdrawManager(TenpayClientV3 _tenpayClient)
        //{
        //    tenpayClient = _tenpayClient;
        //    jsonSerializerOptions = new JsonSerializerOptions();
        //    jsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
        //}
        ///// <summary>
        ///// 电商平台通过余额提现API帮助二级商户发起账户余额提现申请，完成账户余额提现
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //public async Task<SubMchWithdrawResponse> EcommerceWithdraw(SubMchWithdrawRequest request)
        //{
        //    string url = "https://api.mch.weixin.qq.com/v3/ecommerce/fund/withdraw";
        //    return await tenpayClient.PostAsync<SubMchWithdrawResponse>(url,new StringContent(JsonSerializer.Serialize( request,jsonSerializerOptions)));
        //}
        ///// <summary>
        ///// 电商平台通过查询提现状态API查询二级商户提现单的提现结果
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //public async Task<SubMchWithdrawStatusResponse> EcommerceWithdrawStatus(SubMchWithdrawStatusRequest request)
        //{
        //    string url = $"https://api.mch.weixin.qq.com/v3/ecommerce/fund/withdraw/{request.WithdrawId}";
        //    if(string.IsNullOrWhiteSpace(request.WithdrawId))
        //    {
        //        url = $"https://api.mch.weixin.qq.com/v3/ecommerce/fund/withdraw/out-request-no/{request.OutRequestNo}";
        //    }
        //    return await tenpayClient.GetAsync<SubMchWithdrawStatusResponse>(url);
        //}
        ///// <summary>
        ///// 电商平台通过该接口可将其平台的收入进行提现
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //public async Task<MerchantWithdrawResponse> MerchantWithdraw(MerchantWithdrawRequest request)
        //{
        //    string url = "https://api.mch.weixin.qq.com/v3/merchant/fund/withdraw";
        //    return await tenpayClient.PostAsync<MerchantWithdrawResponse>(url, new StringContent(JsonSerializer.Serialize(request, jsonSerializerOptions)));
        //}
        ///// <summary>
        ///// 电商平台通过该接口查询其提现结果
        ///// </summary>
        ///// <param name="request">方式1：微信支付提现单号查询； 方式2：商户提现单号查询。</param>
        ///// <returns></returns>
        //public async Task<MerchantWithdrawStatusResponse> MerchantWithdrawStatus(MerchantWithdrawStatusRequest request)
        //{
        //    string url = $"https://api.mch.weixin.qq.com/v3/ecommerce/fund/withdraw/{request.WithdrawId}";
        //    if (string.IsNullOrWhiteSpace(request.WithdrawId))
        //    {
        //        url = $"https://api.mch.weixin.qq.com/v3/merchant/fund/withdraw/out-request-no/{request.OutRequestNo}";
        //    }
        //    return await tenpayClient.GetAsync<MerchantWithdrawStatusResponse>(url);
        //}

        //public async Task<DownWithdrawExceptionFileResponse> DownWithdrawExceptionFile(DownWithdrawExceptionFileRequest request)
        //{
        //    string url = $"https://api.mch.weixin.qq.com/v3/merchant/fund/withdraw/bill-type/{request.BillType}?bill_date={request.BillDate}&tar_type={request.TarType}";
        //    if (string.IsNullOrWhiteSpace(request.BillDate))
        //    {
        //        url = $"https://api.mch.weixin.qq.com/v3/merchant/fund/withdraw/bill-type/{request.BillType}?tar_type={request.TarType}";
        //    }
        //    return await tenpayClient.GetAsync<DownWithdrawExceptionFileResponse>(url);
        //}
    }
}
