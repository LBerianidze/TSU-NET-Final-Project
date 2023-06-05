using DecorationMarket.Domain.DBModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorationMarket.Persistence.EntityConfiguration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(p => p.Id);
            builder.ToTable("Order");
            builder.HasMany<OrderItem>(q => q.OrderItems).WithOne(q => q.Order).HasForeignKey(q=>q.OrderId);
            builder.Property(q=>q.CreateDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
