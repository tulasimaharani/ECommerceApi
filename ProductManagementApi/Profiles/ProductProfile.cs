using AutoMapper;
using ProductManagementApi.Models;
using ProductManagementApi.Dtos;

namespace ProductManagementApi.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductReadDto>();
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductShowDto, Product>();
            CreateMap<Product, ProductShowDto>();
        }
    }
}