using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Domain.Entity
{
    
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }
        public string MenuName { get; set; }=string.Empty;
        public string MenuUrl { get; set; } = string.Empty;
        public string ActionController { get; set; } = string.Empty;
        public string ActionMethod { get; set; } = string.Empty;
        public int? ParentMenuId { get; set; }
        public string? Icon { get; set; }
        public int DisplayOrder { get; set; }
        public int IsActive { get; set; } = 0;
    }
}
