using Core.DefaultValues;
using Entities.Concrete.TableModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration
{
    public class PackageConfiguration : IEntityTypeConfiguration<Package>
    {
        public void Configure(EntityTypeBuilder<Package> builder)
        {

            builder.ToTable("Packages");

            builder.Property(x => x.ID)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_INCREMENT_VALUE, increment: 1);

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Duration)
                .IsRequired();

            builder.Property(x => x.PeopleCount)
                .IsRequired();

            builder.Property(x => x.Price)
                .HasPrecision(7,2)
                .IsRequired();

            builder.Property(x => x.PhotoUrl)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.IsHome)
                .HasDefaultValue(false)
                .IsRequired();

            builder.HasOne(x => x.Destination)
                .WithMany(x => x.Packages)
                .HasForeignKey(x => x.DestinationID);
        }
    }
}
