using Core.DefaultValues;
using Entities.Concrete.TableModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts");

            builder.Property(x => x.ID)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_INCREMENT_VALUE, increment: 1);

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Subject)
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(x => x.Message)
                .HasMaxLength(2000)
                .IsRequired();

            builder.Property(x => x.IsContacted)
                .HasDefaultValue(0);

            builder.HasIndex(x => x.Email);

            builder.HasIndex(x => x.Deleted)
                .IsUnique();
        }
    }
}
