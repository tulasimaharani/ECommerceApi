using AutoMapper;
using ProductManagementApi.Data;
using ProductManagementApi.Dtos;
using ProductManagementApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;

namespace ProductManagementApi.Controllers
{
    [Route("api/compras")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private IProductManagerRepository _repository;
        private IMapper _mapper;

        public SaleController(IProductManagerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //POST api/compras
        /// <summary>
        /// Sell a product
        /// </summary>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult SellProducts(Sale sale)
        {
            try
            {
                var id = sale.ProdutoId;
                var productModel = _repository.GetProductById(id);

                if(productModel == null)
                {
                    return BadRequest("Os valores informados não são válidos");
                }

                var productCreateDto = _mapper.Map<ProductCreateDto>(productModel);
                productCreateDto.QuantidadeEstoque -= sale.QuantidadeComprada;
                sale.Data = DateTime.Now;
                sale.Valor = sale.QuantidadeComprada * productCreateDto.ValorUnitario;

                _mapper.Map(productCreateDto, productModel);
                _repository.SellProduct(sale); 
                _repository.SaveChanges();

                return Ok("Venda realizada com sucesso");
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
    }
}