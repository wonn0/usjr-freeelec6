using Microsoft.AspNetCore.Mvc;

namespace ASI.Basecode.WebApp.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Forbidden()
        {
            return View("Forbidden");
        }
    }
}
