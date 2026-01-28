using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TRUSIRENT.Migrations
{
    /// <inheritdoc />
    public partial class AudiSeedUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "VehicleTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Sedan" },
                    { 2, "Premium" },
                    { 3, "SUV" },
                    { 4, "Hatchback" },
                    { 5, "Coupe" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "Description", "ImageThumbnailUrl", "ImageUrl", "Name", "PricePerDay", "VehicleTypeId" },
                values: new object[,]
                {
                    { 1, "Kompaktowy model klasy premium, idealny do miasta.", "/images/audi_a3_thumb.jpg", "/images/audi_a3.jpg", "Audi A3", 199m, 4 },
                    { 2, "Elegancki i dynamiczny model klasy średniej wyższej.", "/images/audi_a5_thumb.jpg", "/images/audi_a5.jpg", "Audi A5", 259m, 5 },
                    { 3, "Luksusowa limuzyna oferująca najwyższy komfort podróży.", "/images/audi_a8_thumb.jpg", "/images/audi_a8.jpg", "Audi A8", 399m, 2 },
                    { 4, "Duży SUV premium o sportowym charakterze.", "/images/audi_q8_thumb.jpg", "/images/audi_q8.jpg", "Audi Q8", 349m, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "VehicleTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "VehicleTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "VehicleTypeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "VehicleTypeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "VehicleTypeId",
                keyValue: 5);
        }
    }
}
