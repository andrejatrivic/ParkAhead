using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkAhead.Data.Migrations
{
    /// <inheritdoc />
    public partial class ParkingSpotImageXY : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageX",
                table: "ParkingSpot",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImageY",
                table: "ParkingSpot",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageX",
                table: "ParkingSpot");

            migrationBuilder.DropColumn(
                name: "ImageY",
                table: "ParkingSpot");
        }
    }
}
