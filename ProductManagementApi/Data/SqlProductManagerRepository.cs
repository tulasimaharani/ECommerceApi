using System;
using System.Collections.Generic;
using System.Linq;
using ProductManagementApi.Dtos;
using ProductManagementApi.Models;

namespace ProductManagementApi.Data
{
    public class SqlProductManagerRepository : IProductManagerRepository
    {
        private readonly ProductManagerContext _context;

        public SqlProductManagerRepository(ProductManagerContext context) 
        {
            _context = context;    
        }

        public void CreateProduct(Product product)
        {
            _context.Products.Add(product);                
        }

        public void DeleteProduct(Product product)
        {
            if(product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            _context.Products.Remove(product);
        }

        public ProductShowOneDto GetProductByIdWithLastSale(int id)
        {
            var product = _context.Products
            .Join(_context.Sales, p => p.Id, s => s.ProdutoId,
                (p, s) => new ProductShowOneDto
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    QuantidadeEstoque = p.QuantidadeEstoque,
                    ValorUnitario = p.ValorUnitario,
                    Data = s.Data,
                    Valor = s.Valor
                }
            ).Where(p => p.Id == id)
            .OrderBy(p => p.Data);            

            if(product.Count() != 0)
                return product.Last();

            return null;
        }
         public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products
                .Where(p => p.QuantidadeEstoque > 0)
                .ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void SellProduct(Sale sale)
        {
            _context.Sales.Add(sale);
        }
    }
}