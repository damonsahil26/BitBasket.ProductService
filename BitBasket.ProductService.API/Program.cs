using BitBasket.ProductService.API.APIEndpoints;
using BitBasket.ProductService.API.Middlewares;
using BitBasket.ProductService.BusinessLogic;
using BitBasket.ProductService.DataAccess;
using FluentValidation.AspNetCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDataAccessServices(builder.Configuration);
builder.Services.AddBusinessLogicServices();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    options.JsonSerializerOptions
    .Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddFluentValidationAutoValidation();

var app = builder.Build();

app.UseExceptionHandlingMiddleware();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.AddProductApiEndpoints();

app.Run();
