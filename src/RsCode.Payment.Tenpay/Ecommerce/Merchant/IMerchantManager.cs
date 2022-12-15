using RsCode.Payment.Tenpay.ECommerce.Merchant;
using System.Threading.Tasks;

namespace RsCode.Payment.Tenpay.ECommerce
{
    public interface IMerchantManager
    {
        Task<ApplyMentResponse> ApplymentAsync(ApplyMentRequest request);
        Task<object> Certificates();
        Task<object> ModifySettlement(ModifySettlementRequest request);
        Task<ApplymentQueryResponse> QueryAsync(ApplymentQueryRequest request);
        Task<SettlementResponse> Settlement(SettlementRequest request);
    }
}