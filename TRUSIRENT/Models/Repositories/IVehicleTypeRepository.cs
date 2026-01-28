using TRUSIRENT.Models.Entities;

namespace TRUSIRENT.Models.Repositories
{
    public interface IVehicleTypeRepository
    {
        IEnumerable<VehicleType> AllVehicleTypes { get; }
    }
}