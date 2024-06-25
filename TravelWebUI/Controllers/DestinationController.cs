using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TravelWebUI.Controllers
{
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var data = _destinationService.GetAll().Data;
            return View(data);
        }
    }
}
