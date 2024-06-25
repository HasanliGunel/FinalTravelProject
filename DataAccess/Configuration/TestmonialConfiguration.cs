using Core.DefaultValues;
using Entities.Concrete.TableModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configuration
{
    public class TestmonialConfiguration : IEntityTypeConfiguration<Testimonial>
    {
        public void Configure(EntityTypeBuilder<Testimonial> builder)
        {
            builder.ToTable("Testimonials");

            builder.Property(x => x.ID)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_INCREMENT_VALUE, increment: 1);

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Comment)
                .HasMaxLength(2000)
                .IsRequired();

            builder.Property(x => x.PhotoUrl)
                .HasMaxLength(200)
                .IsRequired();

            builder.HasIndex(x => x.Name);

            builder.Property(x => x.IsHome)
                .HasDefaultValue(false)
                .IsRequired();
        }
    }
}
