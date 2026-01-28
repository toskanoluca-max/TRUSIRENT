namespace TRUSIRENT.Models.Entities
{
    public class RentalCartItem
    {
        public int RentalCartItemId { get; set; }

        public int Amount { get; set; }

        public string CartId { get; set; } = string.Empty;

        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; } = default!;
    }
}