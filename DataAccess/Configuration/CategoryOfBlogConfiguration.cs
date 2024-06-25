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
    public class CategoryOfBlogConfiguration : IEntityTypeConfiguration<CategoryOfBlog>
    {
        public void Configure(EntityTypeBuilder<CategoryOfBlog> builder)
        {
            builder.ToTable("CategoryBlogs");

            builder.Property(x => x.ID)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_INCREMENT_VALUE, increment:1) ;

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(x => x.Name);

            builder.HasIndex(x => new { x.Name, x.Deleted })
                .IsUnique();
        }
    }
}
