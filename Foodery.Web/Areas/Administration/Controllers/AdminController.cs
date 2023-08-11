using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Foodery.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public abstract class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
