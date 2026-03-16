using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Domain.Entity
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; }=string.Empty;
        public string LoginUserName { get; set; }=string.Empty;

        public string PasswordHash { get; set; } = string.Empty;        

        public string? Email { get; set; }   
      
        public bool IsActive { get; set; }       

        public DateTime? LastLogin { get; set; }

        public DateTime CreatedDate { get; set; }      

       
    }
}
