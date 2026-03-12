using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Applycation.ModelView
{
    public class LoginResponseDto
    {
        public int UserId {  get; set; }
        public string UserName { get; set; } = string.Empty;
        public string RoleName {  get; set; } = string.Empty;
        public int RoleId {  get; set; }
    }
}
