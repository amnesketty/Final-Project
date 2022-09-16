using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lounga.Migrations
{
    public partial class nullsafetybooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_BookingFlights_BookingFlightId",
                table: "Passengers");

            migrationBuilder.AlterColumn<int>(
                name: "BookingFlightId",
                table: "Passengers",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_BookingFlights_BookingFlightId",
                table: "Passengers",
                column: "BookingFlightId",
                principalTable: "BookingFlights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_BookingFlights_BookingFlightId",
                table: "Passengers");

            migrationBuilder.AlterColumn<int>(
                name: "BookingFlightId",
                table: "Passengers",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_BookingFlights_BookingFlightId",
                table: "Passengers",
                column: "BookingFlightId",
                principalTable: "BookingFlights",
                principalColumn: "Id");
        }
    }
}
