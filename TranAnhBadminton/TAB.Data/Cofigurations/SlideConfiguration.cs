using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAB.Data.Entities;
using System.Drawing;

namespace TAB.Data.Configurations
{
    public class SlideConfiguration : IEntityTypeConfiguration<Slide>
    {
        public void Configure(EntityTypeBuilder<Slide> builder)
        {
            builder.ToTable("Slides");
            builder.HasKey(x => x.SlideId);

            builder.Property(x => x.SlideId).UseIdentityColumn();

            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Url).HasMaxLength(200).IsRequired();
            builder.Property(x => x.SortOrder).IsRequired();
            builder.Property(x => x.Image).HasMaxLength(200).IsRequired();
        }
    }
}