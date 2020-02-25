using Microsoft.AspNetCore.Mvc;

namespace StandAlone.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            ViewBag.ErrorMessage = statusCode switch
            {
                404 => "That page does not exists",
                _ => "There was a problem"
            };

            return View("NotFound");
        }
    }
}