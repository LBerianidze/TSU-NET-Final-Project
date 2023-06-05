using DecorationMarket.Domain.Enum;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorationMarket.Domain.DBModel
{
    public class Order
    {
        public int Id { get; set; }
        public User User { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreateDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
