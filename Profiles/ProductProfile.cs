using AutoMapper;
using ECommerceApi.Models;
using ECommerceApi.Dtos;

namespace ECommerceApi.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductReadDto>();
        }
    }
}