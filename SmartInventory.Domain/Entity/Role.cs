using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Domain.Entity
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string RoleName {  get; set; }=string.Empty;
        public int IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
