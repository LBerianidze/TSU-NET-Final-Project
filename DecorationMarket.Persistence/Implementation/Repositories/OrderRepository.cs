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
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext dbContext;

        public OrderRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task InsertOrder(Order order)
        {
            await dbContext.Orders.AddAsync(order);
        }
        public async Task<List<Order>> GetByUserId(string userId)
        {
            return await dbContext.Orders.Include(q => q.OrderItems).ThenInclude(f => f.Product).ThenInclude(q => q.Image).Where(f => f.User.Id == userId).ToListAsync();
        }
    }
}
