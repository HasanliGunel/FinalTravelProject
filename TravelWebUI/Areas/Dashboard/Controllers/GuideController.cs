using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;


namespace TravelWebUI.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class GuideController : Controller
    {
        private IGuideService _guideService;
        private IWebHostEnvironment _env;
        public GuideController(IGuideService guideService, IWebHostEnvironment env)
        {
            _guideService = guideService;
            _env = env;
        }
        public IActionResult Index()
        {
            var data = _guideService.GetAll().Data;
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(GuideCreateDto dto, IFormFile photoUrl)
        {
            var result = _guideService.Add(dto, photoUrl, _env.WebRootPath);

            if(!result.IsSuccess)
            {
                ModelState.Clear();
                ModelState.AddModelError("", result.Message);
                return View(dto);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var data = _guideService.GetbyId(id).Data;

            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(GuideUpdateDto dto,IFormFile photoUrl)
        {
            var result = _guideService.Update(dto, photoUrl, _env.WebRootPath);

            if(result.IsSuccess)
                return RedirectToAction("Index");
            return View(dto);
           
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _guideService.Delete(id);

            if( result.IsSuccess)
                return RedirectToAction("Index");

            return View();
        }
    }
}
