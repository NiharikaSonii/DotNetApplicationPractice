using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class Secondmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "To",
                table: "Timing",
                newName: "Destination");

            migrationBuilder.RenameColumn(
                name: "From",
                table: "Timing",
                newName: "Boarding");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Destination",
                table: "Timing",
                newName: "To");

            migrationBuilder.RenameColumn(
                name: "Boarding",
                table: "Timing",
                newName: "From");
        }
    }
}
