using TRUSIRENT.Models.Entities;
using TRUSIRENT.Models.Repositories;
using TRUSIRENT.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace TRUSIRENT.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IVehicleTypeRepository _vehicleTypeRepository;

        public VehicleController(
            IVehicleRepository vehicleRepository,
            IVehicleTypeRepository vehicleTypeRepository)
        {
            _vehicleRepository = vehicleRepository;
            _vehicleTypeRepository = vehicleTypeRepository;
        }

        public IActionResult List(string type)
        {
            IEnumerable<Vehicle> vehicles;
            string currentType;

            if (string.IsNullOrEmpty(type))
            {
                vehicles = _vehicleRepository.AllVehicles
                    .OrderBy(v => v.VehicleId);

                currentType = "Wszystkie pojazdy";
            }
            else
            {
                vehicles = _vehicleRepository.AllVehicles
                    .Where(v => v.VehicleType.Name.Equals(type, StringComparison.OrdinalIgnoreCase))
                    .OrderBy(v => v.VehicleId);

                currentType = _vehicleTypeRepository.AllVehicleTypes
                    .FirstOrDefault(t => t.Name.Equals(type, StringComparison.OrdinalIgnoreCase))
                    ?.Name ?? "Nieznany typ pojazdu";
            }

            return View(new VehicleListViewModel(vehicles, currentType));
        }

        public IActionResult Details(int id)
        {
            var vehicle = _vehicleRepository.GetVehicleById(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }
    }
}