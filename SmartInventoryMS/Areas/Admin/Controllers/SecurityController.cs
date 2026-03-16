using Microsoft.AspNetCore.Mvc;

namespace SmartInventoryMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SecurityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
