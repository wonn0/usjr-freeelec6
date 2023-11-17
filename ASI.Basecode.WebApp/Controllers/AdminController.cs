using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static ASI.Basecode.Resources.Constants.Constants;

namespace ASI.Basecode.WebApp.Controllers
{
    [Authorize(Roles = "User1")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}