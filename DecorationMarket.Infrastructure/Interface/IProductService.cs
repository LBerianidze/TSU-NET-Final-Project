using DecorationMarket.Domain.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorationMarket.Core.Interface
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts(string categoryCode, int page);
    }
}
