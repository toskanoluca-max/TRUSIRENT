using TRUSIRENT.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace TRUSIRENT.Models.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly TrusiRentDbContext _context;

        public VehicleRepository(TrusiRentDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Vehicle> AllVehicles
            => _context.Vehicles
                .Include(v => v.VehicleType);

        public Vehicle? GetVehicleById(int vehicleId)
            => _context.Vehicles
                .Include(v => v.VehicleType)
                .FirstOrDefault(v => v.VehicleId == vehicleId);
    }
}