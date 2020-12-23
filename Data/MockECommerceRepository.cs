using System.Collections.Generic;
using ECommerceApi.Models;

namespace ECommerceApi.Data
{
    public class MockECommerceRepository : IECommerceRepository
    {
        public Product GetProductById(int id)
        {
            return new Product(id:1, nome:"pao", valor_unitario:7.32, qtde_estoque:15);
        }

        public IEnumerable<Product> GetProducts()
        {
            var products = new List<Product>
            {
                new Product(id:1, nome:"bolacha", valor_unitario:3.45, qtde_estoque:45),
                new Product(id:2, nome:"farinha", valor_unitario:5.50, qtde_estoque:12),
                new Product(id:3, nome:"cafe", valor_unitario:4.85, qtde_estoque:50)
            };

            return products;
        }
    }
}