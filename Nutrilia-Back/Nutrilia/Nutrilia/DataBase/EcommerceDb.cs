using Microsoft.EntityFrameworkCore;
using Nutrilia.Models;

namespace Nutrilia.DataBase
{
    public partial class EcommerceDb : DbContext
    {
        public DbSet<Plans> Plans { get; set; }
        public DbSet<Recipes> Recipes { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Cart> Cart { get; set; }

        public EcommerceDb(DbContextOptions<EcommerceDb> options)
            : base(options)
        {
        }
        
    }
}
