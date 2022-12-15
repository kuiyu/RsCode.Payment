using RsCode.Payment.Tenpay.Ecommerce.Merchant;
using RsCode.Payment.Tenpay.ECommerce.Merchant;
using RsCode.Payment.Tenpay.V3;
using System.Text.Json;
using System.Threading.Tasks;

namespace RsCode.Payment.Tenpay.ECommerce
{
    /// <summary>
    /// 二级商户进件
    /// </summary>
    public class MerchantManager //: IMerchantManager
    {
        TenpayClientV3 tenpayClient;
        public MerchantManager(TenpayClientV3 _tenpayClient)
        {
            tenpayClient = _tenpayClient;
        }
        ///// <summary>
        ///// 电商平台，可使用该接口，帮助其二级商户进件成为微信支付商户
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //public async Task<ApplyMentResponse> ApplymentAsync(ApplyMentRequest request)
        //{
        //    string url = "https://api.mch.weixin.qq.com/v3/ecommerce/applyments/";
        //    return await tenpayClient.PostAsync<ApplyMentResponse>(url, request);
        //}

        ///// <summary>
        ///// 查询申请状态 
        ///// https://pay.weixin.qq.com/wiki/doc/apiv3/wxpay/ecommerce/applyments/chapter3_2.shtml
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //public async Task<ApplymentQueryResponse> QueryAsync(ApplymentQueryRequest request)
        //{
        //    string url = "";
        //    if (request.ApplymentId > 0)
        //    {
        //        url = $"https://api.mch.weixin.qq.com/v3/ecommerce/applyments/{request.ApplymentId}";
        //    }
        //    else
        //    {
        //        url = $"https://api.mch.weixin.qq.com/v3/ecommerce/applyments/out-request-no/{request.OutRequestNo}";
        //    }
        //    return await tenpayClient.PostAsync<ApplymentQueryResponse>(url, request);
        //}



        ///// <summary>
        ///// 下载平台证书
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //public async Task<object> Certificates()
        //{
        //    string url = "https://api.mch.weixin.qq.com/v3/certificates";
        //    var response = await tenpayClient.GetAsync(url);
        //    if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //    {
        //        using (var responseStream = await response.Content.ReadAsStreamAsync())
        //        {
        //            return await JsonSerializer.DeserializeAsync
        //             <CertResult>(responseStream);
        //        }
        //    }
        //    else
        //    {
        //        using (var responseStream = await response.Content.ReadAsStreamAsync())
        //        {
        //            return await JsonSerializer.DeserializeAsync
        //             <CertExceptionResult>(responseStream);
        //        }
        //    }
        //}

        ///// <summary>
        ///// 普通服务商（支付机构、银行不可用），可使用本接口修改其进件、已签约的特约商户-结算账户信息。
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //public async Task<object> ModifySettlement(ModifySettlementRequest request)
        //{
        //    string url = $"https://api.mch.weixin.qq.com/v3/apply4sub/sub_merchants/{request.SubMchId}/modify-settlement";
        //    return await tenpayClient.PostAsync<object>(url, request);
        //}
        ///// <summary>
        ///// 普通服务商（支付机构、银行不可用），可使用本接口查询其进件、已签约的特约商户-结算账户信息（敏感信息掩码）。
        ///// 该接口可用于核实是否成功修改结算账户信息、及查询系统汇款验证结果
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //public async Task<SettlementResponse> Settlement(SettlementRequest request)
        //{
        //    string url = $"https://api.mch.weixin.qq.com/v3/apply4sub/sub_merchants/{request.SubMchId}/settlement";
        //    return await tenpayClient.PostAsync<SettlementResponse>(url, request);
        //}

    }
}
