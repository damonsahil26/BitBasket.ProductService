using BitBasket.ProductService.BusinessLogic.DTO;
using BitBasket.ProductService.BusinessLogic.ServiceContracts;
using BitBasket.ProductService.BusinessLogic.Validators;
using FluentValidation;

namespace BitBasket.ProductService.API.APIEndpoints
{
    public static class ProductApiEndpoint
    {
        public static IEndpointRouteBuilder AddProductApiEndpoints(this IEndpointRouteBuilder builder)
        {
            builder.MapGet("api/products/", async (IProductService productService) =>
            {
                var allProducts = await productService.GetProducts();

                return Results.Ok(allProducts);
            });

            builder.MapPost("api/products/", async (IProductService productService,
                IValidator<ProductAddRequest> validator, ProductAddRequest productAddRequest) =>
            {
                var validationResult = await validator.ValidateAsync(productAddRequest);

                if (validationResult != null && !validationResult.IsValid)
                {
                    Dictionary<string, string[]> errors = validationResult.Errors
                    .GroupBy(temp => temp.PropertyName)
                    .ToDictionary(grp => grp.Key, grp => grp.Select(error => error.ErrorMessage).ToArray());

                    return Results.ValidationProblem(errors);
                }

                else
                {
                    var response = await productService.AddProduct(productAddRequest);
                    return Results.Ok(response);
                }
            });

            builder.MapPut("api/products", async (IProductService productService,
                IValidator<ProductUpdateRequest> validator,
                ProductUpdateRequest productUpdateRequest) =>
            {
                var validationResult = await validator.ValidateAsync(productUpdateRequest);
                if (validationResult != null && !validationResult.IsValid)
                {
                    Dictionary<string, string[]> errors = validationResult
                    .Errors.GroupBy(temp => temp.PropertyName)
                    .ToDictionary(grp => grp.Key, grp => grp.Select(error => error.ErrorMessage)
                    .ToArray());

                    return Results.ValidationProblem(errors);
                }
                else
                {
                    var response = await productService.UpdateProduct(productUpdateRequest);
                    return Results.Ok(response);
                }
            });

            builder.MapDelete("api/products/{productId}", async (IProductService productService,
                Guid productId) =>
            {
                var result = await productService.DeleteProduct(productId);

                return Results.Ok(result);
            });

            builder.MapGet("api/products/search/{searchString}", async (IProductService productService,
               string searchString) =>
            {
                var productsByName = await productService
                .GetProductsByConditionAsync(temp => temp.ProductName != null
                && temp.ProductName.Contains(searchString, StringComparison.InvariantCultureIgnoreCase));

                var productsByCategory = await productService.GetProductsByConditionAsync(temp => temp.Category != null
                && temp.Category.Contains(searchString, StringComparison.InvariantCultureIgnoreCase));

                var result = productsByName.Union(productsByCategory);
                return Results.Ok(result);
            });

            builder.MapGet("api/products/search/productId/{productId}", async (IProductService productService,
             Guid productId) =>
            {
                var product = await productService
                .GetProductByConditionAsync(temp => temp.ProductId == productId);

                return Results.Ok(product);
            });

            return builder;
        }
    }
}
