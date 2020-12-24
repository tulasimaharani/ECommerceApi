using ECommerceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApi.Data
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext(DbContextOptions<ECommerceContext> opt) : base(opt)
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}