using System;
using System.Collections.Generic;
using AutoMapper;
using ProductManagementApi.Data;
using ProductManagementApi.Dtos;
using ProductManagementApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;

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
        /// <summary>
        /// Get all the products available for sale
        /// </summary>
        /// <returns>A list of products</returns>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<ProductReadDto>> GetAllProducts()
        {
            try
            {
                var products = _repository.GetProducts();
                if(products == null)
                    return BadRequest();

                return Ok(_mapper.Map<IEnumerable<ProductShowDto>>(products));
            }
            catch(Exception)
            {
                return BadRequest("Ocorreu um erro desconhecido");
            }
        }

        //GET api/produtos/{id}
        /// <summary>
        /// Get a product by id with date and value of last sale
        /// </summary>
        /// <param name="id">Product id</param>
        /// <returns>A product</returns>
        [HttpGet("{id:int}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ProductShowOneDto> GetProductByIdWithLastSale([FromRoute] int id)
        {
            try
            {
                var product = _repository.GetProductByIdWithLastSale(id);
                if(product == null)
                {
                    var productModel = _repository.GetProductById(id);
                    product = _mapper.Map(productModel, product);
                    
                }

                if(product == null)
                    return BadRequest();

                return Ok(_mapper.Map<ProductShowOneDto>(product));
            }
            catch(Exception)
            {
                return BadRequest("Ocorreu um erro desconhecido");
            }
        }

        //POST api/produtos
        /// <summary>
        /// Create a new product
        /// </summary>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ProductReadDto> CreateProduct([FromBody] ProductCreateDto productCreateDto)
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
        /// <summary>
        /// Remove a product from the database
        /// </summary>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult DeleteProduct([FromRoute] int id)
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