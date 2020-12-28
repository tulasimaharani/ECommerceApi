using System.Collections.Generic;
using System.Linq;
using ProductManagementApi.Dtos;
using ProductManagementApi.Models;

namespace ProductManagementApi.Data
{
    public interface IProductManagerRepository
    {
        bool SaveChanges();
        IEnumerable<Product> GetProducts();
        ProductShowOneDto GetProductByIdWithLastSale(int id);
        Product GetProductById(int id);
        void CreateProduct(Product product);
        void DeleteProduct(Product product);
        void SellProduct(Sale sale);
    }
}