namespace TRUSIRENT.Models.Entities;

public class RentalDetail
{
    public int RentalDetailId { get; set; }

    public int Amount { get; set; }

    public decimal PricePerDay { get; set; }

    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; } = default!;

    public int RentalId { get; set; }
    public Rental Rental { get; set; } = default!;
}