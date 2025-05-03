using BitBasket.ProductService.API.Middlewares;
using BitBasket.ProductService.BusinessLogic;
using BitBasket.ProductService.DataAccess;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddDataAccessServices(builder.Configuration);
builder.Services.AddBusinessLogicServices();
builder.Services.AddControllers()
    .AddJsonOptions(options => 
    options.JsonSerializerOptions
    .Converters.Add(new JsonStringEnumConverter()));


app.UseExceptionHandlingMiddleware();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
