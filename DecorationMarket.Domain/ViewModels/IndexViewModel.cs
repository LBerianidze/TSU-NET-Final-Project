using DecorationMarket.Domain.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorationMarket.Domain.ViewModels
{
    public class IndexViewModel
    {
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
    }
}
