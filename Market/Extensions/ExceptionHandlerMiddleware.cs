using System;
using System.Threading.Tasks;
using Entities.DataTransferObjects.Errors;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NLog;

namespace Market.Extensions
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionMessageAsync(context, ex);
            }
        }
        
        private Task HandleExceptionMessageAsync(HttpContext context, Exception ex)
        {
            _logger.Error(ex.Message);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = ex switch
            {
                ExceptionWithStatusCode e => (int) e.StatusCode,
                _ => 500
                // (int)((ExceptionWithStatusCode) ex).StatusCode;
            };
            return context.Response.WriteAsync(JsonConvert.SerializeObject(new ErrorDetails
            {
                Message = ex switch
                {
                    _ => ex.Message
                }
            }));
        }
    }
}