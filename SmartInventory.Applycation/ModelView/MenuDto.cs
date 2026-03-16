using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Applycation.ModelView
{
    public class MenuDto
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; } = string.Empty;
        public string? Icon {  get; set; }
        public string? MenuUrl {  get; set; }
        public string? AreaName { get; set; }
        public string? ActionController { get; set; }
        public string? ActionMethod { get; set; }
        public List<SubmenuDto>?submenu { get; set; }
        
    }
}
