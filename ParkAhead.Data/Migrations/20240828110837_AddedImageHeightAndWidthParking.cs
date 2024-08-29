using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkAhead.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedImageHeightAndWidthParking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageHeight",
                table: "Parkings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImageWidth",
                table: "Parkings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageHeight",
                table: "Parkings");

            migrationBuilder.DropColumn(
                name: "ImageWidth",
                table: "Parkings");
        }
    }
}
