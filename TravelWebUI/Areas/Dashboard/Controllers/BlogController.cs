    using Business.Abstract;
using Core.Result.Contrete;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelWebUI.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryOfBlogService _categoryOfBlogService;
        private readonly ITagService _tagService;
        private readonly IWebHostEnvironment _env;

        public BlogController(IBlogService blogService, ICategoryOfBlogService categoryOfBlogService, IWebHostEnvironment env, ITagService tagService)
        {
            _blogService = blogService;
            _categoryOfBlogService = categoryOfBlogService;
            _env = env;
            _tagService = tagService;
        }

        public IActionResult Index()
        {
            var data = _blogService.GetBlogWithCategoryID().Data;
            return View(data);
        }

        public IActionResult Create()
        {
            ViewData["Categories"] = _categoryOfBlogService.GetAll().Data;
            ViewData["Tags"] = _tagService.GetAll().Data;

            return View();
        }

        [HttpPost]
        public IActionResult Create(BlogCreateDto dto, IFormFile photoUrl)
            {
            if (photoUrl != null)
            {
                //var result = _blogService.Add(dto, photoUrl, _env.WebRootPath);

                var result = _blogService.Add(dto, photoUrl, _env.WebRootPath);

                if (result.IsSuccess)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", result.Message);
            }
            ViewData["Categories"] = _categoryOfBlogService.GetAll().Data;
            //ViewData["Tags"]
            return View(dto);
        }
        [HttpPost]
        public ActionResult UploadImage(List<IFormFile> files)
        {
            var filepath = "";

            foreach(var photo in Request.Form.Files)
            {
                string serverMapPath = Path.Combine(_env.WebRootPath, "Images", photo.FileName);
                using (var stream = new FileStream(serverMapPath, FileMode.Create))
                {
                    photo.CopyTo(stream);
                }
                filepath = "http://localhost:5003/" + "Images/" + photo.FileName;
            }
            return Json(new {url = filepath});
        }
        public IActionResult Edit(int id)
        {
            ViewData["Categories"] = _categoryOfBlogService.GetAll().Data;

            ViewData["Tags"] = _tagService.GetAll().Data;

            //var data = _blogService.GetbyId(id).Data;
            var data = _blogService.GetbyIdBlogWithDetail(id).Data;
            var selectedClassTagIds = new List<int>();

            if (data.TagBlogVMs != null)
            {
                selectedClassTagIds = data.TagBlogVMs.Select(sct => sct.TagID).ToList();
            }
            ViewData["SelectedClassTagIds"] = selectedClassTagIds;
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(BlogUpdateDto dto, IFormFile formFile)
        {
            var result = _blogService.Update(dto, formFile, _env.WebRootPath);

            if (result.IsSuccess) return RedirectToAction("Index");

            return View(dto);

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _blogService.Delete(id);

            if (result.IsSuccess)
                return RedirectToAction("Index");

            return View();
        }
        
    }
}
