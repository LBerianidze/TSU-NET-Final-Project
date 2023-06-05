using DecorationMarket.Domain.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorationMarket.Persistence.Interface.Repositories
{
    public interface IOrderRepository
    {
        Task InsertOrder(Order order);
        Task<List<Order>> GetByUserId(string userId);

    }
}
