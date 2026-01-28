using TRUSIRENT.Models.Repositories;

namespace TRUSIRENT.ViewModels;

public class RentalCartViewModel
{
    public RentalCartViewModel(IRentalCart rentalCart, decimal rentalCartTotal)
    {
        RentalCart = rentalCart;
        RentalCartTotal = rentalCartTotal;
    }

    public IRentalCart RentalCart { get; }
    public decimal RentalCartTotal { get; }
}