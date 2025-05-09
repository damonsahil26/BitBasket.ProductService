using BitBasket.ProductService.BusinessLogic.Mappers;
using BitBasket.ProductService.BusinessLogic.ServiceContracts;
using BitBasket.ProductService.BusinessLogic.Services;
using BitBasket.ProductService.BusinessLogic.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BitBasket.ProductService.BusinessLogic
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProductMappingProfile).Assembly);
            services.AddScoped<IProductService, AppProductService>();
            services.AddValidatorsFromAssemblyContaining(typeof(ProductAddRequestValidator));
            return services;
        }
    }
}
