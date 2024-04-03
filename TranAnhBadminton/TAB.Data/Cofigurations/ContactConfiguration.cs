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
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts");
            builder.HasKey(x => x.ContactId);

            builder.Property(x => x.ContactId).UseIdentityColumn();

            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();

            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();
            builder.Property(x => x.PhoneNumber).HasMaxLength(11).IsRequired();
            builder.Property(x => x.Message).IsRequired();


        }
    }
}