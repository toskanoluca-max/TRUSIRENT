using System.ComponentModel.DataAnnotations;

namespace TRUSIRENT.Models.Entities
{
    public class Vehicle
    {
        public int VehicleId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [Range(1, 10000)]
        public decimal PricePerDay { get; set; }

        [Url]
        public string? ImageUrl { get; set; }

        [Url]
        public string? ImageThumbnailUrl { get; set; }

        [Required]
        public int VehicleTypeId { get; set; }

        public VehicleType VehicleType { get; set; } = default!;
    }
}