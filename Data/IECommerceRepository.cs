using System.Collections.Generic;
using ECommerceApi.Models;

namespace ECommerceApi.Data
{
    public interface IECommerceRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int id);
    }
}