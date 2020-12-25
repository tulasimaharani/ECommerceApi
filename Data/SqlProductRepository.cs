using System.Collections.Generic;
using System.Linq;
using ECommerceApi.Models;

namespace ECommerceApi.Data
{
    public class SqlProductRepository : IProductRepository
    {
        private readonly ECommerceContext _context;

        public SqlProductRepository(ECommerceContext context) 
        {
            _context = context;    
        }

        public void CreateProduct(Product product)
        {
            _context.Products.Add(product);                
        }

        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}