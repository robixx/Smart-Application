using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Applycation.ModelView
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string LoginUserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string? Email { get; set; }
        public bool IsActive { get; set; }

        public string Avater
        {
            get
            {
                if (string.IsNullOrWhiteSpace(UserName))
                    return "";

                var parts = UserName.Trim().Split(' ');

                if (parts.Length == 1)
                    return parts[0][0].ToString().ToUpper();

                return (parts[0][0].ToString() + parts[1][0].ToString()).ToUpper();
            }
        }
    }
}
