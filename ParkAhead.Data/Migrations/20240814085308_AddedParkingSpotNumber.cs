using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkAhead.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedParkingSpotNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParkingSpotNumber",
                table: "ParkingSpot",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParkingSpotNumber",
                table: "ParkingSpot");
        }
    }
}
