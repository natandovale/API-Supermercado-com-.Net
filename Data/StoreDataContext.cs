using Microsoft.EntityFrameworkCore;
using WebApplication2.Data.Maps;
using WebApplication2.Model;

namespace WebApplication2.Data
{
    public class StoreDataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Cart { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = SampleDB; Trusted_Connection = True");
            //optionsBuilder.UseInMemoryDatabase("Products");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new CartMap());
        }
    }
}