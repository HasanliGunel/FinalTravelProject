using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TravelWebUI.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public IActionResult Index()
        {
            var data = _testimonialService.GetAll().Data;
            return View(data);
        }
    }
}
