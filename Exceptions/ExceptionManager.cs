using System.Net;
using Exceptions.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace Exceptions
{
    public class ExceptionManager : ExceptionHandlerOptions
    {
        public ExceptionManager()
        {
            ExceptionHandler = async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();

                if (exceptionHandlerPathFeature.Error is null)
                    return;

                switch (exceptionHandlerPathFeature.Error)
                {
                    case FoodTruckExceptionHttp exceptionHttp:
                        context.Response.StatusCode = (int)exceptionHttp.StatusCode;
                        await context.Response.WriteAsync(exceptionHttp.Message);
                        break;
                    default:
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync(exceptionHandlerPathFeature.Error.Message);
                        break;
                }
            };
        }
    }
}