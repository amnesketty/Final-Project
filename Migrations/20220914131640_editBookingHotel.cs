using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lounga.Migrations
{
    public partial class editBookingHotel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingHotelRoom");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordSalt",
                table: "Users",
                type: "bytea",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "bytea");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "Users",
                type: "bytea",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "bytea");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "BookingHotels",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookingHotels_RoomId",
                table: "BookingHotels",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingHotels_Rooms_RoomId",
                table: "BookingHotels",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingHotels_Rooms_RoomId",
                table: "BookingHotels");

            migrationBuilder.DropIndex(
                name: "IX_BookingHotels_RoomId",
                table: "BookingHotels");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "BookingHotels");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordSalt",
                table: "Users",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "bytea",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "Users",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "bytea",
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_BookingHotelRoom_RoomId",
                table: "BookingHotelRoom",
                column: "RoomId");
        }
    }
}
