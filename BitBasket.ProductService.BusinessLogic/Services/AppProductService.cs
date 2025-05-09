using AutoMapper;
using BitBasket.ProductService.BusinessLogic.DTO;
using BitBasket.ProductService.BusinessLogic.ServiceContracts;
using BitBasket.ProductService.DataAccess.Entities;
using BitBasket.ProductService.DataAccess.RepositoryContracts;
using System.Linq.Expressions;

namespace BitBasket.ProductService.BusinessLogic.Services
{
    public class AppProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public AppProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductResponse?> AddProduct(ProductAddRequest productAddRequest)
        {
            var product = _mapper.Map<ProductAddRequest, Product>(productAddRequest);
            var result = await _productRepository.AddProduct(product);

            return _mapper.Map<ProductResponse>(result);
        }

        public Task<bool> DeleteProduct(Guid productId)
        {
            return _productRepository.DeleteProduct(productId);
        }

        public async Task<ProductResponse?> GetProductByConditionAsync(Expression<Func<Product, bool>> conditionExpression)
        {
            var product = await _productRepository.GetProductByConditionAsync(conditionExpression);
            return _mapper.Map<ProductResponse>(product);
        }

        public async Task<List<ProductResponse?>> GetProducts()
        {
            var products = await _productRepository.GetProductsAsync();
            return _mapper.Map<List<ProductResponse?>>(products);
        }

        public async Task<List<ProductResponse?>> GetProductsByConditionAsync(Expression<Func<Product, bool>> conditionExpression)
        {
            var products = await _productRepository.GetProductsByConditionAsync(conditionExpression);
            return _mapper.Map<List<ProductResponse?>>(products);
        }

        public async Task<ProductResponse?> UpdateProduct(ProductUpdateRequest productUpdateRequest)
        {
            var product = _mapper.Map<Product>(productUpdateRequest);
            var updatedProduct = await _productRepository.UpdateProduct(product);

            var productResponse = _mapper.Map<ProductResponse>(updatedProduct);

            return productResponse;
        }
    }
}
