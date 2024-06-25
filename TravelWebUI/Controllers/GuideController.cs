using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TravelWebUI.Controllers
{
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IActionResult Index()
        {
            var data = _guideService.GetAll().Data;
            return View(data);
        }
    }
}
