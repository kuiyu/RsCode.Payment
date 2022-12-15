/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using RsCode.Payment.Tenpay.ECommerce.ESubsidies;
using RsCode.Payment.Tenpay.V3;
using System.Threading.Tasks;

namespace RsCode.Payment.Tenpay.ECommerce
{
    public class SubsidiesManager
    {
        TenpayClientV3 tenpayClient;
        public SubsidiesManager(TenpayClientV3 _tenpayClient)
        {
            tenpayClient = _tenpayClient;
        }

        ///// <summary>
        ///// 请求补差API
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //public async Task<SubsidiesCreateResponse>Create(SubsidiesCreateRequest request)
        //{
        //    string url = "https://api.mch.weixin.qq.com/v3/ecommerce/subsidies/create";
        //    return await tenpayClient.PostAsync<SubsidiesCreateResponse>(url, request);
        //}

        ///// <summary>
        ///// 请求补差回退API
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //public async Task<SubsidiesReturnResponse> Return(SubsidiesReturnRequest request)
        //{
        //    string url = "https://api.mch.weixin.qq.com/v3/ecommerce/subsidies/return";
        //    return await tenpayClient.PostAsync<SubsidiesReturnResponse>(url, request);
        //}

        ///// <summary>
        ///// 取消补差API
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //public async Task<SubsidiesCancelResponse> Cancel(SubsidiesCancelRequest request)
        //{
        //    string url = "https://api.mch.weixin.qq.com/v3/ecommerce/subsidies/cancel";
        //    return await tenpayClient.PostAsync<SubsidiesCancelResponse>(url, request);
        //}

    }
}
