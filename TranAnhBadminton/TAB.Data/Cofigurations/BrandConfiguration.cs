using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAB.Data.Entities;
using TAB.Data.Enums;

namespace TAB.Data.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brands");

            builder.HasKey(x => x.BrandId);

            builder.Property(x => x.BrandId).UseIdentityColumn();

            builder.Property(x => x.BrandName).IsRequired().HasMaxLength(100);

            builder.Property(x => x.Address).IsRequired().HasMaxLength(500);

            builder.Property(x => x.NumberPhone).HasMaxLength(15);

            builder.Property(x => x.Status).IsRequired().HasDefaultValue(Status.Active);

        }
    }
}