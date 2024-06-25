using Business.Abstract;
using DataAccess.Concrete;
using DataAccess.Context;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModel;
using Entities.Concrete.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Reflection.Metadata;
using TravelWebUI.ViewModels;

namespace TravelWebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ITagService _tagService;
        private readonly ICategoryOfBlogService _categoryOfBlogService;

        public BlogController(IBlogService blogService, ITagService tagService, ICategoryOfBlogService categoryOfBlogService)
        {
            _blogService = blogService;
            _tagService = tagService;
            _categoryOfBlogService = categoryOfBlogService;
        }

        public IActionResult Index()
        {
            
            BlogViewModel model = new();
            List<TagBlogVM> blogs = new();
            
            var blogdata = _blogService.GetBlogWithDetails().Data;
            var tagdata = _tagService.GetAllTagWithDetails().Data;
            var categoryData = _categoryOfBlogService.GetAll().Data;
            foreach (var item in blogdata)
            {
                blogs.Add(item.TagBlogVMs.FirstOrDefault());
            }
            //var categoryBlog = _categoryOfBlogService.GetAll().Data;
            model.Blogs = blogs;
            model.Tags = tagdata;
            model.categoryOfBlogs = categoryData;
            return View(model);

            //}
            //else
            //{
            //var tags = _tagService.GetbyIdTagWithDetails(id).Data;
            //var blog = tags.TagBlogVMs;
            //var tagdata = _tagService.GetAllTagWithDetails().Data;
            //model = new()
            //{
            //    Blogs = (List<TagBlogVM>)blog,
            //    Tags = tagdata
            //};
            //}
        }

        public ActionResult Tag(int id)
        {
            BlogViewModel model = new();
            var tags = _tagService.GetbyIdTagWithDetails(id).Data;
            var blog = tags.TagBlogVMs;
            var tagdata = _tagService.GetAllTagWithDetails().Data;
            model = new()
            {
                Blogs = (List<TagBlogVM>)blog,
                Tags = tagdata
            };
            return View("Index",model);
        }

        public ActionResult Category(int id)
        {
            BlogViewModel model = new();
            
            var tagdata = _tagService.GetAllTagWithDetails().Data;

            var cat = _categoryOfBlogService.GetbyIdCategoryWithDetails(id).Data;

            var blog = cat.TagBlogVMs;
            var categoryData = _categoryOfBlogService.GetAll().Data;
            model = new()
            {
                Blogs = (List<TagBlogVM>)blog,
                Tags = tagdata,
                categoryOfBlogs = categoryData
            };
            return View("Index", model);
        }

     
        public IActionResult Details(int id)
        {
            var data = _blogService.GetbyIdBlogWithDetail(id).Data;
            
            return View(data);
        }

    }
}
