using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkAhead.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedOnDeleteActions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSpotHistory_ParkingSpots_ParkingSpotId",
                table: "ParkingSpotHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSpotHistory_Status_StatusId",
                table: "ParkingSpotHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_ParkingSpots_ParkingSpotId",
                table: "Reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParkingSpots",
                table: "ParkingSpots");

            migrationBuilder.RenameTable(
                name: "ParkingSpots",
                newName: "ParkingSpot");

            migrationBuilder.AddColumn<int>(
                name: "ParkingId",
                table: "ParkingSpot",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "ParkingSpot",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParkingSpot",
                table: "ParkingSpot",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpot_ParkingId",
                table: "ParkingSpot",
                column: "ParkingId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpot_StatusId",
                table: "ParkingSpot",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSpot_Parkings_ParkingId",
                table: "ParkingSpot",
                column: "ParkingId",
                principalTable: "Parkings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSpot_Status_StatusId",
                table: "ParkingSpot",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSpotHistory_ParkingSpot_ParkingSpotId",
                table: "ParkingSpotHistory",
                column: "ParkingSpotId",
                principalTable: "ParkingSpot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSpotHistory_Status_StatusId",
                table: "ParkingSpotHistory",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_ParkingSpot_ParkingSpotId",
                table: "Reservation",
                column: "ParkingSpotId",
                principalTable: "ParkingSpot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSpot_Parkings_ParkingId",
                table: "ParkingSpot");

            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSpot_Status_StatusId",
                table: "ParkingSpot");

            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSpotHistory_ParkingSpot_ParkingSpotId",
                table: "ParkingSpotHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSpotHistory_Status_StatusId",
                table: "ParkingSpotHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_ParkingSpot_ParkingSpotId",
                table: "Reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParkingSpot",
                table: "ParkingSpot");

            migrationBuilder.DropIndex(
                name: "IX_ParkingSpot_ParkingId",
                table: "ParkingSpot");

            migrationBuilder.DropIndex(
                name: "IX_ParkingSpot_StatusId",
                table: "ParkingSpot");

            migrationBuilder.DropColumn(
                name: "ParkingId",
                table: "ParkingSpot");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "ParkingSpot");

            migrationBuilder.RenameTable(
                name: "ParkingSpot",
                newName: "ParkingSpots");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParkingSpots",
                table: "ParkingSpots",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSpotHistory_ParkingSpots_ParkingSpotId",
                table: "ParkingSpotHistory",
                column: "ParkingSpotId",
                principalTable: "ParkingSpots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSpotHistory_Status_StatusId",
                table: "ParkingSpotHistory",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_ParkingSpots_ParkingSpotId",
                table: "Reservation",
                column: "ParkingSpotId",
                principalTable: "ParkingSpots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
