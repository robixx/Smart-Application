using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Applycation.ModelView
{
    public class SubmenuDto
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; } = string.Empty;
        public string? MenuUrl { get; set; }
        public string? AreaName { get; set; }
        public string? ActionController { get; set; }
        public string? ActionMethod { get; set; }
        public int? ParentMenuId { get; set; }
        public string? Icon { get; set; }
        public int DisplayOrder { get; set; }
    }
}
