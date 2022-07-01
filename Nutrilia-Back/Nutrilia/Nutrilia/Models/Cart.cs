using System.Collections.Generic;

namespace Nutrilia.Models
{
    public class Cart
    {
        public Cart()
        {
            Plans = new HashSet<Plans>();
            Users = new HashSet<Users>();
        }
        public string Id_Plan { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<Plans> Plans { get; set; }
        public virtual ICollection<Users> Users{ get; set; }
    }
}
