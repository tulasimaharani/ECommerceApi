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
            CreateMap<Product, ProductCreateDto>();
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductShowDto, Product>();
            CreateMap<Product, ProductShowDto>();
            CreateMap<Product, ProductShowOneDto>();
        }
    }
}