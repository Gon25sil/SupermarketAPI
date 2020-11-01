using Microsoft.EntityFrameworkCore;
using SupermarketAPI.Domain.Models;

namespace SupermarketAPI.Domain.Persistance
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
