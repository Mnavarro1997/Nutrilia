using System.ComponentModel.DataAnnotations;

namespace Nutrilia.DTOs
{
    public class UsersDTO
    {
        public int Id_User { get; set; }
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Bank_Account { get; set; }
    }
}
