using BitBasket.ProductService.DataAccess.AppDbContext;
using BitBasket.ProductService.DataAccess.Entities;
using BitBasket.ProductService.DataAccess.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BitBasket.ProductService.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Product?> AddProduct(Product product)
        {
            _applicationDbContext.Products.Add(product);
            await _applicationDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProduct(Guid productId)
        {
           var product = _applicationDbContext.Products.Where(x=>x.ProductId == productId).FirstOrDefault();

            if (product != null)
            {
                _applicationDbContext.Products.Remove(product);
                await _applicationDbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<Product?> GetProductByConditionAsync(Expression<Func<Product, bool>> conditionExpression)
        {
            return await _applicationDbContext.Products.FirstOrDefaultAsync(conditionExpression);
        }

        public async Task<IEnumerable<Product?>> GetProductsAsync()
        {
            return await _applicationDbContext.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product?>> GetProductsByConditionAsync(Expression<Func<Product, bool>> conditionExpression)
        {
            return await _applicationDbContext.Products
                .Where(conditionExpression)
                .ToListAsync();
        }

        public async Task<Product?> UpdateProduct(Product product)
        {
            var productFromDb = await _applicationDbContext.Products
                .Where(x => x.ProductId.Equals(product.ProductId))
                .FirstOrDefaultAsync();

            if (productFromDb != null)
            {
                productFromDb.ProductId = product.ProductId;
                productFromDb.ProductName = product.ProductName;
                productFromDb.UnitPrice = product.UnitPrice;
                productFromDb.QuantityInStock = product.QuantityInStock;
                productFromDb.Category = product.Category;
                _applicationDbContext.Update(productFromDb);
                await _applicationDbContext.SaveChangesAsync();
                return product;
            }

            else
            {
                return null;
            }
        }
    }
}
