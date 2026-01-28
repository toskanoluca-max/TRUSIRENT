using TRUSIRENT.Models.Entities;

namespace TRUSIRENT.Models.Repositories
{
    public interface IVehicleRepository
    {
        IEnumerable<Vehicle> AllVehicles { get; }
        Vehicle? GetVehicleById(int vehicleId);
    }
}