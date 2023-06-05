using DecorationMarket.DbContext;
using DecorationMarket.Domain.DBModel;
using DecorationMarket.Persistence.Interface.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorationMarket.Persistence.Implementation.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Product>> GetProductsByCategory(int? categoryId, int page = 1)
        {
            return await dbContext.Products.Include(q => q.Image).Where(q => (categoryId == null || q.CategoryId == categoryId)).Skip((page - 1) * 12).Take(12).ToListAsync();
        }

        public async Task DecreaseQuantity(int productId, int quantityChange)
        {
            var product = await dbContext.Products.FirstOrDefaultAsync(q => q.Id == productId);
            product.Quantity += quantityChange;
        }

        public async Task<Product?> GetByIdAsync(int productId)
        {
            return await dbContext.Products.Include(q => q.Image).FirstOrDefaultAsync(q=>q.Id == productId);
        }
    }
}
