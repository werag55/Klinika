using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Klinika.Migrations
{
    /// <inheritdoc />
    public partial class AppoitmentTableUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GUID",
                table: "Appoitments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GUID",
                table: "Appoitments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
