using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace lounga.Migrations
{
    public partial class UpdateAllDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingFlights_Aircrafts_AircraftId",
                table: "BookingFlights");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingFlights_Airlines_AirlineId",
                table: "BookingFlights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_FacilitiesAircrafts_FacilitiesAircraftId",
                table: "Flights");

            migrationBuilder.DropTable(
                name: "FacilitiesAircrafts");

            migrationBuilder.DropTable(
                name: "Aircrafts");

            migrationBuilder.DropTable(
                name: "Airlines");

            migrationBuilder.DropIndex(
                name: "IX_Flights_FacilitiesAircraftId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_BookingFlights_AircraftId",
                table: "BookingFlights");

            migrationBuilder.DropIndex(
                name: "IX_BookingFlights_AirlineId",
                table: "BookingFlights");

            migrationBuilder.DropColumn(
                name: "FacilitiesAircraftId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "AircraftId",
                table: "BookingFlights");

            migrationBuilder.DropColumn(
                name: "AirlineId",
                table: "BookingFlights");

            migrationBuilder.CreateTable(
                name: "FacilitiesFlights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Baggage = table.Column<int>(type: "integer", nullable: false),
                    CabinBaggage = table.Column<int>(type: "integer", nullable: false),
                    Wifi = table.Column<bool>(type: "boolean", nullable: false),
                    PowerPort = table.Column<bool>(type: "boolean", nullable: false),
                    Entertainment = table.Column<bool>(type: "boolean", nullable: false),
                    FlightId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilitiesFlights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacilitiesFlights_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FacilitiesFlights_FlightId",
                table: "FacilitiesFlights",
                column: "FlightId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacilitiesFlights");

            migrationBuilder.AddColumn<int>(
                name: "FacilitiesAircraftId",
                table: "Flights",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AircraftId",
                table: "BookingFlights",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AirlineId",
                table: "BookingFlights",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Airlines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ArrivalTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DestinationFrom = table.Column<string>(type: "text", nullable: false),
                    DestinationTo = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SeatClass = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airlines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aircrafts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AirlineId = table.Column<int>(type: "integer", nullable: true),
                    AircraftsType = table.Column<string>(type: "text", nullable: false),
                    AmountPassenger = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    SeatCapacity = table.Column<int>(type: "integer", nullable: false),
                    SeatLayout = table.Column<string>(type: "text", nullable: false),
                    SeatPitch = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircrafts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aircrafts_Airlines_AirlineId",
                        column: x => x.AirlineId,
                        principalTable: "Airlines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FacilitiesAircrafts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AircraftId = table.Column<int>(type: "integer", nullable: false),
                    Baggage = table.Column<int>(type: "integer", nullable: false),
                    CabinBaggage = table.Column<int>(type: "integer", nullable: false),
                    Entertainment = table.Column<bool>(type: "boolean", nullable: false),
                    PowerPort = table.Column<bool>(type: "boolean", nullable: false),
                    Wifi = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilitiesAircrafts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacilitiesAircrafts_Aircrafts_AircraftId",
                        column: x => x.AircraftId,
                        principalTable: "Aircrafts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_FacilitiesAircraftId",
                table: "Flights",
                column: "FacilitiesAircraftId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingFlights_AircraftId",
                table: "BookingFlights",
                column: "AircraftId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingFlights_AirlineId",
                table: "BookingFlights",
                column: "AirlineId");

            migrationBuilder.CreateIndex(
                name: "IX_Aircrafts_AirlineId",
                table: "Aircrafts",
                column: "AirlineId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilitiesAircrafts_AircraftId",
                table: "FacilitiesAircrafts",
                column: "AircraftId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingFlights_Aircrafts_AircraftId",
                table: "BookingFlights",
                column: "AircraftId",
                principalTable: "Aircrafts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingFlights_Airlines_AirlineId",
                table: "BookingFlights",
                column: "AirlineId",
                principalTable: "Airlines",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_FacilitiesAircrafts_FacilitiesAircraftId",
                table: "Flights",
                column: "FacilitiesAircraftId",
                principalTable: "FacilitiesAircrafts",
                principalColumn: "Id");
        }
    }
}
