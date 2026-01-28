using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TRUSIRENT.Migrations
{
    /// <inheritdoc />
    public partial class AddCartIdToRentalCartItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RentalCartId",
                table: "RentalCartItems");

            migrationBuilder.AddColumn<string>(
                name: "CartId",
                table: "RentalCartItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartId",
                table: "RentalCartItems");

            migrationBuilder.AddColumn<string>(
                name: "RentalCartId",
                table: "RentalCartItems",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
