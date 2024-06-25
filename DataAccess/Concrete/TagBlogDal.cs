using Core.DataAccess.Contrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.TableModel;
using Entities.Concrete.ViewModel;

namespace DataAccess.Concrete
{
    public class TagBlogDal : BaseRepository<TagBlog, ApplicationDbContext>, ITagBlogDal
    {
        private ApplicationDbContext _context;

        public TagBlogDal(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<TagBlogVM> GetAllBlogTag()
        {
            var classTeacherList = (from tb in _context.TagBlogs
                                    join b in _context.Blogs on tb.BlogId equals b.ID
                                    join t in _context.Tags on tb.TagID equals t.ID
                                    where tb.Deleted == 0 && b.Deleted == 0 && t.Deleted == 0
                                    select new TagBlogVM
                                    {
                                        ID = tb.ID,
                                        TagID = t.ID,
                                        TagName = t.Name,
                                        BlogId = b.ID,
                                        Title = b.Title
                                    }).ToList();

            return classTeacherList;
        }

        public TagBlogVM GetByIDBlogTag(int id)
        {
            var classTeacher = (from tb in _context.TagBlogs
                                join b in _context.Blogs on tb.BlogId equals b.ID
                                join t in _context.Tags on tb.TagID equals t.ID
                                where tb.ID == id && tb.Deleted == 0 && b.Deleted == 0 && t.Deleted == 0
                                select new TagBlogVM
                                {
                                    TagID = t.ID,
                                    TagName = t.Name,
                                    BlogId = b.ID,
                                    Title = b.Title
                                }).FirstOrDefault();

            return classTeacher;
        }
    }
}
