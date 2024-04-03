using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAB.Data.Entities;
using TAB.Data.Enums;

namespace TAB.Data.Cofigurations
{
    public class PromotionDetailConfiguration : IEntityTypeConfiguration<PromotionDetail>
    {
        public void Configure(EntityTypeBuilder<PromotionDetail> builder)
        {
            builder.ToTable("Promotion Details");

            builder.HasKey(x => new { x.ProductId, x.PromotionId });

            builder.Property(x => x.ApplyForAll);

            builder.Property(x => x.DiscountPercent).IsRequired();

            builder.Property(x => x.DiscountAmount).IsRequired();

            builder.Property(x => x.Status).HasDefaultValue(Status.Active);

            builder.HasOne(p => p.Product).WithMany(bd => bd.PromotionDetails)
                .HasForeignKey(p => p.ProductId);

            builder.HasOne(b => b.Promotion).WithMany(bd => bd.PromotionDetails)
                .HasForeignKey(b => b.PromotionId);
        }
    }
}
