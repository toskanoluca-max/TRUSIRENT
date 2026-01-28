using Microsoft.AspNetCore.Mvc;
using TRUSIRENT.Models.Repositories;

namespace TRUSIRENT.Controllers
{
    public class RentalCartController : Controller
    {
        private readonly IRentalCart _cart;
        private readonly IVehicleRepository _vehicleRepository;

        public RentalCartController(IRentalCart cart, IVehicleRepository vehicleRepository)
        {
            _cart = cart;
            _vehicleRepository = vehicleRepository;
        }

        public IActionResult Index()
        {
            var items = _cart.GetRentalCartItems();
            return View(items);
        }

        [HttpPost]
        public IActionResult AddToCart(int vehicleId)
        {
            var vehicle = _vehicleRepository.GetVehicleById(vehicleId);

            if (vehicle != null)
            {
                _cart.AddToCart(vehicle);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int vehicleId)
        {
            var vehicle = _vehicleRepository.GetVehicleById(vehicleId);

            if (vehicle != null)
            {
                _cart.RemoveFromCart(vehicle);
            }

            return RedirectToAction("Index");
        }
    }
}