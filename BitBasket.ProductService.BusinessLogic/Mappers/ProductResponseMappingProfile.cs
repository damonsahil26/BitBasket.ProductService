using AutoMapper;
using BitBasket.ProductService.BusinessLogic.DTO;
using BitBasket.ProductService.BusinessLogic.Enums;
using BitBasket.ProductService.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitBasket.ProductService.BusinessLogic.Mappers
{
    public class ProductResponseMappingProfile : Profile
    {
        public ProductResponseMappingProfile()
        {
            CreateMap<ProductResponse, Product>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId));

            CreateMap<ProductResponse, Product>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName));

            CreateMap<Product, ProductResponse>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));

            CreateMap<ProductResponse, Product>()
                .ForMember(dest => dest.QuantityInStock, opt => opt.MapFrom(src => src.QuantityInStock));

            CreateMap<ProductResponse, Product>()
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice));
        }
    }
}
