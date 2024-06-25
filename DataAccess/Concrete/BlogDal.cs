using Core.DataAccess.Contrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModel;
using Entities.Concrete.ViewModel;
using System.ComponentModel;

namespace DataAccess.Concrete
{
    public class BlogDal : BaseRepository<Blog, ApplicationDbContext>, IBlogDal
    {
        private ApplicationDbContext _context;

        public BlogDal(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddWithTag(Blog blog, BlogCreateDto dto)
        {
            foreach (var tagID in dto.tagIds)
            {
                var tag = _context.Tags.Find(tagID);

                var tagBlog = new TagBlog
                {
                    BlogId = blog.ID,
                    Tag = tag,
                };
                _context.TagBlogs.Add(tagBlog);

            }
            _context.SaveChanges();
        }
        public List<BlogDto> GetBlogWithCategories()
        {
            var result = from blog in _context.Blogs
                         where blog.Deleted == 0
                         join categoryOfBlog in _context.CategoryOfBlogs
                         on blog.CategoryOfBlogID equals categoryOfBlog.ID
                         where categoryOfBlog.Deleted == 0
                         select new BlogDto
                         {
                             ID = blog.ID,
                             Title = blog.Title,
                             Description = blog.Description,
                             PhotoUrl = blog.PhotoUrl,
                             Text = blog.Text,
                             IsHome = blog.IsHome,
                             CreateDate = blog.CreateDate,
                             CategoryOfBlogID = blog.CategoryOfBlogID,
                             CategotyOfBlogName = categoryOfBlog.Name
                         };
            return result.ToList();
        }
        public List<BlogVM> GetAllBlogWithTag()
        {
            var blogs = (from blog in _context.Blogs
                           join categoryOfBlog in _context.CategoryOfBlogs
                           on blog.CategoryOfBlogID equals categoryOfBlog.ID
                           where blog.Deleted == 0 && categoryOfBlog.Deleted == 0
                           select new BlogVM
                           {
                               ID = blog.ID,
                               Title = blog.Title,
                               Description = blog.Description,
                               PhotoUrl = blog.PhotoUrl,
                               Text = blog.Text,
                               IsHome = blog.IsHome,
                               CategoryOfBlogID = categoryOfBlog.ID
                           }).ToList();
            if (blogs == null && blogs.Count == 0)
                return blogs;
            foreach (var blog in blogs)
            {
                blog.TagBlogVMs = GetBlogTagDetails(blog, blog.ID);
            }
            return blogs;
        }
        private ICollection<TagBlogVM> GetBlogTagDetails(BlogVM blog, int id)
        {
            var data = (from tagBlog in _context.TagBlogs
                        join b in _context.Blogs on tagBlog.BlogId equals b.ID
                        join t in _context.Tags on tagBlog.TagID equals t.ID
                        where b.ID == id && t.Deleted == 0 && tagBlog.Deleted == 0 && b.Deleted == 0
                        select new TagBlogVM
                        {
                            TagID = t.ID,
                            TagName = t.Name,
                            BlogId = b.ID,
                            Title = b.Title,
                            Description = b.Description,
                            Text = b.Text,
                            PhotoUrl = b.PhotoUrl,
                            CreateDate = b.CreateDate,
                        }).ToList();
            return data;
        }
        public BlogVM GetByIDBlogWithTag(int id)
        {
            var blog = (from b in _context.Blogs
                               join catBlog in _context.CategoryOfBlogs 
                               on b.CategoryOfBlogID equals catBlog.ID
                               where b.ID == id && b.Deleted == 0
                               select new BlogVM
                               {
                                   ID = b.ID,
                                   Title = b.Title,
                                   Description = b.Description,
                                   IsHome = b.IsHome,
                                   CreatedDate = b.CreateDate,
                                   Text = b.Text,
                                   PhotoUrl = b.PhotoUrl,
                                   CategoryOfBlogID = catBlog.ID,
                               }).FirstOrDefault();
            if (blog == null)
                return null;
            blog.TagBlogVMs = GetBlogTagDetails(blog, id);

            return blog;
        }
        public void UpdateWithTag(Blog blog, BlogUpdateDto dto)
        {
            var existingTag= _context.TagBlogs
                            .Where(sct => sct.BlogId == blog.ID)
                            .ToList();

            _context.TagBlogs.RemoveRange(existingTag);

            foreach (var tagID in dto.tagIds)
            {
                var tagBlog = new TagBlog
                {
                    BlogId = blog.ID,
                    TagID = tagID
                };
                _context.TagBlogs.Add(tagBlog);
            }

            _context.SaveChanges();
        }

        
        //public List<BlogDto> GetByIdCategory(int id)
        //{
        //    var data = (from blog in _context.Blogs
        //                where blog.Deleted == 0
        //                join category in _context.CategoryOfBlogs
        //                on blog.CategoryOfBlogID equals category.ID
        //                where category.ID == id && category.Deleted == 0
        //                select new BlogDto
        //                {
        //                    ID = blog.ID,
        //                    Title = blog.Title,
        //                    Description = blog.Description,
        //                    PhotoUrl = blog.PhotoUrl,
        //                    Text = blog.Text,
        //                    IsHome = blog.IsHome,
        //                    CreateDate = blog.CreateDate,
        //                    CategoryOfBlogID = category.ID,
        //                    CategotyOfBlogName = category.Name
        //                });
        //    return data.ToList();
        //}

        
    }

}
