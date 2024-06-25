using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelWebUI.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class AdvantageController : Controller
    {
        private readonly IAdvantageService _advantageService;

        public AdvantageController(IAdvantageService advantageService)
        {
            _advantageService = advantageService;
        }
        public IActionResult Index()
        {
            var data = _advantageService.GetAll().Data;
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AdvantageCreateDto dto)
        {
            var result = _advantageService.Add(dto);

            if (!result.IsSuccess) 
            {
                
                ModelState.AddModelError("", result.Message);
                return View(dto);
            }
            return RedirectToAction("Index");

            //var result = _aboutService.Add(dto);

            //if (!result.IsSuccess)
            //{

            //    ModelState.AddModelError("", result.Message);

            //    //ModelState.AddModelError("Description", result.Message);
            //    return View(dto);
            //}
            //return RedirectToAction("Index");

        }

        public IActionResult Edit(int id)
        {
            var data = _advantageService.GetbyId(id).Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(AdvantageUpdateDto dto)
        {
            var result = _advantageService.Update(dto);

            if (result.IsSuccess) 
                return RedirectToAction("Index");

            return View(dto);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _advantageService.Delete(id);

            if (result.IsSuccess) 
                return RedirectToAction("Index");

            return View(result);
        }

    }

}
