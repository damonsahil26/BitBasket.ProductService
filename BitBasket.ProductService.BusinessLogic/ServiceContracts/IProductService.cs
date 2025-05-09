using BitBasket.ProductService.BusinessLogic.DTO;
using BitBasket.ProductService.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BitBasket.ProductService.BusinessLogic.ServiceContracts
{
    public interface IProductService
    {
        public Task<List<ProductResponse?>> GetProducts();
        public Task<List<ProductResponse?>> GetProductsByConditionAsync(Expression<Func<Product, bool>> conditionExpression);
        public Task<ProductResponse?> GetProductByConditionAsync(Expression<Func<Product, bool>> conditionExpression);
        public Task<ProductResponse?> AddProduct(ProductAddRequest productAddRequest);
        public Task<ProductResponse?> UpdateProduct(ProductUpdateRequest productUpdateRequest);
        public Task<bool> DeleteProduct(Guid productId);
    }
}
