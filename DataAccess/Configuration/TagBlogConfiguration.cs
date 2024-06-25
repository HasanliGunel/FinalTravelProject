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
    public class TagBlogConfiguration : IEntityTypeConfiguration<TagBlog>
    {
        public void Configure(EntityTypeBuilder<TagBlog> builder)
        {
            builder.ToTable("TagBlogs");
            builder.Property(x => x.ID)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_INCREMENT_VALUE, increment: 1);

            builder.HasIndex(x => new { x.BlogId, x.TagID });

            builder.HasOne(x => x.Blog)
                .WithMany(x => x.TagBlogs)
                .HasForeignKey(x => x.BlogId);

            builder.HasOne(x => x.Tag)
                .WithMany(x => x.TagBlogs)
                .HasForeignKey(x => x.TagID);



        }
    }
}
