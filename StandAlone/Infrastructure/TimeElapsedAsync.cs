using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace StandAlone.Infrastructure
{
    public class TimeElapsedAsync : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Stopwatch timer = Stopwatch.StartNew();
            await next();
            timer.Stop();

            string result = "Elapsed Time: " + $"{timer.Elapsed.TotalMilliseconds} ms";
            byte[] bytes = Encoding.ASCII.GetBytes(result);
            await context.HttpContext.Response.Body.WriteAsync(bytes, 0, bytes.Length);
        }
    }
}
