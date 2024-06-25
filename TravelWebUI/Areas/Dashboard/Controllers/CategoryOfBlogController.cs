using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelWebUI.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class CategoryOfBlogController : Controller
    {
        private readonly ICategoryOfBlogService _categoryOfBlogService;

        public CategoryOfBlogController(ICategoryOfBlogService categoryOfBlogService)
        {
            _categoryOfBlogService = categoryOfBlogService;
        }
        public IActionResult Index()
        {
            var data = _categoryOfBlogService.GetAll().Data;

            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CategoryOfBlogCreateDto dto)
        {
            var result = _categoryOfBlogService.Add(dto);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View(dto);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var data = _categoryOfBlogService.GetbyId(id).Data;

            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(CategoryOfBlogUpdateDto dto)
        {
            var result = _categoryOfBlogService.Update(dto);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");   
            }
            return View(dto);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _categoryOfBlogService.Delete(id);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }
    }
}
