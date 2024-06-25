using Core.DefaultValues;
using Entities.Concrete.TableModel;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Configuration
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Blog> builder)
        {
            builder.ToTable("Blogs");

            builder.Property(x => x.ID)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_INCREMENT_VALUE, increment: 1);

            builder.Property(x => x.Title)
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.PhotoUrl)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.Text)
                .HasMaxLength(5000)
                .IsRequired();

            builder.Property(x => x.IsHome)
                .HasDefaultValue(false)
                .IsRequired();

            builder.HasOne(x => x.CategoryOfBlog)
                .WithMany(x => x.Blogs)
                .HasForeignKey(x => x.CategoryOfBlogID);
        }
    }
}
