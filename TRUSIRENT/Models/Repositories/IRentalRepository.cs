using System.Collections.Generic;

namespace TRUSIRENT.Models.Repositories
{
    public interface IRentalRepository
    {
        void CreateRental(Entities.Rental rental);
        IEnumerable<Entities.Rental> GetAllRentals();
        Entities.Rental? GetRentalById(int id);

        IEnumerable<(string VehicleType, decimal Revenue)> GetRevenueByVehicleType();
    }
}