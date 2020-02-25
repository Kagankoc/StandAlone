using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Diagnostics;
using System.Threading.Tasks;

namespace StandAlone.Infrastructure
{
    public class ActionResultMix : ActionFilterAttribute
    {
        private Stopwatch timer;
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            timer = Stopwatch.StartNew();
            await next();
        }

        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            timer.Stop();
            context.Result = new ViewResult
            {
                ViewName = "TimeElapsed",
                ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                {
                    Model = "Elapsed Time: " + $"{timer.Elapsed.TotalMilliseconds} ms"
                }
            };
            await next();
        }
    }
}
