using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelWebUI.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;


        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var data = _serviceService.GetAll().Data;
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ServiceCreateDto dto)
        {
            var result = _serviceService.Add(dto);

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
            var data = _serviceService.GetbyId(id).Data;

            return View(data);
        }
        [HttpPost]

        public IActionResult Edit(ServiceUpdateDto dto)
        {
            var result = _serviceService.Update(dto);

            if (result.IsSuccess)
                return RedirectToAction("Index");
            return View(dto);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _serviceService.Delete(id);

            if(result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }
    }
}
