using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lounga.Migrations
{
    public partial class BookingNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookingHotelNo",
                table: "BookingHotels",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BookingFlightNo",
                table: "BookingFlights",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingHotelNo",
                table: "BookingHotels");

            migrationBuilder.DropColumn(
                name: "BookingFlightNo",
                table: "BookingFlights");
        }
    }
}
