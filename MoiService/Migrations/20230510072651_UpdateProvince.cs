using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoiService.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProvince : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Lat",
                table: "Province",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lon",
                table: "Province",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Province");

            migrationBuilder.DropColumn(
                name: "Lon",
                table: "Province");
        }
    }
}
