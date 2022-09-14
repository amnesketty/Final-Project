using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace lounga.Migrations
{
    public partial class updatedatacontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FlightId",
                table: "BookingFlights",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "flights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Airline = table.Column<string>(type: "text", nullable: false),
                    SeatClass = table.Column<string>(type: "text", nullable: false),
                    Aircraft = table.Column<string>(type: "text", nullable: false),
                    AircraftsType = table.Column<string>(type: "text", nullable: false),
                    SeatLayout = table.Column<string>(type: "text", nullable: false),
                    SeatPitch = table.Column<string>(type: "text", nullable: false),
                    SeatCapacity = table.Column<int>(type: "integer", nullable: false),
                    AmountPassenger = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    DestinationFrom = table.Column<string>(type: "text", nullable: false),
                    DestinationTo = table.Column<string>(type: "text", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FacilitiesAircraftId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_flights_FacilitiesAircrafts_FacilitiesAircraftId",
                        column: x => x.FacilitiesAircraftId,
                        principalTable: "FacilitiesAircrafts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingFlights_FlightId",
                table: "BookingFlights",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_flights_FacilitiesAircraftId",
                table: "flights",
                column: "FacilitiesAircraftId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingFlights_flights_FlightId",
                table: "BookingFlights",
                column: "FlightId",
                principalTable: "flights",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingFlights_flights_FlightId",
                table: "BookingFlights");

            migrationBuilder.DropTable(
                name: "flights");

            migrationBuilder.DropIndex(
                name: "IX_BookingFlights_FlightId",
                table: "BookingFlights");

            migrationBuilder.DropColumn(
                name: "FlightId",
                table: "BookingFlights");
        }
    }
}
