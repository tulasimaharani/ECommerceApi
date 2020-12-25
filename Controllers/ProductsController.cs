using System;
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
            var products = _repository.GetProducts();

            return Ok(_mapper.Map<IEnumerable<ProductReadDto>>(products));
        }

        //GET api/produtos/{id}
        [HttpGet("{id}")]
        public ActionResult<ProductReadDto> GetProductById(int id)
        {
            var product = _repository.GetProductById(id);
            
            return Ok(_mapper.Map<ProductReadDto>(product));
        }

        //POST api/produtos
        [HttpPost]
        public ActionResult<ProductReadDto> CreateProduct(ProductCreateDto productCreateDto)
        {
            var productModel = _mapper.Map<Product>(productCreateDto);
            _repository.CreateProduct(productModel);
            _repository.SaveChanges();
            
            return Ok(_mapper.Map<ProductReadDto>(productModel));            
        }
    }
}