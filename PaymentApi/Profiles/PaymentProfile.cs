using AutoMapper;
using PaymentApi.Dtos;
using PaymentApi.Models;

namespace PaymentApi.Profiles
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<Payment, PaymentShowDto>();
            CreateMap<PaymentReadDto, Payment>();
        }
    }
}