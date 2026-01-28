using TRUSIRENT.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace TRUSIRENT.Models.Repositories;

public class RentalCart : IRentalCart
{
    private readonly TrusiRentDbContext _context;

    public string CartId { get; set; } = string.Empty;
    public List<RentalCartItem> RentalCartItems { get; set; } = new();

    private RentalCart(TrusiRentDbContext context)
    {
        _context = context;
    }

    public static RentalCart GetCart(IServiceProvider services)
    {
        var accessor = services.GetRequiredService<IHttpContextAccessor>();
        var session = accessor.HttpContext!.Session;

        var context = services.GetRequiredService<TrusiRentDbContext>();

        var cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
        session.SetString("CartId", cartId);

        return new RentalCart(context) { CartId = cartId };
    }

    public void AddToCart(Vehicle vehicle)
    {
        var cartItem = _context.RentalCartItems.SingleOrDefault(
            s => s.Vehicle.VehicleId == vehicle.VehicleId &&
                 s.CartId == CartId);

        if (cartItem == null)
        {
            cartItem = new RentalCartItem
            {
                CartId = CartId,
                Vehicle = vehicle,
                Amount = 1
            };

            _context.RentalCartItems.Add(cartItem);
        }
        else
        {
            cartItem.Amount++;
        }

        _context.SaveChanges();
    }

    public int RemoveFromCart(Vehicle vehicle)
    {
        var cartItem = _context.RentalCartItems.SingleOrDefault(
            s => s.Vehicle.VehicleId == vehicle.VehicleId &&
                 s.CartId == CartId);

        var localAmount = 0;

        if (cartItem != null)
        {
            if (cartItem.Amount > 1)
            {
                cartItem.Amount--;
                localAmount = cartItem.Amount;
            }
            else
            {
                _context.RentalCartItems.Remove(cartItem);
            }
        }

        _context.SaveChanges();
        return localAmount;
    }

    public List<RentalCartItem> GetRentalCartItems()
    {
        return RentalCartItems = _context.RentalCartItems
            .Where(c => c.CartId == CartId)
            .Include(s => s.Vehicle)
            .ToList();
    }

    public void ClearCart()
    {
        var cartItems = _context.RentalCartItems
            .Where(cart => cart.CartId == CartId);

        _context.RentalCartItems.RemoveRange(cartItems);
        _context.SaveChanges();
    }

    public decimal GetRentalCartTotal()
    {
        return _context.RentalCartItems
            .Where(c => c.CartId == CartId)
            .Select(c => c.Vehicle.PricePerDay * c.Amount)
            .Sum();
    }
}