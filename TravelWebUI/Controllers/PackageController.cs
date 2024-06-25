using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using TravelWebUI.ViewModels;

namespace TravelWebUI.Controllers
{
    public class PackageController : Controller
    {
        private readonly IPackageService _packageService;
        private readonly IDestinationService _destinationService;

        public PackageController(IPackageService packageService, IDestinationService destinationService)
        {
            _packageService = packageService;
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var packageData = _packageService.GetPackagesWithDestinationID().Data;

            var destinationData = _destinationService.GetAll().Data;

            PackageViewModel viewModel = new()
            {
                Packages = packageData,
                Destinations = destinationData
            };
            return View(viewModel);
        }
    }
}
