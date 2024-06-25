using Core.DefaultValues;
using Entities.Concrete.TableModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;

namespace DataAccess.Configuration
{
    public class DestinationConfiguration : IEntityTypeConfiguration<Destination>
    {
        public void Configure(EntityTypeBuilder<Destination> builder)
        {
            builder.ToTable("Destinations");

            builder.Property(x => x.ID)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_INCREMENT_VALUE, increment: 1);

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.PhotoUrl)
                .HasMaxLength (200)
                .IsRequired();

            builder.Property(x => x.IsHomePage)
                .HasDefaultValue(false)
                .IsRequired();

            builder.HasIndex(x => new { x.Name, x.Deleted })
                .IsUnique();

            
        }
    }
}
