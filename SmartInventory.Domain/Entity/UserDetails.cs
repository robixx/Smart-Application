using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Domain.Entity
{
    [Table("User_details")]
    public class UserDetails
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }     
        public string? MobileNumber { get; set; }     
        public string? Address { get; set; }     
        public string? Title { get; set; }
    }
}
