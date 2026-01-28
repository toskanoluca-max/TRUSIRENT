using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TRUSIRENT.Models.Entities;

namespace TRUSIRENT.Models
{
    public class TrusiRentDbContext : IdentityDbContext
    {
        public TrusiRentDbContext(DbContextOptions<TrusiRentDbContext> options)
            : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; } = default!;
        public DbSet<VehicleType> VehicleTypes { get; set; } = default!;
        public DbSet<Rental> Rentals { get; set; } = default!;
        public DbSet<RentalDetail> RentalDetails { get; set; } = default!;
        public DbSet<RentalCartItem> RentalCartItems { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>()
                .Property(v => v.PricePerDay)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Rental>()
                .Property(r => r.TotalCost)
                .HasPrecision(18, 2);

            modelBuilder.Entity<RentalDetail>()
                .Property(rd => rd.PricePerDay)
                .HasPrecision(18, 2);

            modelBuilder.Entity<VehicleType>().HasData(
                new VehicleType { VehicleTypeId = 1, Name = "Sedan" },
                new VehicleType { VehicleTypeId = 2, Name = "Premium" },
                new VehicleType { VehicleTypeId = 3, Name = "SUV" },
                new VehicleType { VehicleTypeId = 4, Name = "Hatchback" },
                new VehicleType { VehicleTypeId = 5, Name = "Coupe" }
            );

            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle
                {
                    VehicleId = 1,
                    Name = "Audi A3",
                    Description = "Kompaktowy model klasy premium, idealny do miasta.",
                    PricePerDay = 199,
                    VehicleTypeId = 4,
                    ImageUrl = "/images/audi_a3.jpg",
                    ImageThumbnailUrl = "/images/audi_a3_thumb.jpg"
                },
                new Vehicle
                {
                    VehicleId = 2,
                    Name = "Audi A5",
                    Description = "Elegancki i dynamiczny model klasy średniej wyższej.",
                    PricePerDay = 259,
                    VehicleTypeId = 5,
                    ImageUrl = "/images/audi_a5.jpg",
                    ImageThumbnailUrl = "/images/audi_a5_thumb.jpg"
                },
                new Vehicle
                {
                    VehicleId = 3,
                    Name = "Audi A8",
                    Description = "Luksusowa limuzyna oferująca najwyższy komfort podróży.",
                    PricePerDay = 399,
                    VehicleTypeId = 2,
                    ImageUrl = "/images/audi_a8.jpg",
                    ImageThumbnailUrl = "/images/audi_a8_thumb.jpg"
                },
                new Vehicle
                {
                    VehicleId = 4,
                    Name = "Audi Q8",
                    Description = "Duży SUV premium o sportowym charakterze.",
                    PricePerDay = 349,
                    VehicleTypeId = 3,
                    ImageUrl = "/images/audi_q8.jpg",
                    ImageThumbnailUrl = "/images/audi_q8_thumb.jpg"
                }
            );
        }
    }
}