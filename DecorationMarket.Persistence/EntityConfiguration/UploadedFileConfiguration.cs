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
    public class UploadedFileConfiguration : IEntityTypeConfiguration<UploadedFile>
    {
        public void Configure(EntityTypeBuilder<UploadedFile> builder)
        {
            builder.HasKey(p => p.Id);
            builder.ToTable("UploadedFile");
            builder.Property(q => q.FileName).IsRequired();
            builder.Property(q => q.CreateDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
