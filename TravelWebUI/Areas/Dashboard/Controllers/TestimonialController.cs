using Business.Abstract;
using Core.Result.Contrete;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelWebUI.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IWebHostEnvironment _env;

        public TestimonialController(ITestimonialService testimonialService, IWebHostEnvironment env)
        {
            _testimonialService = testimonialService;
            _env = env;
        }

        public IActionResult Index()
        {
            var data = _testimonialService.GetAll().Data;
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TestimonialCreateDto dto, IFormFile photoUrl)
        {
            if (photoUrl != null)
            {
                var result = _testimonialService.Add(dto, photoUrl, _env.WebRootPath);

                if (result.IsSuccess)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", result.Message);
            }
            return View(dto);
        }

        public IActionResult Edit(int id)
        {
            var data = _testimonialService.GetbyId(id).Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(TestimonialUpdateDto dto, IFormFile photoUrl)
        {
            var result = _testimonialService.Update(dto, photoUrl, _env.WebRootPath);

            if(result .IsSuccess) 
                return RedirectToAction("Index");

            return View(dto);
        }

        public IActionResult Delete(int id)
        {
            var data = _testimonialService.Delete(id);

            if (data.IsSuccess)
                return RedirectToAction("Index");

            return View();
        }
    }
}
