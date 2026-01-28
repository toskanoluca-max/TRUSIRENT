using Microsoft.AspNetCore.Mvc;
using TRUSIRENT.Models.Repositories;
using TRUSIRENT.ViewModels;

namespace TRUSIRENT.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVehicleRepository _vehicleRepository;

        public HomeController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public IActionResult Index()
        {
            var vehicles = _vehicleRepository.AllVehicles;
            var homeViewModel = new HomeViewModel(vehicles);
            return View(homeViewModel);
        }
    }
}