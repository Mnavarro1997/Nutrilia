using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Nutrilia.Models
{
    public class Plans
    {
        public Plans()
        {
            Cart = new HashSet<Cart>();
            Users = new HashSet<Users>();

        }
        public int Id_Plan { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        [JsonIgnore]
        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
