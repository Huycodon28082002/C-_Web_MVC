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
    public class PromotionConfiguration : IEntityTypeConfiguration<Promotion>
    {
        public void Configure(EntityTypeBuilder<Promotion> builder)
        {
            builder.ToTable("Promotions");

            builder.HasKey(x => x.PromotionId);
            builder.Property(x => x.PromotionId).UseIdentityColumn();

            builder.Property(x => x.PromotionName).IsRequired().HasMaxLength(300);
            builder.Property(x => x.StartDay).IsRequired();
            builder.Property(x => x.EndDay).IsRequired();
            builder.Property(x => x.Status).HasDefaultValue(Status.Active);

        }

    }
}
