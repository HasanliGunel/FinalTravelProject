using Core.DataAccess.Contrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModel;
using Entities.Concrete.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class TagDal : BaseRepository<Tag, ApplicationDbContext>, ITagDal
    {
        private ApplicationDbContext _context;

        public TagDal(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<TagVM> GetAllTagWithBlog()
        {
            var tags = (from tag in _context.Tags
                         where tag.Deleted == 0 
                         select new TagVM
                         {
                             ID = tag.ID,
                             Name = tag.Name,
                         }).ToList();

            if (tags == null && tags.Count == 0)
                return tags;

            foreach (var tag in tags)
            {
                tag.TagBlogVMs = GetBlogTagDetail(tag, tag.ID);
            }

            return tags;
        }

        private ICollection<TagBlogVM> GetBlogTagDetail(TagVM tag, int id)
        {
            var data = (from tagBlog in _context.TagBlogs
                        join b in _context.Blogs on tagBlog.BlogId equals b.ID
                        join t in _context.Tags on tagBlog.TagID equals t.ID
                        where t.ID == id && t.Deleted == 0 && tagBlog.Deleted == 0 && b.Deleted == 0
                        select new TagBlogVM
                        {
                            TagID = t.ID,
                            TagName = t.Name,
                            BlogId = b.ID,
                            CreateDate = b.CreateDate,
                            Title = b.Title,
                            Description = b.Description,
                            Text = b.Text,
                            PhotoUrl = b.PhotoUrl,

                        }).ToList();
            return data;
        }

        public TagVM GetByIDTagWithBlog(int id)
        {
            var tag = (from t in _context.Tags
                        where t.ID == id && t.Deleted == 0
                        select new TagVM
                        {
                            ID = t.ID,
                            Name = t.Name,
                        }).FirstOrDefault();
            if (tag == null)
                return null;
            tag.TagBlogVMs = GetBlogTagDetail(tag, id);

            return tag;
        }

    }
}
