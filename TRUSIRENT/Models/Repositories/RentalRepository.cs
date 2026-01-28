using TRUSIRENT.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace TRUSIRENT.Models.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        private readonly TrusiRentDbContext _context;
        private readonly IRentalCart _cart;

        public RentalRepository(TrusiRentDbContext context, IRentalCart cart)
        {
            _context = context;
            _cart = cart;
        }

        public void CreateRental(Rental rental)
        {
            var cartItems = _cart.GetRentalCartItems();
            rental.TotalCost = cartItems.Sum(i => i.Amount * i.Vehicle.PricePerDay);
            _context.Rentals.Add(rental);
            _context.SaveChanges();

            foreach (var item in cartItems)
            {
                var rentalDetail = new RentalDetail
                {
                    RentalId = rental.RentalId,
                    VehicleId = item.Vehicle.VehicleId,
                    Amount = item.Amount,
                    PricePerDay = item.Vehicle.PricePerDay
                };
                _context.RentalDetails.Add(rentalDetail);
            }

            _context.SaveChanges();
            _cart.ClearCart();
        }

        public IEnumerable<Rental> GetAllRentals()
        {
            return _context.Rentals.ToList();
        }

        public Rental? GetRentalById(int id)
        {
            return _context.Rentals.FirstOrDefault(r => r.RentalId == id);
        }

        public IEnumerable<(string VehicleType, decimal Revenue)> GetRevenueByVehicleType()
        {
            var query = _context.RentalDetails
                .Include(rd => rd.Vehicle)
                .ThenInclude(v => v.VehicleType)
                .AsNoTracking()
                .GroupBy(rd => rd.Vehicle.VehicleType.Name)
                .Select(g => new
                {
                    VehicleType = g.Key,
                    Revenue = g.Sum(x => x.PricePerDay * x.Amount)
                })
                .ToList();

            return query.Select(x => (x.VehicleType, x.Revenue));
        }
    }
}