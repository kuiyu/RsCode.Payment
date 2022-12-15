using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace RsCode.Payment
{
    /// <summary>
    /// 支付客户端授权策略
    /// </summary>
    public class PayClientRequirement:IAuthorizationRequirement
    {
       
    }

    public class PayClientRequirementHandler : AuthorizationHandler<PayClientRequirement>
    {
        IPayConfig payClient;
        public PayClientRequirementHandler(IPayConfig _payClient)
        {
            payClient = _payClient;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PayClientRequirement requirement)
        {
            
            if(!context.User.HasClaim(c=>c.Type=="AppId"))
            {
                return Task.CompletedTask;
            }
            string appId = context.User.FindFirst(c => c.Type == "AppId").Value;
            //查询appid支付信息 
            var payOption= payClient.GetClient(appId);
            if(payOption!=null)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
