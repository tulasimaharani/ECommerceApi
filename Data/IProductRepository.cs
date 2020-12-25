using System.Collections.Generic;
using ECommerceApi.Models;

namespace ECommerceApi.Data
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int id);
    }
}