using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelWebUI.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;
        private readonly IWebHostEnvironment _env;
        public DestinationController(IDestinationService destinationService, IWebHostEnvironment env)
        {
            _destinationService = destinationService;
            _env = env;
        }

        public IActionResult Index()
        {
            var data = _destinationService.GetAll().Data;
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DestinationCreateDto dto, IFormFile photoUrl)
        {
            var result = _destinationService.Add(dto,photoUrl, _env.WebRootPath);

            if(result.IsSuccess) 
                return RedirectToAction("Index");

            return View(dto);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _destinationService.GetbyId(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit (DestinationUpdateDto dto, IFormFile photoUrl)
        {
            var result = _destinationService.Update(dto, photoUrl, _env.WebRootPath);

            if(result.IsSuccess ) return RedirectToAction("Index");

            return View(dto);

        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _destinationService.Delete(id);
            
            if (result.IsSuccess) return RedirectToAction("Index");

            return View(result);
        }
    }
}
