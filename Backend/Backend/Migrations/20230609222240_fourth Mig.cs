using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class fourthMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Airline_AirlineId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Passanger_User_UserId",
                table: "Passanger");

            migrationBuilder.DropIndex(
                name: "IX_Passanger_UserId",
                table: "Passanger");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Passanger");

            migrationBuilder.RenameColumn(
                name: "AirlineId",
                table: "Booking",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_AirlineId",
                table: "Booking",
                newName: "IX_Booking_UserId");

            migrationBuilder.AddColumn<int>(
                name: "TimingId",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_TimingId",
                table: "Booking",
                column: "TimingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Timing_TimingId",
                table: "Booking",
                column: "TimingId",
                principalTable: "Timing",
                principalColumn: "TimingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_User_UserId",
                table: "Booking",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Timing_TimingId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_User_UserId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_TimingId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "TimingId",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Booking",
                newName: "AirlineId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_UserId",
                table: "Booking",
                newName: "IX_Booking_AirlineId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Passanger",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Passanger_UserId",
                table: "Passanger",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Airline_AirlineId",
                table: "Booking",
                column: "AirlineId",
                principalTable: "Airline",
                principalColumn: "AirlineId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Passanger_User_UserId",
                table: "Passanger",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
