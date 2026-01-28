using TRUSIRENT.Models.Entities;

namespace TRUSIRENT.Models.Repositories
{
    public class VehicleTypeRepository : IVehicleTypeRepository
    {
        private readonly TrusiRentDbContext _context;

        public VehicleTypeRepository(TrusiRentDbContext context)
        {
            _context = context;
        }

        public IEnumerable<VehicleType> AllVehicleTypes =>
            _context.VehicleTypes.OrderBy(vt => vt.Name);
    }
}