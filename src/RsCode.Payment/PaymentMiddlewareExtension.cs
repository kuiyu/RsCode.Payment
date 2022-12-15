using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace RsCode.Payment
{
  public static  class PaymentMiddlewareExtension
    {
        public static void UsePayment(this IApplicationBuilder app)
        {

            app.Map( "/rspay", m => {
                app.UseMiddleware<PaymentMiddleware>();
            });
        }
    }
}
