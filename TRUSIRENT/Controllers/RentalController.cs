using Microsoft.AspNetCore.Mvc;
using TRUSIRENT.Models.Entities;
using TRUSIRENT.Models.Repositories;

namespace TRUSIRENT.Controllers
{
    public class RentalController : Controller
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IRentalCart _cart;

        public RentalController(IRentalRepository rentalRepository, IRentalCart cart)
        {
            _rentalRepository = rentalRepository;
            _cart = cart;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Rental rental)
        {
            var items = _cart.GetRentalCartItems();

            if (!items.Any())
            {
                ModelState.AddModelError("", "Koszyk jest pusty.");
                return View(rental);
            }

            if (ModelState.IsValid)
            {
                rental.RentalDate = DateTime.Now;

                _rentalRepository.CreateRental(rental);

                _cart.ClearCart();

                return RedirectToAction("CheckoutComplete");
            }

            return View(rental);
        }

        public IActionResult CheckoutComplete()
        {
            return View();
        }
    }
}