using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace Nutrilia.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int Id_Plan { get; set; }
        public int Id_User { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public  ICollection<Plans> Plans { get; set; }
        public  ICollection<Users> Users{ get; set; }
    }
}
