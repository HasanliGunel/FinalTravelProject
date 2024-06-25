using Core.DataAccess.Contrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModel;
using Entities.Concrete.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class CategoryOfBlogDal : BaseRepository<CategoryOfBlog, ApplicationDbContext>, ICategoryOfBlogDal
    {
        private ApplicationDbContext _context;

        public CategoryOfBlogDal(ApplicationDbContext context)
        {
            _context = context;
        }
        private ICollection<TagBlogVM> GetBlogTagDetail(TagVM tag, int id)
        {
            var data = (from t in _context.CategoryOfBlogs
                        join b in _context.Blogs on t.ID equals b.CategoryOfBlogID
                        where t.ID == id && t.Deleted == 0 && b.Deleted == 0
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
                            CategoryName = t.Name
                        }).ToList();
            return data;
        }

        public TagVM GetByIDCategoryWithBlog(int id)
        {
            var tag = (from t in _context.CategoryOfBlogs
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
