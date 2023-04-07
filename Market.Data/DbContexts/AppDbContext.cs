using Market.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Market.Data.DbContexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = "Server=(localdb)\\mssqllocaldb;Database=Market;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(path);
        }
    }
}
