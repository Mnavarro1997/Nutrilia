using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Nutrilia.Models
{
    public class Cart
    {
        public Cart()
        {
            Plans = new HashSet<Plans>();
            Users = new HashSet<Users>();
        }
        public int Id { get; set; }
        public int Id_Plan { get; set; }
        public int Id_User { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Plans> Plans { get; set; }
        public virtual ICollection<Users> Users{ get; set; }
    }
}
