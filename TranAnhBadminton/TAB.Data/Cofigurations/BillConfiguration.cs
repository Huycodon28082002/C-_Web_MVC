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
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("Bills");

            builder.HasKey(x => x.BillId);

            builder.Property(x => x.BillId).UseIdentityColumn();

            builder.Property(x => x.UserId).IsRequired();

            builder.Property(x => x.DateCreated).IsRequired();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            builder.HasOne(a => a.User).WithMany(b => b.Bills).HasForeignKey(b => b.UserId);

        }
    }
}