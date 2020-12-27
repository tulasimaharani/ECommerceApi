using ProductManagementApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductManagementApi.Data
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext(DbContextOptions<ECommerceContext> opt) : base(opt)
        {
            
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Card> Cards { get; set; }
    }
}