using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using TravelWebUI.ViewModels;

namespace TravelWebUI.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IAdvantageService _advantageService;
        private readonly IGuideService _guideService;

        public AboutController(IAboutService aboutService, IAdvantageService advantageService, IGuideService guideService)
        {
            _aboutService = aboutService;
            _advantageService = advantageService;
            _guideService = guideService;
        }

        public IActionResult Index()
        {
            var aboutData = _aboutService.GetAll().Data;
            var advantageData = _advantageService.GetAll().Data;
            var guideData = _guideService.GetAll().Data;

            AboutViewModel ViewModel = new AboutViewModel()
            {
                Abouts = aboutData,
                Advantages = advantageData,
                Guides = guideData,
            };

            return View(ViewModel);
        }
    }
}
