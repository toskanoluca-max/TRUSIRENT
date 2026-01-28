using TRUSIRENT.Models.Entities;

namespace TRUSIRENT.Models.Repositories;

public interface IRentalCart
{
    void AddToCart(Vehicle vehicle);
    int RemoveFromCart(Vehicle vehicle);
    List<RentalCartItem> GetRentalCartItems();
    void ClearCart();
    decimal GetRentalCartTotal();
    List<RentalCartItem> RentalCartItems { get; set; }
}