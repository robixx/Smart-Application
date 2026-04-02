using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Applycation.ModelView
{
    public class RoleDto
    {
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
        public int IsActive { get; set; }
        public List<UserAssignRoleDto>?userlist { get; set; }
    }
}
