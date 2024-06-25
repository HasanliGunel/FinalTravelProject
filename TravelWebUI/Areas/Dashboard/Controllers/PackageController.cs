using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelWebUI.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class PackageController : Controller
    {
        //PackageManager _packageManager = new();
        //DestinationManager _destinationManager = new();

        private readonly IPackageService _packageService;
        private readonly IDestinationService _destinationService;
        private readonly IWebHostEnvironment _env;
        public PackageController(IPackageService packageService, IDestinationService destinationService, IWebHostEnvironment webHostEnvironment)
        {
            _packageService = packageService;
            _destinationService = destinationService;
            _env = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var data = _packageService.GetPackagesWithDestinationID().Data;
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Destinations"] = _destinationService.GetAll().Data;
            return View();
        }

        [HttpPost]
        public IActionResult Create(PackageCreateDto dto, IFormFile photoUrl)
        {
            ViewData["Destinations"] = _destinationService.GetAll().Data;
            var result = _packageService.Add(dto, photoUrl, _env.WebRootPath);

            if(result.IsSuccess) 
                return RedirectToAction("Index");

            return View(dto);
        }
        public IActionResult Edit(int id)
        {
            ViewData["Destinations"] = _destinationService.GetAll().Data;

            var data = _packageService.GetbyId(id).Data; 

            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(PackageUpdateDto dto, IFormFile photoUrl)
        {
            var result = _packageService.Update(dto, photoUrl, _env.WebRootPath);
            
            if(result.IsSuccess)
                return RedirectToAction("Index");

            return View(dto);
        }
        public IActionResult Delete(int id) 
        {
            var result = _packageService.Delete(id);
            
            if(result.IsSuccess)
                return RedirectToAction("Index");

            return View();
        }
    }
}
