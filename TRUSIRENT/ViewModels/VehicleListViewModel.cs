using TRUSIRENT.Models.Entities;

namespace TRUSIRENT.ViewModels
{
    public class VehicleListViewModel
    {
        public IEnumerable<Vehicle> Vehicles { get; set; }
        public string CurrentVehicleType { get; set; }

        public VehicleListViewModel(IEnumerable<Vehicle> vehicles, string currentVehicleType)
        {
            Vehicles = vehicles;
            CurrentVehicleType = currentVehicleType;
        }
    }
}