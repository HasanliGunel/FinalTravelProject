using Core.DefaultValues;
using Entities.Concrete.TableModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration
{
    public class HomeSlideConfiguration : IEntityTypeConfiguration<HomeSlide>
    {
        public void Configure(EntityTypeBuilder<HomeSlide> builder)
        {
            builder.ToTable("HomeSlides");

            builder.Property(x => x.ID)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_INCREMENT_VALUE, increment: 1);

            builder.Property(x => x.Description)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.PhotoUrl)
                .HasMaxLength(200)
                .IsRequired();

            builder.HasIndex(x => x.Description)
                .IsUnique();
        }
    }
}
