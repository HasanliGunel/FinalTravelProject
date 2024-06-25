using Core.DefaultValues;
using Entities.Concrete.TableModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration
{
    public class GuideConfiguration : IEntityTypeConfiguration<Guide>
    {
        public void Configure(EntityTypeBuilder<Guide> builder)
        {
            builder.ToTable("Guides");

            builder.Property(x => x.ID)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_INCREMENT_VALUE, increment: 1);

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.SurName)
               .HasMaxLength(50)
               .IsRequired();
            builder.Property(x => x.IsHome)
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(x => x.PhotoUrl)
               .HasMaxLength(200)
               .IsRequired();

            builder.Property(x => x.InstagramLink)
               .HasMaxLength(150)
               .IsRequired();

            builder.Property(x => x.FacebookLink)
               .HasMaxLength(150)
               .IsRequired();

            builder.Property(x => x.TwitterLink)
               .HasMaxLength(150)
               .IsRequired();

            builder.Property(x => x.LinkedInLink)
               .HasMaxLength(150)
               .IsRequired();

        }
    }
}
