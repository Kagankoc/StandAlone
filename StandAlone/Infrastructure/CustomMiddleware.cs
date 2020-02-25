using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace StandAlone.Infrastructure
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.ToString() == "/middleware")
            {
                await httpContext.Response.WriteAsync("This is from CustomMiddleware");
            }
            else
            {
                await _next.Invoke(httpContext);
            }
        }
    }
}
