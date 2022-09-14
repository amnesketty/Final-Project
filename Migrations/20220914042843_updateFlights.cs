using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lounga.Migrations
{
    public partial class updateFlights : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingFlights_flights_FlightId",
                table: "BookingFlights");

            migrationBuilder.DropForeignKey(
                name: "FK_flights_FacilitiesAircrafts_FacilitiesAircraftId",
                table: "flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_flights",
                table: "flights");

            migrationBuilder.RenameTable(
                name: "flights",
                newName: "Flights");

            migrationBuilder.RenameIndex(
                name: "IX_flights_FacilitiesAircraftId",
                table: "Flights",
                newName: "IX_Flights_FacilitiesAircraftId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flights",
                table: "Flights",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingFlights_Flights_FlightId",
                table: "BookingFlights",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_FacilitiesAircrafts_FacilitiesAircraftId",
                table: "Flights",
                column: "FacilitiesAircraftId",
                principalTable: "FacilitiesAircrafts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingFlights_Flights_FlightId",
                table: "BookingFlights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_FacilitiesAircrafts_FacilitiesAircraftId",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flights",
                table: "Flights");

            migrationBuilder.RenameTable(
                name: "Flights",
                newName: "flights");

            migrationBuilder.RenameIndex(
                name: "IX_Flights_FacilitiesAircraftId",
                table: "flights",
                newName: "IX_flights_FacilitiesAircraftId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_flights",
                table: "flights",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingFlights_flights_FlightId",
                table: "BookingFlights",
                column: "FlightId",
                principalTable: "flights",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_flights_FacilitiesAircrafts_FacilitiesAircraftId",
                table: "flights",
                column: "FacilitiesAircraftId",
                principalTable: "FacilitiesAircrafts",
                principalColumn: "Id");
        }
    }
}
