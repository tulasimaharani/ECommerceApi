using System.Collections.Generic;
using ECommerceApi.Models;

namespace ECommerceApi.Data
{
    public interface IProductRepository
    {
        bool SaveChanges();
        IEnumerable<Product> GetProducts();
        Product GetProductById(int id);
        void CreateProduct(Product product);
        void DeleteProduct(Product product);
    }
}