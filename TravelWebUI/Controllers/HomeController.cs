using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using TravelWebUI.ViewModels;

namespace TravelWebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IDestinationService _destinationService;
        private readonly IAdvantageService _advantageService;
        private readonly IServiceService _serviceService;
        private readonly IPackageService _packageService;
        private readonly ITestimonialService _testimonialService;
        private readonly IGuideService _guideService;
        private readonly IBlogService _blogService;
        public HomeController(IAboutService aboutService, IDestinationService destinationService, IAdvantageService advantageService, IServiceService serviceService, IPackageService packageService, ITestimonialService testimonialService, IGuideService guideService, IBlogService blogService)
        {
            _aboutService = aboutService;
            _destinationService = destinationService;
            _advantageService = advantageService;
            _serviceService = serviceService;
            _packageService = packageService;
            _testimonialService = testimonialService;
            _guideService = guideService;
            _blogService = blogService;
        }


        public IActionResult Index()
        {
            var aboutData = _aboutService.GetAll().Data;
            var advantageData = _advantageService.GetAll().Data;
            var destinationData = _destinationService.GetAll().Data;
            var serviceData = _serviceService.GetAll().Data;
            var packageData = _packageService.GetPackagesWithDestinationID().Data;
            var testimonialData = _testimonialService.GetAll().Data;
            var guideData = _guideService.GetAll().Data;
            var blogData = _blogService.GetBlogWithCategoryID().Data;

            HomeViewModel viewModel = new()
            {
                Abouts = aboutData,
                Advantages = advantageData,
                Destinations = destinationData,
                Services = serviceData,
                Packages = packageData,
                Testimonials = testimonialData,
                Guides = guideData,
                Blogs = blogData,
            };
            return View(viewModel);
        }


        
    }
}
