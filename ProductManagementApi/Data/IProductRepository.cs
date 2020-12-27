using System.Collections.Generic;
using ProductManagementApi.Models;

namespace ProductManagementApi.Data
{
    public interface IProductRepository
    {
        bool SaveChanges();
        IEnumerable<Product> GetProducts();
        Product GetProductById(int id);
        void CreateProduct(Product product);
        void DeleteProduct(Product product);
        void SellProduct(Product product);
    }
}