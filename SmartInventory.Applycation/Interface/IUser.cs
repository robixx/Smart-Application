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
    }
}
