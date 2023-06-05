using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecorationMarket.Persistence.Implementation.Repositories;
using DecorationMarket.Persistence.Interface.Repositories;

namespace DecorationMarket.Persistence.Interface
{
    public interface IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public Task SaveAsync();
    }
}
