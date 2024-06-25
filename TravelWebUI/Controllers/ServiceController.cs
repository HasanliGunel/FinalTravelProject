using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using TravelWebUI.ViewModels;

namespace TravelWebUI.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;
        private readonly ITestimonialService _testimonialService;

        public ServiceController(IServiceService serviceService, ITestimonialService testimonialService)
        {
            _serviceService = serviceService;
            _testimonialService = testimonialService;
        }

        public IActionResult Index()
        {
            var serviceData = _serviceService.GetAll().Data;
            var testimonialData = _testimonialService.GetAll().Data;
            ServiceViewModel viewModel = new ServiceViewModel()
            {
                Services = serviceData,
                Testimonials = testimonialData
            };
            return View(viewModel);
        }
    }
}
