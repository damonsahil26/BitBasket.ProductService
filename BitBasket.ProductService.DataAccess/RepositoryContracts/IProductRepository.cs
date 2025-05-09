using BitBasket.ProductService.DataAccess.Entities;
using System.Linq.Expressions;

namespace BitBasket.ProductService.DataAccess.RepositoryContracts
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product?>> GetProductsAsync();
        public Task<IEnumerable<Product?>> GetProductsByConditionAsync(Expression<Func<Product, bool>> conditionExpression);
        public Task<Product?> GetProductByConditionAsync(Expression<Func<Product, bool>> conditionExpression);
        public Task<Product?> AddProduct(Product product);
        public Task<Product?> UpdateProduct(Product product);
        public Task<bool> DeleteProduct(Guid productId);
    }
}
