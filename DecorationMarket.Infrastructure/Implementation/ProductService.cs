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
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<List<Product>> GetProducts(string categoryCode, int page)
        {
            int? categoryId = null;
            if (categoryCode != null)
            {
                var category = await unitOfWork.CategoryRepository.GetByCode(categoryCode);
                if (category == null) throw new Exception("Bad category");
                categoryId = category.Id;
            }
            return await unitOfWork.ProductRepository.GetProductsByCategory(categoryId,page);
        }
    }
}
