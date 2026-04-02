using Microsoft.AspNetCore.Mvc;
using SmartInventory.Applycation.Interface;
using SmartInventory.Applycation.ModelView;

namespace SmartInventoryMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SettingsController : Controller
    {

        private readonly IUser _user;

        public SettingsController (IUser user)
        {
            _user = user;
        }

        public async Task<IActionResult> GetUserList()
        {
            var result = await _user.GetUserAsync();
            return View(result.user_list);
        }

        [HttpPost]

        public async Task<IActionResult> SaveUser([FromBody] UserDto userDto)
        {
            var result= await _user.UserSaveAsync(userDto);

            return Ok(new { message = result.Message, status=result.Status });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _user.UserDeleteAsync(id);

            return Ok(new { message = result.Message, status = result.Status });
        }
        public IActionResult UserProfile()
        {
            return View();
        }


        public async Task<IActionResult> RoleList()
        {

            var result = await _user.GetRoleAsync();
            return View(result.role_list);
        }


        public async Task<IActionResult> SaveRole([FromBody] RoleDto roleDto)
        {
            var result = await _user.RoleSaveAsync(roleDto);

            return Ok(new { message = result.Message, status = result.Status });
        }

        public IActionResult Permission()
        {
            return View();
        }

    }
}
