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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await dbContext.Categories.ToListAsync();
        }
        public async Task<Category> GetById(int id)
        {
            return await dbContext.Categories.FirstOrDefaultAsync(q => q.Id == id);
        }
        public async Task<Category> GetByCode(string code) => await dbContext.Categories.FirstOrDefaultAsync(q => q.Code == code);
    }
}
