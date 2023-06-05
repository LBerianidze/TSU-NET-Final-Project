using DecorationMarket.Domain.DBModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorationMarket.Persistence.EntityConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.ToTable("Product");
            builder.Property(q => q.Name).IsRequired();
            builder.HasOne<Category>(q => q.Category).WithMany(a => a.Products).HasForeignKey(q => q.CategoryId);
            builder.HasOne<UploadedFile>(q => q.Image).WithOne(a => a.Product);
        }
    }
}
