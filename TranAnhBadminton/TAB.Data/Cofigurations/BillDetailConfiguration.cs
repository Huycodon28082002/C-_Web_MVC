    using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAB.Data.Entities;

namespace TAB.Data.Configurations
{
    public class BillDetailConfiguration : IEntityTypeConfiguration<BillDetail>
    {
        public void Configure(EntityTypeBuilder<BillDetail> builder)
        {
            builder.ToTable("Bill Details");

            builder.HasKey(x => new { x.ProductId, x.BillId });

            builder.Property(x => x.ProductName).IsRequired().HasMaxLength(200);

            builder.Property(x => x.Count).IsRequired();

            builder.Property(x => x.Price).IsRequired();

            builder.Property(x => x.TotalPrice).IsRequired();

            builder.HasOne(p => p.Product).WithMany(bd => bd.BillDetails)
                .HasForeignKey(p => p.ProductId);

            builder.HasOne(b => b.Bill).WithMany(bd => bd.BillDetails)
                .HasForeignKey(b => b.BillId);
        }
    }
}