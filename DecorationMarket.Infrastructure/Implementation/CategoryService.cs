using DecorationMarket.Domain.DBModel;
using DecorationMarket.Core.Interface;
using DecorationMarket.Persistence.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorationMarket.Core.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await unitOfWork.CategoryRepository.GetCategoriesAsync();
        }
    }
}
