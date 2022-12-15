/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using RsCode.Payment.Tenpay.ECommerce.ECombine;
using RsCode.Payment.Tenpay.V3;
using System.Threading.Tasks;

namespace RsCode.Payment.Tenpay.ECommerce
{
    public class ECombineManager
    {
        //TenpayClientV3 tenpayClient;
        //public ECombineManager(TenpayClientV3 _tenpayClient)
        //{
        //    tenpayClient = _tenpayClient;
        //}
        ///// <summary>
        ///// 合单下单-APP支付API
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //public async Task<AppResponse> AppAsync(AppRequest request)
        //{
        //    string url = "https://api.mch.weixin.qq.com/v3/combine-transactions/app";
        //    return await tenpayClient.PostAsync<AppResponse>(url, request);
        //}

        ///// <summary>
        ///// 合单下单-JSAPI支付API
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //public async Task<JspaiResponse> JsapiAsync(JsapiRequest request)
        //{
        //    string url = "https://api.mch.weixin.qq.com/v3/combine-transactions/jsapi";
        //    return await tenpayClient.PostAsync<JspaiResponse>(url, request);
        //}

        ///// <summary>
        ///// 合单下单-H5支付API
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //public async Task<H5Response> H5Async(H5Request request)
        //{
        //    string url = "https://api.mch.weixin.qq.com/v3/combine-transactions/h5";
        //    return await tenpayClient.PostAsync<H5Response>(url, request);
        //}

        ///// <summary>
        ///// 合单下单-Native支付API
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //public async Task<NativeResponse> NativeAsync(NativeRequest request)
        //{
        //    string url = "https://api.mch.weixin.qq.com/v3/combine-transactions/native";
        //    return await tenpayClient.PostAsync<NativeResponse>(url, request);
        //}

        ///// <summary>
        ///// 合单查询订单API
        ///// </summary>
        ///// <param name="combineOutTradeNo"></param>
        ///// <returns></returns>
        //public async Task<QueryResponse>QueryAsync(string combineOutTradeNo)
        //{
        //    string url = $"https://api.mch.weixin.qq.com/v3/combine-transactions/out-trade-no/{combineOutTradeNo}";
        //    return await tenpayClient.GetAsync<QueryResponse>(url);
        //}

        ///// <summary>
        ///// 合单关闭订单API
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //public async Task<object>CloseAsync(CloseRequest request)
        //{
        //    string url = $"https://api.mch.weixin.qq.com/v3/combine-transactions/out-trade-no/{request.CombineOutTradeNo}/close"; 
        //    return await tenpayClient.PostAsync<object>(url, request);
        //}
    }
}
