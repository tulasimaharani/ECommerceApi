using System.Collections.Generic;
using ECommerceApi.Data;
using ECommerceApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        //GET api/produtos
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            return Ok();
        }

        //GET api/produtos/{id}
        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            return Ok();
        }
    }
}