using Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using WebApp.DTO.Responses;

namespace WebApp.Middleware
{
    public class ExceptionHandler
    {
        private RequestDelegate _requestDelegate;

        public ExceptionHandler(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _requestDelegate(httpContext);
            }
            catch (APIException APIEx)
            {

                var response = APIResponse.Fail(APIEx.Code, APIEx.Message);
                var responseMessage = JsonConvert.SerializeObject(response);
                await httpContext.Response.WriteAsync(responseMessage);

            }
            catch (Exception)
            {

                var response = APIResponse.Fail(500, "unhandled exception");
                var responseMessage = JsonConvert.SerializeObject(response);
                await httpContext.Response.WriteAsync(responseMessage);
            }

        }
    }
}
