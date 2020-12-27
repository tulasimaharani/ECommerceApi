using Microsoft.EntityFrameworkCore;
using PaymentApi.Models;

namespace PaymentApi.Data
{
    public class PaymentContext : DbContext
    {
        public PaymentContext(DbContextOptions<PaymentContext> opt) : base(opt)
        {
            
        }
        public DbSet<Payment> Payments { get; set; }

        public DbSet<Card> Cards { get; set; }
    }
}