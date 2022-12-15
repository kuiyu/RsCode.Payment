using Microsoft.AspNetCore.Http;
using RsCode.Payment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace Rswl.Payment.Alipay.Application
{
    public class AlipayAccountQuery: PaymentClient, IPayment
    {
        [Required]
        [Display(Name = "alipay_user_id")]
        public string AlipayUserId { get; set; }

        [Required]
        [Display(Name = "account_type")]
        public string AccountType { get; set; }

        public string ApiTypeName => throw new NotImplementedException();
        //   public string ApiTypeName => "alipay.trade.app.pay";
        public Task<string> InvokeAsync(HttpContext httpContext)
        {
            var client = GetClient();
            // client.SdkExecute<AlipayAccountQueryResponse>(this);
            // return result;
            return null;
        }

        //初始化SDK
        //支付宝实例
        //IAopClient client=new DefaultAopClient("",xx);
        //AlipayTradeAppPayRequest request=new ();
        //request.SetBizModel(model);
        //request.RequestDelegate.SetNotifyUrl("外网可以访问的异步地址");
        //AlipayTradeAppPayResponse response=client.SdkExecute(request);
        //Response.Write(HttpUtility.HtmlEncode(response.Body));
    }
}
