using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Nutrilia.Models
{
    public class Users
    {
        [Key]
        public int Id_User { get; set; }
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; } 
        public string Bank_Account { get; set; }
        [JsonIgnore]
        public  ICollection<Cart> Cart { get; set; }
        [JsonIgnore]
        public  ICollection <Plans> Plans { get; set; }
    }
}
