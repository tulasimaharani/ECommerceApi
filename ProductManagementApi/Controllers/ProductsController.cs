using System;
using System.Collections.Generic;
using AutoMapper;
using ProductManagementApi.Data;
using ProductManagementApi.Dtos;
using ProductManagementApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagementApi.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductManagerRepository _repository;
        private readonly IMapper _mapper;

        public ProductsController(IProductManagerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        //GET api/produtos
        [HttpGet]
        public ActionResult<IEnumerable<ProductReadDto>> GetAllProducts()
        {
            try
            {
                var products = _repository.GetProducts();

                return Ok(_mapper.Map<IEnumerable<ProductShowDto>>(products));
            }
            catch(Exception)
            {
                return BadRequest("Ocorreu um erro desconhecido");
            }
        }

        //GET api/produtos/{id}
        [HttpGet("{id}")]
        public ActionResult<ProductReadDto> GetProductById(int id)
        {
            try
            {
                var product = _repository.GetProductById(id);
                
                return Ok(_mapper.Map<ProductReadDto>(product));
            }
            catch(Exception)
            {
                return BadRequest("Ocorreu um erro desconhecido");
            }
        }

        //POST api/produtos
        [HttpPost]
        public ActionResult<ProductReadDto> CreateProduct(ProductCreateDto productCreateDto)
        {
            try
            {
                var productModel = _mapper.Map<Product>(productCreateDto);
                _repository.CreateProduct(productModel);
                _repository.SaveChanges();
                
                return Ok("Produto Cadastrado");
            }
            catch(ArgumentException)
            {
                throw new ArgumentException("Os valores informados não são válidos");
            }
            catch(Exception)
            {
                return BadRequest("Ocorreu um erro desconhecido");
            }
                        
        }

        //DELETE api/produtos/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            try
            {
                var storedProduct = _repository.GetProductById(id);
                if(storedProduct == null)
                {
                    return BadRequest();
                }
                _repository.DeleteProduct(storedProduct);
                _repository.SaveChanges();

                return Ok("Produto excluído com sucesso");
            }
            catch(Exception)
            {
                return BadRequest("Ocorreu um erro desconhecido");
            }
        }
    }
}