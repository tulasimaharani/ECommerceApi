using ProductManagementApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductManagementApi.Data
{
    public class ProductManagerContext : DbContext
    {
        public ProductManagerContext(DbContextOptions<ProductManagerContext> opt) : base(opt)
        {
            
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Sale> Sales { get; set; }
    }
}