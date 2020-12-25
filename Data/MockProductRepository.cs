using System.Collections.Generic;
using ECommerceApi.Models;

namespace ECommerceApi.Data
{
    public class MockProductRepository : IProductRepository
    {
        public Product GetProductById(int id)
        {
            return new Product(Id:1, Nome:"pao", ValorUnitario:7.32, QuantidadeEstoque:15);
        }

        public IEnumerable<Product> GetProducts()
        {
            var products = new List<Product>
            {
                new Product(Id:1, Nome:"bolacha", ValorUnitario:3.45, QuantidadeEstoque:45),
                new Product(Id:2, Nome:"farinha", ValorUnitario:5.50, QuantidadeEstoque:12),
                new Product(Id:3, Nome:"cafe", ValorUnitario:4.85, QuantidadeEstoque:50)
            };

            return products;
        }
    }
}