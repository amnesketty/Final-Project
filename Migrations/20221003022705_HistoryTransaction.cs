using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lounga.Migrations
{
    public partial class HistoryTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingFlights_FacilitiesFlights_FacilitiesFlightId",
                table: "BookingFlights");

            migrationBuilder.DropIndex(
                name: "IX_BookingFlights_FacilitiesFlightId",
                table: "BookingFlights");

            migrationBuilder.DropColumn(
                name: "FacilitiesFlightId",
                table: "BookingFlights");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FacilitiesFlightId",
                table: "BookingFlights",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookingFlights_FacilitiesFlightId",
                table: "BookingFlights",
                column: "FacilitiesFlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingFlights_FacilitiesFlights_FacilitiesFlightId",
                table: "BookingFlights",
                column: "FacilitiesFlightId",
                principalTable: "FacilitiesFlights",
                principalColumn: "Id");
        }
    }
}
