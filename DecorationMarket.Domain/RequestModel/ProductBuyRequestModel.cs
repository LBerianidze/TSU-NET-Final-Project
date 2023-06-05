using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorationMarket.Domain.RequestModel
{
    public class ProductBuyRequestModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
