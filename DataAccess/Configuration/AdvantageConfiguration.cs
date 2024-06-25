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
    public class AdvantageConfiguration : IEntityTypeConfiguration<Advantage>
    {
        public void Configure(EntityTypeBuilder<Advantage> builder)
        {
            builder.ToTable("Advantages");

            builder.Property(x => x.ID)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_INCREMENT_VALUE, increment: 1);

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.IconName)
                .HasMaxLength(150)
                .IsRequired();

            builder.HasIndex(x => new { x.Name, x.Deleted })
                .IsUnique();
        }
    }
}
