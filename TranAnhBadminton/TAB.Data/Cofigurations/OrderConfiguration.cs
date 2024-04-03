using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAB.Data.Entities;

namespace TAB.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(x => x.OrderId);

            builder.Property(x => x.OrderId).UseIdentityColumn();

            builder.Property(x => x.OrderDate);

            builder.Property(x => x.ShipEmail).IsRequired().IsUnicode(false).HasMaxLength(100);

            builder.Property(x => x.ShipAddress).IsRequired().HasMaxLength(500);


            builder.Property(x => x.ShipName).IsRequired().HasMaxLength(100);


            builder.Property(x => x.ShipPhoneNumber).IsRequired().HasMaxLength(11);

            builder.HasOne(x => x.User).WithMany(x => x.Orders).HasForeignKey(x => x.UserId);

        }
    }
}