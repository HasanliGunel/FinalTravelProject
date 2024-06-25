using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace TravelWebUI.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class TagController : Controller
    {
        private readonly ITagService _tagService;
        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        public IActionResult Index()
        {
            var data = _tagService.GetAll().Data;
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TagCreateDto dto)
        {
            var result = _tagService.Add(dto);

            if (!result.IsSuccess)
            {
                ModelState.Clear();
                ModelState.AddModelError("", result.Message);
                return View(dto);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var data = _tagService.GetbyId(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(TagUpdateDto dto)
        {
            var result = _tagService.Update(dto);

            if (result.IsSuccess)
                return RedirectToAction("Index");
            return View(dto);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _tagService.Delete(id);

            if(result.IsSuccess)
                return RedirectToAction("Index");
            return View(result);
        }
    }
}
