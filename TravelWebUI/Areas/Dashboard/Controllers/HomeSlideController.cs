using Business.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelWebUI.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class HomeSlideController : Controller
    {
        private readonly IHomeSlideService _homeSlideService;
        private readonly IWebHostEnvironment _env;

        public HomeSlideController(IHomeSlideService homeSlideService, IWebHostEnvironment env)
        {
            _homeSlideService = homeSlideService;
            _env = env; 
        }
        public IActionResult Index()
        {
            var data = _homeSlideService.GetAll().Data;
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(HomeSlideCreateDto dto, IFormFile photoUrl)
        {
            if (photoUrl != null)
            {
                var result = _homeSlideService.Add(dto, photoUrl, _env.WebRootPath);

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
            var data = _homeSlideService.GetbyId(id).Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(HomeSlideUpdateDto dto,  IFormFile photoUrl)
        {
            var result = _homeSlideService.Update(dto, photoUrl, _env.WebRootPath); 

            if (result.IsSuccess) 
                return RedirectToAction("Index");

            return View(result);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _homeSlideService.Delete(id);

            if (result.IsSuccess)
                return RedirectToAction("Index");
            return View();
        }
    }
}
