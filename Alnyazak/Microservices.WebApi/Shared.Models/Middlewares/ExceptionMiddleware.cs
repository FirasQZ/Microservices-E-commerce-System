using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Shared.Models.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            switch (ex)
            {
                case UnauthorizedAccessException:
                    context.Response.StatusCode = StatusCodes.Status403Forbidden; break;
                case InvalidDataException:
                case InvalidOperationException:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest; break;
                case Exception:
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError; break;

            }
            return context.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = context.Response.StatusCode,
                Message = $"{ex.Message}:{ex.InnerException}"
            }.ToString());
        }
    }

    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
