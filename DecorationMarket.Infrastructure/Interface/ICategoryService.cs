using DecorationMarket.Domain.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorationMarket.Core.Interface
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategoriesAsync();
    }
}
