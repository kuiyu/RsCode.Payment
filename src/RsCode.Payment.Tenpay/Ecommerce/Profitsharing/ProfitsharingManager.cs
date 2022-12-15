/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using RsCode.Payment.Tenpay.ECommerce.Profitsharing;
using System.Net.Http;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace RsCode.Payment.Tenpay.ECommerce
{
    /// <summary>
    /// 分账
    /// </summary>
    public class ProfitsharingManager
    {
        //TenpayClientV3 tenpayClient;
        //JsonSerializerOptions jsonSerializerOptions;
        //public ProfitsharingManager(TenpayClientV3 _tenpayClient)
        //{
        //    tenpayClient = _tenpayClient;
        //    jsonSerializerOptions = new JsonSerializerOptions();
        //    jsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
        //}
        ///// <summary>
        ///// 微信订单支付成功后，由电商平台发起分账请求，将结算后的资金分给分账接收方
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //public async Task<ProfitSharingResponse> ProfitsharingAsync(ProfitSharingRequest request)
        //{
        //    string url = "https://api.mch.weixin.qq.com/v3/ecommerce/profitsharing/orders";
        //    return await tenpayClient.PostAsync<ProfitSharingResponse>(url, new StringContent(JsonSerializer.Serialize(request, jsonSerializerOptions)));
        //}

        ///// <summary>
        ///// 发起分账请求后，可调用此接口查询分账结果 ;发起分账完结请求后，可调用此接口查询分账完结的结果
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //public async Task<ProfitsharingQueryResponse> ProfitsharingQueryAsync(ProfitSharingQueryRequest request)
        //{
        //    string url = $"https://api.mch.weixin.qq.com/v3/ecommerce/profitsharing/orders?sub_mchid={request.SubMchId}&transaction_id={request.TransactionId}&out_order_no={request.OutOrderNo}";
        //    return await tenpayClient.GetAsync<ProfitsharingQueryResponse>(url);
        //}
        ///// <summary>
        ///// 订单已经分账，在退款时，可以先调此接口，将已分账的资金从分账接收方的账户回退给分账方，再发起退款
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //public async Task<ProfitSharingReturnOrdersResponse> ProfitSharingReturnAsync(ProfitSharingReturnOrdersRequest request)
        //{
        //    string url = "https://api.mch.weixin.qq.com/v3/ecommerce/profitsharing/returnorders";
        //    return await tenpayClient.PostAsync<ProfitSharingReturnOrdersResponse>(url, new StringContent(JsonSerializer.Serialize(request, jsonSerializerOptions)));
        //}

        ///// <summary>
        ///// 商户需要核实回退结果，可调用此接口查询回退结果;如果分账回退接口返回状态为处理中，可调用此接口查询回退结果
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //public async Task<ProfitSharingReturnOrdersQueryResponse>ProfitSharingReturnQueryAsync(ProfitSharingReturnOrdersQueryRequest request)
        //{
        //    string url = $"https://api.mch.weixin.qq.com/v3/ecommerce/profitsharing/returnorders?sub_mchid={request.SubMchId}&order_id={request.OrderId}&out_return_no={request.OutReturnNo}";
        //    if(string.IsNullOrEmpty(request.OrderId))
        //    {
        //        url = $"https://api.mch.weixin.qq.com/v3/ecommerce/profitsharing/returnorders?sub_mchid={request.SubMchId}&out_order_no={request.OutOrderNo}&out_return_no={request.OutReturnNo}";
        //    }
        //    return await tenpayClient.GetAsync<ProfitSharingReturnOrdersQueryResponse>(url);
        //}

        ///// <summary>
        ///// 不需要进行分账的订单，可直接调用本接口将订单的金额全部解冻给二级商户。
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //public async Task<ProfitSharingFinishOrderResponse> ProfitSharingFinishOrderAsync(ProfitSharingFinishOrderRequest request)
        //{
        //    string url = "https://api.mch.weixin.qq.com/v3/ecommerce/profitsharing/finish-order";
        //    return await tenpayClient.PostAsync<ProfitSharingFinishOrderResponse>(url, new StringContent(JsonSerializer.Serialize(request, jsonSerializerOptions)));
        //}

        ///// <summary>
        ///// 添加分账接收方
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //public async Task<ProfitSharingReceiverAddResponse>AddReceiverAsync(ProfitSharingReceiverAddRequest request)
        //{
        //    string url = "https://api.mch.weixin.qq.com/v3/ecommerce/profitsharing/receivers/add";
        //    return await tenpayClient.PostAsync<ProfitSharingReceiverAddResponse>(url, new StringContent(JsonSerializer.Serialize(request, jsonSerializerOptions)));
        //}
        
        //public async Task<ProfitSharingReceiverDeleteResponse> DeleteReceiverAsync(ProfitSharingReceiverDeleteRequest request)
        //{
        //    string url = "https://api.mch.weixin.qq.com/v3/ecommerce/profitsharing/receivers/delete";
        //    return await tenpayClient.PostAsync<ProfitSharingReceiverDeleteResponse>(url, new StringContent(JsonSerializer.Serialize(request, jsonSerializerOptions)));
        //}


    }
}
