using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lounga.Migrations
{
    public partial class editTransactionHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "BookingHotels",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DestinationFrom",
                table: "BookingFlights",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DestinationTo",
                table: "BookingFlights",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "BookingHotels");

            migrationBuilder.DropColumn(
                name: "DestinationFrom",
                table: "BookingFlights");

            migrationBuilder.DropColumn(
                name: "DestinationTo",
                table: "BookingFlights");
        }
    }
}
