using System.Net;
using TripsApp.Api.Constants;

namespace TripsApp.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception)
            {

                await httpContext.Response.WriteCustomResponseAsync(HttpStatusCode.BadRequest, ErrorConstants.InternalError);
            }
        }
    }
}
