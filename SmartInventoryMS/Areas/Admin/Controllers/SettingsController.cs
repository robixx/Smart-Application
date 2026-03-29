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


        public IActionResult UserProfile()
        {
            return View();
        }
        public IActionResult RoleList()
        {
            return View();
        }


        public IActionResult Permission()
        {
            return View();
        }

    }
}
