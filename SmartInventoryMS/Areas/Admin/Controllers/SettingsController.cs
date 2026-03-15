using Microsoft.AspNetCore.Mvc;

namespace SmartInventoryMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SettingsController : Controller
    {

       
        public IActionResult GetUserList()
        {
            return View();
        }
    }
}
