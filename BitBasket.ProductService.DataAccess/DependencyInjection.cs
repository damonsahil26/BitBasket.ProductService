using BitBasket.ProductService.DataAccess.AppDbContext;
using BitBasket.ProductService.DataAccess.Repositories;
using BitBasket.ProductService.DataAccess.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitBasket.ProductService.DataAccess
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            var sqlConnectionStringTemplate = configuration.GetConnectionString("DefaultConnection")!;

            var sqlConnectionString = sqlConnectionStringTemplate
                .Replace("$MYSQL_HOST", Environment.GetEnvironmentVariable("MYSQL_HOST"))
                .Replace("$MYSQL_PASSWORD", Environment.GetEnvironmentVariable("MYSQL_PASSWORD"));

            services.AddDbContext<ApplicationDbContext>(options => 
            options.UseMySQL(sqlConnectionString));

            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
