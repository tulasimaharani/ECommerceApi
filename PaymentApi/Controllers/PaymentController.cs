using System;
using AutoMapper;
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
        [HttpPost]
        public ActionResult<PaymentShowDto> ApprovePayment(PaymentReadDto paymentReadDto)
        {
            try
            {
                var paymentModel = _mapper.Map<Payment>(paymentReadDto);

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