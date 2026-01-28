using System.ComponentModel.DataAnnotations;

namespace TRUSIRENT.Models.Entities
{
    public class VehicleType
    {
        public int VehicleTypeId { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; } = string.Empty;

        public ICollection<Vehicle>? Vehicles { get; set; }
    }
}