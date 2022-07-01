using System.Net;
using System.Text.Json;

namespace TripsApp.Api.Middleware
{
    public static class MiddlewareExtensions
    {
        public static void UseCustomMiddleware(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsDevelopment())
            {
                app.UseMiddleware<ExceptionMiddleware>();
            }
        }

        public static async Task WriteCustomResponseAsync(this HttpResponse response, HttpStatusCode statusCode, string message)
        {
            response.StatusCode = (int)statusCode;
            response.ContentType = "application/json";

            await response.WriteAsync(JsonSerializer.Serialize(new
            {
                StatusCode = (int)statusCode,
                Message = message,
            }));
        }
    }
}
