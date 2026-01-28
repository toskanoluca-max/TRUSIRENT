using TRUSIRENT.Models.Repositories;

namespace TRUSIRENT.ViewModels;

public class RentalCartSummaryViewModel
{
    public RentalCartSummaryViewModel(IRentalCart rentalCart, int amount)
    {
        RentalCart = rentalCart;
        Amount = amount;
    }

    public IRentalCart RentalCart { get; }
    public int Amount { get; set; }
}