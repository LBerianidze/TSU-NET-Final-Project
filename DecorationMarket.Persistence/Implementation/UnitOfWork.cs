using DecorationMarket.DbContext;
using DecorationMarket.Persistence.Implementation.Repositories;
using DecorationMarket.Persistence.Interface;
using DecorationMarket.Persistence.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorationMarket.Persistence.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _dbContext;
        public ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public UnitOfWork(ICategoryRepository categoryRepository, IProductRepository productRepository, IOrderRepository orderRepository, ApplicationDbContext dbContext)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _dbContext = dbContext;
        }
        public ICategoryRepository CategoryRepository => _categoryRepository;
        public IProductRepository ProductRepository => _productRepository;
        public IOrderRepository OrderRepository => _orderRepository;
        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
