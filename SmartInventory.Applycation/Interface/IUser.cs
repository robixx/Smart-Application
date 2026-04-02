using SmartInventory.Applycation.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Applycation.Interface
{
    public interface IUser
    {
        Task<(string Message, bool Status, List<UserDto> user_list)> GetUserAsync();
        Task<(string Message, bool Status)> UserSaveAsync(UserDto userDto);
        Task<(string Message, bool Status)> UserDeleteAsync(int Id);
        Task<(string Message, bool Status, List<RoleDto> role_list)> GetRoleAsync();
        Task<(string Message, bool Status)> RoleSaveAsync(RoleDto roleDto);
    }
}
