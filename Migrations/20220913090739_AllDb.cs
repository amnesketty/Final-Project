using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace lounga.Migrations
{
    public partial class AllDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountPassenger",
                table: "Airlines");

            migrationBuilder.DropColumn(
                name: "ArrivalAirport",
                table: "Airlines");

            migrationBuilder.DropColumn(
                name: "DepartureAirport",
                table: "Airlines");

            migrationBuilder.DropColumn(
                name: "FacilitiesFlight",
                table: "Airlines");

            migrationBuilder.DropColumn(
                name: "FlightDuration",
                table: "Airlines");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Airlines");

            migrationBuilder.DropColumn(
                name: "TransitFlight",
                table: "Airlines");

            migrationBuilder.DropColumn(
                name: "TravelRoute",
                table: "Airlines");

            migrationBuilder.CreateTable(
                name: "Aircrafts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    AircraftsType = table.Column<string>(type: "text", nullable: false),
                    SeatLayout = table.Column<string>(type: "text", nullable: false),
                    SeatPitch = table.Column<string>(type: "text", nullable: false),
                    SeatCapacity = table.Column<int>(type: "integer", nullable: false),
                    AmountPassenger = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    AirlineId = table.Column<int>(type: "integer", nullable: true)
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
                name: "BookingHotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BookingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TotalRoom = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    HotelId = table.Column<int>(type: "integer", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingHotels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingHotels_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BookingHotels_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FacilitiesHotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AirConditioner = table.Column<bool>(type: "boolean", nullable: false),
                    Television = table.Column<bool>(type: "boolean", nullable: false),
                    Wifi = table.Column<bool>(type: "boolean", nullable: false),
                    Restaurant = table.Column<bool>(type: "boolean", nullable: false),
                    Spa = table.Column<bool>(type: "boolean", nullable: false),
                    Pool = table.Column<bool>(type: "boolean", nullable: false),
                    Playground = table.Column<bool>(type: "boolean", nullable: false),
                    Gym = table.Column<bool>(type: "boolean", nullable: false),
                    Parking = table.Column<bool>(type: "boolean", nullable: false),
                    HotelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilitiesHotels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacilitiesHotels_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Image = table.Column<string>(type: "text", nullable: false),
                    HotelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    HotelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BookingFlights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BookingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    AmountPassenger = table.Column<int>(type: "integer", nullable: false),
                    TotalPrice = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    AirlineId = table.Column<int>(type: "integer", nullable: true),
                    AircraftId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingFlights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingFlights_Aircrafts_AircraftId",
                        column: x => x.AircraftId,
                        principalTable: "Aircrafts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BookingFlights_Airlines_AirlineId",
                        column: x => x.AirlineId,
                        principalTable: "Airlines",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BookingFlights_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FacilitiesAircrafts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Baggage = table.Column<int>(type: "integer", nullable: false),
                    CabinBaggage = table.Column<int>(type: "integer", nullable: false),
                    Wifi = table.Column<bool>(type: "boolean", nullable: false),
                    PowerPort = table.Column<bool>(type: "boolean", nullable: false),
                    Entertainment = table.Column<bool>(type: "boolean", nullable: false),
                    AircraftId = table.Column<int>(type: "integer", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    BookingHotelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Guests_BookingHotels_BookingHotelId",
                        column: x => x.BookingHotelId,
                        principalTable: "BookingHotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingHotelRoom",
                columns: table => new
                {
                    BookingHotelsId = table.Column<int>(type: "integer", nullable: false),
                    RoomId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingHotelRoom", x => new { x.BookingHotelsId, x.RoomId });
                    table.ForeignKey(
                        name: "FK_BookingHotelRoom_BookingHotels_BookingHotelsId",
                        column: x => x.BookingHotelsId,
                        principalTable: "BookingHotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingHotelRoom_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IdCard = table.Column<string>(type: "text", nullable: false),
                    BookingFlightId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passengers_BookingFlights_BookingFlightId",
                        column: x => x.BookingFlightId,
                        principalTable: "BookingFlights",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aircrafts_AirlineId",
                table: "Aircrafts",
                column: "AirlineId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingFlights_AircraftId",
                table: "BookingFlights",
                column: "AircraftId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingFlights_AirlineId",
                table: "BookingFlights",
                column: "AirlineId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingFlights_UserId",
                table: "BookingFlights",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingHotelRoom_RoomId",
                table: "BookingHotelRoom",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingHotels_HotelId",
                table: "BookingHotels",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingHotels_UserId",
                table: "BookingHotels",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilitiesAircrafts_AircraftId",
                table: "FacilitiesAircrafts",
                column: "AircraftId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FacilitiesHotels_HotelId",
                table: "FacilitiesHotels",
                column: "HotelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Guests_BookingHotelId",
                table: "Guests",
                column: "BookingHotelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_BookingFlightId",
                table: "Passengers",
                column: "BookingFlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_HotelId",
                table: "Photos",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelId",
                table: "Rooms",
                column: "HotelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingHotelRoom");

            migrationBuilder.DropTable(
                name: "FacilitiesAircrafts");

            migrationBuilder.DropTable(
                name: "FacilitiesHotels");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "BookingHotels");

            migrationBuilder.DropTable(
                name: "BookingFlights");

            migrationBuilder.DropTable(
                name: "Aircrafts");

            migrationBuilder.AddColumn<int>(
                name: "AmountPassenger",
                table: "Airlines",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ArrivalAirport",
                table: "Airlines",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DepartureAirport",
                table: "Airlines",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FacilitiesFlight",
                table: "Airlines",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FlightDuration",
                table: "Airlines",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Airlines",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "TransitFlight",
                table: "Airlines",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TravelRoute",
                table: "Airlines",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
