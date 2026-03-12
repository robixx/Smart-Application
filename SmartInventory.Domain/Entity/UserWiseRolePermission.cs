using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Domain.Entity
{
    public class UserWiseRolePermission
    {
        [Key]
        public int Id { get; set; } 
        public int RoleId { get; set; }
        [Index(IsUnique = true)]        
        public int UserId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
