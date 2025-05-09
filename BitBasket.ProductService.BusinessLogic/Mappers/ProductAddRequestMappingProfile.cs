using AutoMapper;
using BitBasket.ProductService.BusinessLogic.DTO;
using BitBasket.ProductService.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitBasket.ProductService.BusinessLogic.Mappers
{
    public class ProductAddRequestMappingProfile : Profile
    {
        public ProductAddRequestMappingProfile()
        {
            CreateMap<ProductAddRequest, Product>()
                .ForMember(dest => dest.ProductId, opt => opt.Ignore());

            CreateMap<ProductAddRequest, Product>()
               .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName));

            CreateMap<ProductAddRequest, Product>()
              .ForMember(dest => dest.QuantityInStock, opt => opt.MapFrom(src => src.QuantityInStock));

            CreateMap<ProductAddRequest, Product>()
              .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice));

            CreateMap<ProductAddRequest, Product>()
              .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));
        }
    }
}
