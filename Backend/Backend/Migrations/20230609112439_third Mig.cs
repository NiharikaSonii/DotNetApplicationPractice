using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class thirdMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timing_Airline_AirlineId",
                table: "Timing");

            migrationBuilder.DropIndex(
                name: "IX_Timing_AirlineId",
                table: "Timing");

            migrationBuilder.DropColumn(
                name: "AvailableSeats",
                table: "Airline");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Airline");

            migrationBuilder.DropColumn(
                name: "TotalSeats",
                table: "Airline");

            migrationBuilder.RenameColumn(
                name: "AirlineId",
                table: "Timing",
                newName: "TotalSeats");

            migrationBuilder.AddColumn<string>(
                name: "AirlineName",
                table: "Timing",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AirlineNo",
                table: "Timing",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AvailableSeats",
                table: "Timing",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Timing",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AirlineName",
                table: "Timing");

            migrationBuilder.DropColumn(
                name: "AirlineNo",
                table: "Timing");

            migrationBuilder.DropColumn(
                name: "AvailableSeats",
                table: "Timing");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Timing");

            migrationBuilder.RenameColumn(
                name: "TotalSeats",
                table: "Timing",
                newName: "AirlineId");

            migrationBuilder.AddColumn<int>(
                name: "AvailableSeats",
                table: "Airline",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Airline",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalSeats",
                table: "Airline",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Timing_AirlineId",
                table: "Timing",
                column: "AirlineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Timing_Airline_AirlineId",
                table: "Timing",
                column: "AirlineId",
                principalTable: "Airline",
                principalColumn: "AirlineId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
