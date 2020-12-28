using System;
using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentApi.Data;
using PaymentApi.Dtos;
using PaymentApi.Models;

namespace PaymentApi.Controllers
{
    [Route("api/pagamento/compras")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private IPaymentRepository _repository;
        private IMapper _mapper;

        public PaymentController(IPaymentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //POST api/pagamento/compras
        /// <summary>
        /// Approve the payment of a sale
        /// </summary>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<PaymentShowDto> ApprovePayment([FromBody] PaymentReadDto paymentCreateDto)
        {
            try
            {
                var paymentModel = _mapper.Map<Payment>(paymentCreateDto);

                if(paymentModel.Valor >= 100)
                {
                    paymentModel.Estado = "APROVADO";
                }
                else
                {
                    paymentModel.Estado = "REJEITADO";
                } 
                
                paymentModel = _repository.PersistPayment(paymentModel);
                
                _repository.SaveChanges();

                return Ok(_mapper.Map<PaymentShowDto>(paymentModel));
            }
            catch
            {
                return BadRequest();
            }           
        }
    }
}