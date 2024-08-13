using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkAhead.Data.Migrations
{
    /// <inheritdoc />
    public partial class ParkingSpotChangeType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "ParkingSpot",
                type: "DECIMAL(18,8)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "ParkingSpot",
                type: "DECIMAL(18,8)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Longitude",
                table: "ParkingSpot",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,8)");

            migrationBuilder.AlterColumn<long>(
                name: "Latitude",
                table: "ParkingSpot",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,8)");
        }
    }
}
