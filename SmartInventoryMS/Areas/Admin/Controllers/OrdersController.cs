using Microsoft.AspNetCore.Mvc;

namespace SmartInventoryMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrdersController : Controller
    {
        public IActionResult AllOrderList()
        {
            return View();
        }

        public IActionResult NewOrderList()
        {
            return View();
        }
    }
}
