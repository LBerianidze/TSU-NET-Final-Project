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
    public interface IProductRepository
    {
        public Task<List<Product>> GetProductsByCategory(int? categoryId, int page = 1);
        public Task DecreaseQuantity(int productId, int quantityChange);
        public Task<Product> GetByIdAsync(int productId);
    }
}
