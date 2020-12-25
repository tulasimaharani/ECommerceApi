using System.Collections.Generic;
using AutoMapper;
using ECommerceApi.Data;
using ECommerceApi.Dtos;
using ECommerceApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        //GET api/produtos
        [HttpGet]
        public ActionResult<IEnumerable<ProductReadDto>> GetAllProducts()
        {
            var produtos = _repository.GetProducts();

            return Ok(_mapper.Map<IEnumerable<ProductReadDto>>(produtos));
        }

        //GET api/produtos/{id}
        [HttpGet("{id}")]
        public ActionResult<ProductReadDto> GetProductById(int id)
        {
            var produto = _repository.GetProductById(id);
            
            return Ok(_mapper.Map<ProductReadDto>(produto));
        }
    }
}