using System.ComponentModel.DataAnnotations;

namespace Nutrilia.Models
{
    public class Recipes
    {
        [Key]
        public int Id_Recipe { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}
