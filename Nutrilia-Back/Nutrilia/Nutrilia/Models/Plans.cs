using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Nutrilia.Models
{
    public partial class Plans
    {
        [Key]
        public int Id_Plan { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURl { get; set; }

        [JsonIgnore]
        public ICollection <Cart> Cart { get; set; }
        public ICollection<Users> Users { get; set; }
    }
}
