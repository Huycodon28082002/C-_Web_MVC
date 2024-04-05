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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            // builder.HasKey(x => x.Id);
            // builder.Property(x => x.Id).UseIdentityColumn().IsRequired();
            builder.Property(x => x.Dob).IsRequired();
            builder.Property(x => x.Email).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Address);
            builder.Property(x => x.Avatar);
            builder.Property(x => x.Password).IsRequired();
            // builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(11);
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(200);

        }
    }
}