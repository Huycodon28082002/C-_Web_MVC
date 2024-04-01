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
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transactions");

            builder.HasKey(x => x.TransactionId);

            builder.Property(x => x.TransactionId).UseIdentityColumn();

            builder.Property(x => x.TransactionDate).IsRequired();
            builder.Property(x => x.ExternalTransactionId);
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.Fee).IsRequired();
            builder.Property(x => x.Result);
            builder.Property(x => x.Message);
            builder.Property(x => x.Status);
            builder.Property(x => x.Provider);


            builder.HasOne(x => x.User).WithMany(x => x.Transactions).HasForeignKey(x => x.UserId);

        }
    }
}