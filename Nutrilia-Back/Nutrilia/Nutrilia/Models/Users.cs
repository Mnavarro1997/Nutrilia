using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nutrilia.Models
{
    public class Users
    {
        public Users()
        {
            Cart = new HashSet<Cart>();
            Plans = new HashSet<Plans>();
        }
        public int Id_User { get; set; }
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; } 
        public string Bank_Account { get; set; }

        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection <Plans> Plans { get; set; }
    }
}
