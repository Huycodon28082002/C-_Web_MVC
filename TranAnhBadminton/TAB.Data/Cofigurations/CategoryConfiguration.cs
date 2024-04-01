using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAB.Data.Entities;
using TAB.Data.Enums;

namespace TAB.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(x => x.CategoryId);

            builder.Property(x => x.CategoryId).UseIdentityColumn();
            builder.Property(x => x.CategoryName).IsRequired().HasMaxLength(200);
            builder.Property(x=>x.BrandId).IsRequired();
            builder.Property(x => x.Status).HasDefaultValue(Status.Active);

            builder.HasOne(b => b.Brand).WithMany(c => c.Categories).HasForeignKey(b=>b.BrandId);
        }

    }
}