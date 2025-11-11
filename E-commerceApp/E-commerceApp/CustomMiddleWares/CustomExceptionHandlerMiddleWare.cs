using DomainLayer.Exceptions;
using Microsoft.AspNetCore.Http;
using Shared.ErrorModels;
using System.Text.Json;

namespace E_commerceApp.CustomMiddleWares
{
    public class CustomExceptionHandlerMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionHandlerMiddleWare> _logger;

        public CustomExceptionHandlerMiddleWare(RequestDelegate next,ILogger<CustomExceptionHandlerMiddleWare> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
                await HandleNotFoundEndPointAsync(httpContext);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Somthing went wrong ");
                await HandleExceptionAsync(httpContext, ex);

            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            //set status code for response
            httpContext.Response.StatusCode = ex switch
            {
                ProductNotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError

            };
            //set content type for response


            //httpContext.Response.ContentType = "application/json";

            //create response object
            var response = new ErrorToReturn()
            {
                StatusCode = httpContext.Response.StatusCode,
                ErrorMessage = ex.Message,

            }
            ;

            //return object as json
            //var responseToReturn=JsonSerializer.Serialize(response);
            await httpContext.Response.WriteAsJsonAsync(response);
        }

        private static async Task HandleNotFoundEndPointAsync(HttpContext httpContext)
        {
            if (httpContext.Response.StatusCode == StatusCodes.Status404NotFound)
            {
                var response = new ErrorToReturn()
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    ErrorMessage = $"End Point With {httpContext.Request.Path} Is Not Found",

                };
                await httpContext.Response.WriteAsJsonAsync(response);

            }
        }
    }
}
