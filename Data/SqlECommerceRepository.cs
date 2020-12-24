using System.Collections.Generic;
using System.Linq;
using ECommerceApi.Models;

namespace ECommerceApi.Data
{
    public class SqlECommerceRepository : IECommerceRepository
    {
        private readonly ECommerceContext _context;

        public SqlECommerceRepository(ECommerceContext context) 
        {
            _context = context;    
        }
        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }
    }
}