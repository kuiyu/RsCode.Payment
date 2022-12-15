using Microsoft.AspNetCore.Http;
using RsCode.DI;
using System.Threading.Tasks;

namespace RsCode.Payment
{
    public  interface IPayment:ISingletonDependency
    {
        string ApiTypeName { get; }
        Task<string> InvokeAsync(HttpContext httpContext);
         
    }


    
}
