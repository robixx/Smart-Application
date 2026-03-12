using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Domain.Entity
{
    public class RoleWiseMenuPermission
    {
        [Key]
        public int Id { get; set; }
        public int RoleId {  get; set; }
        public int MenuId { get; set; }

    }
}
