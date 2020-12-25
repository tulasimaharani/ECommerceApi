using System.Collections.Generic;
using AutoMapper;
using ECommerceApi.Data;
using ECommerceApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }
        
        //GET api/produtos
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            var produtos = _repository.GetProducts();

            return Ok(produtos);
        }

        //GET api/produtos/{id}
        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var produto = _repository.GetProductById(id);
            
            return Ok(produto);
        }
    }
}